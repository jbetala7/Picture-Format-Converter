using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Format_Converter
{
    public partial class Form3 : Form
    {
        string docFileName = string.Empty, defaultPath;
        System.Drawing.Image img = null;
        public Form3()
        {
            InitializeComponent();
            button2.Enabled = false;
            defaultPath = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            defaultPath = Path.Combine(defaultPath, "Desktop");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = defaultPath;
            openDialog.Title = "Select file to be converted";
            openDialog.Filter = "PNG Files|*.png";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                docFileName = openDialog.FileName;
                img = System.Drawing.Image.FromFile(openDialog.FileName);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPEG Files|*.jpg";
            saveDialog.Title = "JPEG file to be saved";
            saveDialog.InitialDirectory = defaultPath;
            saveDialog.FileName = Path.GetFileNameWithoutExtension(docFileName) + ".jpg";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                img.Save(saveDialog.FileName);
            }
            button2.Enabled = false;
            docFileName = string.Empty;
            MessageBox.Show("Successfully converted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
