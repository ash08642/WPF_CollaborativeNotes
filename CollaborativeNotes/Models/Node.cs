using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeNotes.Models
{
    public class Node
    {
        public string Token {  get; set; }
        public int[] SiteId { get; set; }
        public int LogicalCount { get; set; }
        public int[] Position { get; set; }
	    
        public Node(string token, int[] siteId, int logicalCount, int[] position) 
        {
            this.Token = token;
            this.SiteId = siteId;
            this.LogicalCount = logicalCount;
            this.Position = position;
        }
    }
}
