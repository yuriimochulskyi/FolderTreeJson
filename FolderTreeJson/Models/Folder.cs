using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTreeJson.Models
{
    class Folder
    {
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public List<File> Files;
        public List<Folder> Subfolders { get; set; }


        public Folder(DirectoryInfo directory)
        {
            this.Name = directory.Name;
            this.CreationDate = string.Format("{0} {1}", directory.CreationTime.ToShortDateString(), directory.CreationTime.ToShortTimeString());
            this.Subfolders = new List<Folder>();
            this.Files = new List<File>();
        }
    }
}
