using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
