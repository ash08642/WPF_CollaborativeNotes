using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollaborativeNotes.Models
{
    public class Tree
    {
        public Node[] Nodes { get; set; }
        public int LogicalCount { get; set; }
        public int MaxMembers { get; set; }

        public Tree(Node[] nodes, int logicalCount, int maxMembers) 
        {
            this.Nodes = nodes;
            this.LogicalCount = logicalCount;
            this.MaxMembers = maxMembers;
        }

        public string getText()
        {
            string text = "";
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                text += this.Nodes[i].Token;
            }
            return text;
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
    }
}
