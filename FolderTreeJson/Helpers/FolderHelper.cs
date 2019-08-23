using FolderTreeJson.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderTreeJson.Helpers
{
    class FolderHelper
    {

        public Folder GetFoldersData(FileSystemInfo fsi)
        {
            Folder folder = new Folder(fsi as DirectoryInfo);

            foreach (FileSystemInfo f in (fsi as DirectoryInfo).GetFileSystemInfos())
            {
                if (f.Attributes == FileAttributes.Directory)
                {
                    Folder subfolder = GetFoldersData(f as DirectoryInfo);
                    folder.Subfolders.Add(subfolder);
                }
                else
                {
                    Models.File file = new Models.File(f.FullName);
                    folder.Files.Add(file);
                }
            }
            return folder;
        }

        public string JsonToTree(Folder folder)
        {
            return JsonConvert.SerializeObject(folder, Formatting.Indented);
        }
    }
}
