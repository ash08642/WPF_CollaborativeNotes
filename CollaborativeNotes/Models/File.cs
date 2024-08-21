using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollaborativeNotes.Models
{
    public class File
    {
        public string LocalFileId { get; set; }
        public string ServerFileId { get; set; }
        public string FileName { get; set; }
        public int Version { get; set; }
        public string Content { get; set; }
        public Tree MyTree { get; set; }

        public File
        (
            string localFileId,
            string serverFileId,
            string fileName,
            Tree tree,
            int version = 0,
            string content = ""
        )
        {
            this.LocalFileId = localFileId;
            this.ServerFileId = serverFileId;
            this.FileName = fileName;
            this.Version = version;
            this.Content = content;
            this.MyTree = tree;
            if (this.Content == "")
            {
                this.Content = this.MyTree.getText();
            }
        }

        public void updateContent()
        {
            this.Content = this.MyTree.getText();
        }
    }
}
