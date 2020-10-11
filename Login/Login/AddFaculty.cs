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

namespace Login
{
    public partial class AddFaculty : Form
    {
        SqlConnection con;
        DataGridView gdv;

        public AddFaculty(DataGridView gridView)
        {
            InitializeComponent();
            con = new SqlConnection(DBHelper.connectionString);
            gdv = gridView;
            con.Open();
        }
        private void addfacbutton_Click(object sender, EventArgs e)
        {
            if (addFac())
            {
                this.Close();
            }
        }

        private void addmorefacbutton_Click(object sender, EventArgs e)
        {
            if (addFac())
            {
                txtfac1.Text = "";
                txtfac2.Text = "";
                dpfac1.selectedIndex = -1;
            }

        }
        private bool addFac()
        {
            experience_valid.Visible = false;
            if (txtfac1.Text != "" && txtfac2.Text != "" && dpfac1.selectedIndex != -1)
            {
                int exp;
                if (Int32.TryParse(txtfac2.Text, out exp))
                {
                    if (DBHelper.isFacultyPresent(con, txtfac1.Text))
                    {
                        MessageBox.Show("This faculty is already present in database.");
                    }
                    else
                    {
                        if(DBHelper.addFaculty(con, txtfac1.Text, dpfac1.selectedIndex, exp))
                        {
                            DBHelper.refreshFac(gdv, "select f_name, f_noofalloment,f_exp, f_dept_name from Faculty");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    experience_valid.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Faculty Data.");
            }
            return false;
        }
        
    }
}
