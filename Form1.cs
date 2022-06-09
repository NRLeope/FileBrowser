using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string conn = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public static string ut;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxUsrN.Text=="" || textBox1.Text=="")
            {
                MessageBox.Show("Enter username and Password");
                return;
            }
            try
            {
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select UserType from User_Table where Username like'"+textBoxUsrN.Text+ "' COLLATE SQL_Latin1_General_CP1_CS_AS and Password like'" + textBox1.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS ", con);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                if(dt.Rows.Count==1)
                {
                    ut = dt.Rows[0][0].ToString();
                    if(ut=="admin" || ut == "user")
                    {
                        FileBrowser2 FRM = new FileBrowser2();
                        FRM.Show();
                        this.Hide();
                    }
                }
                else 
                {
                    MessageBox.Show("Check Username and Password");
                }
            }
            catch(Exception ex)
            {
               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                 textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }
    }
}
