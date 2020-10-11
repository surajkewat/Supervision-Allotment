using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login.settings
{
    public partial class settings_uc : UserControl
    {
        public settings_uc()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            invisible();
            activepage.Text = "Reset";
            reset.Visible = true;
            bunifuFlatButton3.Normalcolor = System.Drawing.Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            invisible();
            activepage.Text = "Add User";
            adduser.Visible = true;
            bunifuFlatButton2.Normalcolor = System.Drawing.Color.Black;
        }
        private void invisible()
        {
            about.Visible = false;
            adduser.Visible = false;
            reset.Visible = false;
            changepassword.Visible = false;
            bunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent;
            bunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent;
            bunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent;
            bunifuFlatButton4.Normalcolor = System.Drawing.Color.Transparent;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            invisible();
            activepage.Text = "Change Password";
            changepassword.Visible = true;
            bunifuFlatButton1.Normalcolor = System.Drawing.Color.Black;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            invisible();
            activepage.Text = "About";
            about.Visible = true;
            bunifuFlatButton4.Normalcolor = System.Drawing.Color.Black;
        }

        private void adduser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DBHelper.connectionString);
            con.Open();
            passvalid.Visible = false;
            if (addnewusername.Text!="" && addnewpass.Text!="" && addrepass.Text != "")
            {
                if (DBHelper.getID(con, addnewusername.Text) == -1)
                {
                    if (addnewpass.Text == addrepass.Text)
                    {
                        if (DBHelper.addNewUser(con, addnewusername.Text, addnewpass.Text))
                        {
                            MessageBox.Show("User added successfully");
                        }
                        else
                        {
                            MessageBox.Show("Error adding user. Try again");
                        }
                    }
                    else
                    {
                        passvalid.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Username already exists.");
                }
            }
            else
            {
                MessageBox.Show("Fill all details");
            }
            con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DBHelper.connectionString);
            con.Open();
            change_pass_valid.Visible = false;
            if (old_pass.Text != "" && new_pass.Text != "" && re_pass.Text != "")
            {
                if (DBHelper.current_password == old_pass.Text)
                {
                    if (new_pass.Text == re_pass.Text)
                    {
                        if (DBHelper.changePassword(con,new_pass.Text))
                        {
                            MessageBox.Show("Password has been changed.");
                        }
                        else
                        {
                            MessageBox.Show("Error changing password. Try again");
                        }
                    }
                    else
                    {
                        change_pass_valid.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Current password does not match.");
                }
            }
            else
            {
                MessageBox.Show("Fill all details");
            }
            con.Close();
        }
    }
}
