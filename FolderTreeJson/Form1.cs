using FolderTreeJson.Models;
using FolderTreeJson.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace FolderTreeJson
{
    public partial class FolderTreeJson : Form
    {
        public FolderTreeJson()
        {
            InitializeComponent();
        }

        private Folder selectedFolder { get; set; }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FolderHelper fh = new FolderHelper();
                selectedFolder = fh.GetFoldersData(new DirectoryInfo(openFileDialog.SelectedPath));
                TextJSON.Text = fh.JsonToTree(selectedFolder);
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files|*.json";
            saveFileDialog.Title = "Save an JSON File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter file = System.IO.File.CreateText(saveFileDialog.FileName))
                {
                    file.WriteLine(JsonConvert.SerializeObject(selectedFolder, Formatting.Indented));
                }
            }
        }
    }
}
