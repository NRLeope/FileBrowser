using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WebBrowser = System.Windows.Forms.WebBrowser;

namespace FileBrowser
{
    public partial class FileBrowser2 : Form
    {
        public FileBrowser2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog dialog = new FolderBrowserDialog() { Description="Select Directory:"})
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    webBrowser1.Url = new Uri(dialog.SelectedPath);
                    textBox1.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(webBrowser1.CanGoBack)
                webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
                webBrowser1.GoForward(); 
        }
    }
}
