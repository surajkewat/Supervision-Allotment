using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Login
{
    public partial class Form1 : Form
    {
        string username;
        string pass;
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|base.mdf;Integrated Security=True";
        public Form1()
        {
            
            InitializeComponent();
        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string SQL = "select u_name,u_pass from Details";
            SqlConnection con = new SqlConnection(connectionString);
            username = txtusername.Text;
            pass = txtpass.Text;
            int id = DBHelper.getID(con, username);
            if (id!=-1)
            {
                if (pass== DBHelper.getPassword(con,id))
                {
                    DBHelper.current_id = id;
                    DBHelper.current_password = pass;
                    MessageBox.Show("Login succs");
                    this.Hide();
                    (new first()).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                MessageBox.Show("User Does not exists");

            }
        }
    }
}
