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

namespace Login
{
    public partial class AddExam : Form
    {
        DataGridView gdv;
        List<string> selectedDates;
        public AddExam(DataGridView gdvexam)
        {
            InitializeComponent();
            this.CenterToScreen();
            gdv = gdvexam;
            selectedDates = new List<string>();
        }
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch) && ch!=8  && ch != 46)
            {
                e.Handled = true;
            }
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string k = e.Start.ToShortDateString();
            if (monthCalendar1.BoldedDates.Contains(e.Start))
            {
                monthCalendar1.RemoveBoldedDate(e.Start);
                selectedDates.Remove(e.Start.ToShortDateString());
            }
            else
            {
                monthCalendar1.AddBoldedDate(e.Start);
                selectedDates.Add(e.Start.ToShortDateString());
            }
            monthCalendar1.UpdateBoldedDates();
        }
        private void btnaddexam_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DBHelper.connectionString);
            DBHelper.addDates(con, selectedDates);
            string query = "select e.e_date,m.m_req,eve.eve_req from ExamTT as e,MorningExam as m,EveningExam as eve where e.e_id = m.e_id and e.e_id = eve.e_id";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            gdv.DataSource = dt;
            this.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
