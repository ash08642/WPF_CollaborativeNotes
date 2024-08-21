using CollaborativeNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CollaborativeNotes.Models.Tree;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Primitives;

namespace CollaborativeNotes.Models
{
    public class Tree
    {
        public enum Compare
        {
            Equal,
            After,
            Before
        }

        public List<Node> Nodes { get; set; }
        public int LogicalCount { get; set; }
        public int MaxMembers { get; set; }

        public Tree() 
        {
            Nodes = new List<Node>();
        }



        public string getText()
        {
            string text = "";
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                text += this.Nodes[i].Token;
            }
            return text;
        }

        public Node localInsert(string token, int index, int userIndex) {
            Console.WriteLine("local inserted");
            int[] positionAfter;
            int[] positionBefore;

            Node newNode;

            if (index == this.Nodes.Count)
            {
                positionAfter = [this.MaxMembers - 1];
            } 
            else 
            {
                positionAfter = this.Nodes[index].Position;
            }
            if (index - 1 < 0)
            {
                positionBefore = [0];
            }
            else
            {
                positionBefore = this.Nodes[index - 1].Position;
            }

            int[] position = this.generateTreePosition(positionBefore, positionAfter);
            Console.WriteLine(position);

            Console.WriteLine("position before: ", positionBefore);
            Console.WriteLine(position);
            Console.WriteLine("position after: ", positionAfter);

            int[] siteId = [];
            if (this.comparePosition(positionBefore, positionAfter) == Compare.Equal)
            {
                siteId.Concat(this.Nodes[index - 1].SiteId);
                siteId.Append(userIndex);
            }
            else
            {
                siteId = [userIndex];
            }

            newNode = new Node(token, siteId, this.LogicalCount, position);

            this.LogicalCount++;

            this.Nodes.Insert(index, newNode);

            return newNode;
    }

        public Node localDelete(int index)
        {
            Node deletedNode = this.Nodes.ElementAt(index);
            this.Nodes.RemoveAt(index);
            Console.WriteLine(this.Nodes);
            return deletedNode;
        }

        public bool remoteInsert(Node node)
        {
            if (this.Nodes.Count == 0)
            {
                this.Nodes.Add(node);
                return true;
            }
            Console.WriteLine(this.Nodes.Count);
            for (int i = 0; i< this.Nodes.Count; i++)
            {
                if(this.compareNodes(node, this.Nodes[i]) == Compare.Equal)
                {
                    return false;
                }
                if (i == 0)
                {
                    if (this.compareNodes(node, this.Nodes[i]) == Compare.Before)
                    {
                        this.Nodes.Insert(i, node);
                        return true;
                    }
                    continue;
                }
                if (i == this.Nodes.Count - 1)
                {
                    if (this.compareNodes(node, this.Nodes[i]) == Compare.After)
                    {
                        this.Nodes.Add(node);
                        return true;
                    }
                            continue;
                }
                if (this.compareNodes(node, this.Nodes[i - 1]) == Compare.After
                && this.compareNodes(node, this.Nodes[i]) == Compare.Before)
                {
                    this.Nodes.Insert(i, node);
                    return true;
                }
            }
            this.Nodes.Add(node);
            return true;
        }

        public int[] generateTreePosition(int[] positionBefore, int[] positionAfter)
        {
            int[] position = [];
            if (positionBefore.Length < positionAfter.Length) 
            {
                for (int i = 0; i < positionBefore.Length; i++)
                {
                    if (positionBefore[i] == positionAfter[i])
                    {
                        position.Append(positionBefore[i]);
                    } 
                    else if (positionBefore[i] < positionAfter[i])
                    {
                        if (positionBefore[i] + 1 == positionAfter[i])
                        {
                            position.Append(positionBefore[i]);
                            position.Append(1);
                            return position;
                        }
                        else
                        {
                            position.Append(positionBefore[i] + 1);
                            return position;
                        }
                    } 
                    else
                    {
                        Console.WriteLine("PositionBefore comes after PositionAfter");
                    }
                }
                for (int i = positionBefore.Length; i < positionAfter.Length; i++)
                {
                    if (positionAfter[i] == 0)
                    {
                        position.Append(0);
                    }
                    else if (positionAfter[i] == 1)
                    {
                        position.Append(0);
                        position.Append(1);
                        break;
                    }
                    else
                    {
                        position.Append(positionAfter[i] - 1);
                        break;
                    }
                }
                return position;
            } 
            else if (positionBefore.Length > positionAfter.Length)
            {
                if (positionBefore[positionBefore.Length - 1] == this.MaxMembers - 2)
                {
                    position.Concat(positionBefore);
                    position.Append(1);
                }
                else
                {
                    position.Concat(positionBefore);
                    position[position.Length - 1]++;
                }
                return position;
            }
            else
            {
                for (int i = 0; i < positionBefore.Length; i++)
                {
                    if (positionBefore[i] == positionAfter[i])
                    {
                        position.Append(positionBefore[i]);
                    }
                    else if (positionBefore[i] < positionAfter[i])
                    {
                        if (positionBefore[i] + 1 == positionAfter[i])
                        {
                            position.Append(positionBefore[i]);
                            position.Append(1);
                            return position;
                        }
                        else
                        {
                            position.Append(positionBefore[i] + 1);
                            return position;
                        }
                    }
                    else
                    {
                        Console.WriteLine("PositionBefore comes after PositionAfter");
                    }
                }
                return position;
            }
        }

        public bool remoteDelete(Node node)
        {
            for (int i = 0; i < this.Nodes.Count; i++) 
            {
                if (this.compareNodes(node, this.Nodes[i]) == Compare.Equal)
                {
                    this.Nodes.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Compare comparePosition(int[] positionBefore , int[] positionAfter)
        {
            if (positionBefore.Length < positionAfter.Length) 
            {
                for (int i = 0; i < positionBefore.Length; i++)
                {
                    if(positionBefore[i] > positionAfter[i])
                    {
                        return Compare.After;
                    } 
                    else if(positionBefore[i] < positionAfter[i])
                    {
                        return Compare.Before;
                    }
                }
                return Compare.Before;
            } 
            else if (positionBefore.Length > positionAfter.Length)
            {
                for (int i = 0; i < positionAfter.Length; i++)
                {
                    if (positionBefore[i] > positionAfter[i])
                    {
                        return Compare.After;
                    }
                    else if (positionBefore[i] < positionAfter[i])
                    {
                        return Compare.Before;
                    }
                }
                return Compare.After;
            }
            else
            {
                for (int i = 0; i < positionBefore.Length; i++)
                {
                    if (positionBefore[i] > positionAfter[i])
                    {
                        return Compare.After;
                    }
                    else if (positionBefore[i] < positionAfter[i])
                    {
                        return Compare.Before;
                    }
                }
                return Compare.Equal;
            }
        }

        public Compare compareNodes(Node nodeBefore, Node nodeAfter)
        {
            Compare result = this.comparePosition(nodeBefore.Position, nodeAfter.Position);
            if (result != Compare.Equal)
            {
                return result;
            }
            else
            {
                result = this.comparePosition(nodeBefore.SiteId, nodeAfter.SiteId);
                return result;
            }
        }
    }
}
