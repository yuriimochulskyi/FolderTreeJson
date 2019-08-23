using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTreeJson.Models
{
    class File
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }

        public File(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            this.Name = fileInfo.Name;
            this.Size = fileInfo.Length;
            this.Path = fileInfo.FullName;
        }
    }
}
