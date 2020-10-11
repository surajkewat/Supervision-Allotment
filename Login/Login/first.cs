using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using BunifuAnimatorNS;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Concurrent;

namespace Login
{
    public partial class first: MaterialForm
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|base.mdf;Integrated Security=True";
        int k = 0;
        string fname = "";
        int currentRow = -1;
        int currentRowId = -1;
        int row = -1;
        DataGridViewRow dr1;
        DataGridViewRow dr2;
        public static DataTable dt_excel; 

        SqlConnection sqlConnection;
        public first()
        {
       
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo800,
                Primary.Indigo400, Accent.Red700,
                TextShade.WHITE);
            SqlConnection con = new SqlConnection(DBHelper.connectionString);
            string query = "select e.e_date,m.m_req,eve.eve_req,e.e_id from ExamTT as e,MorningExam as m,EveningExam as eve where e.e_id = m.e_id and e.e_id = eve.e_id and m.e_id = eve.e_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            Dictionary<int, string> exam=new Dictionary<int, string>();
            foreach (DataRow r in dt.Rows)
            {
                    exam.Add(Int32.Parse(r[3].ToString()), r[0].ToString());
            }
            dt.Columns.RemoveAt(3);

            gdvexam.DataSource = dt;
            gdvexam.Columns[0].HeaderText = "Date";
            gdvexam.Columns[1].HeaderText = "Morning Requirments";
            gdvexam.Columns[2].HeaderText = "Evening Requirments";
            gdvexam.Columns[0].Width = 300;
            gdvexam.Columns[1].Width = 300;
            gdvexam.Columns[2].Width = 300;
            gdvexam.Columns[0].ReadOnly = true;
            gdvexam.ForeColor = System.Drawing.Color.Black;
            btndateselect.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Date To_96px.png");
            btndel.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Trash_96px.png");
            btnadd.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Classroom_96px.png");
            bunifuFlatButton3.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Trash_96px.png");
            btnallot.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Run Command_100px.png");
            btnswap.Iconimage = System.Drawing.Bitmap.FromFile("D:\\Supervision Allotment\\Login\\Icons\\Replace_100px.png");


            btndateselect.IconVisible = true;
            btndel.IconVisible = true;
            btnadd.IconVisible = true;
            bunifuFlatButton3.IconVisible = true;
            btnswap.IconVisible = true;
            btnallot.IconVisible = true;
            btnexport.IconVisible = true;

            string faculty_query = "select f_id,f_name,f_dept from Faculty";
            DataTable dt_faculties = new DataTable();
            SqlDataReader dtr = (new SqlCommand(faculty_query, con)).ExecuteReader();
            dt_faculties.Load(dtr);

            Dictionary<int, Faculty> fac=new Dictionary<int, Faculty>();
            foreach (DataRow r in dt_faculties.Rows)
            {
                fac.Add(Int32.Parse(r[0].ToString()),new Faculty(r[1].ToString(), Int32.Parse(r[2].ToString())));
            }

            string allotment_query= "select * from Allotments";
            DataTable dt_allotment_db = new DataTable();
            dt_allotment_db.Load(new SqlCommand(allotment_query, con).ExecuteReader());
            
            DataTable dt_allotments = new DataTable();
            dt_allotments.Columns.Add("Date");
            dt_allotments.Columns.Add("Faculty Name");
            dt_allotments.Columns.Add("Shift");
            dt_allotments.Columns.Add("Department");
            
            
            DataRow datarow;
            foreach (DataRow drow in dt_allotment_db.Rows)
            {
                datarow = dt_allotments.NewRow();
                int fid=Int32.Parse(drow[2].ToString());
                datarow["Faculty Name"]=fac[fid].name;
                datarow["Department"] = Faculty.getDept(fac[fid].dept);
                if (Int32.Parse(drow[3].ToString()) == 1) {
                    datarow["Shift"] = "Morning";
                }
                else if (Int32.Parse(drow[3].ToString()) == 2)
                {
                    datarow["Shift"] = "Evening";
                }
                datarow["Date"] = exam[Int32.Parse(drow[1].ToString())];
                dt_allotments.Rows.Add(datarow);
            }
            
            gdvallotment.DataSource = dt_allotments;
            gdvallotment.Columns[0].Width = 300;
            gdvallotment.Columns[1].Width = 300;
            gdvallotment.Columns[2].Width = 200;
            gdvallotment.Columns[3].Width = 250;
            gdvallotment.Columns[0].ReadOnly = true;
            gdvallotment.ForeColor = System.Drawing.Color.Black;
            dt_excel = dt_allotments;
            con.Close();
        }
        private void main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'baseDataSet.Allotments' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'dates.ExamTT' table. You can move, or remove it, as needed.
            this.examTTTableAdapter.Fill(this.dates.ExamTT);
            // TODO: This line of code loads data into the 'faculty.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter1.Fill(this.faculty.Faculty);
            // TODO: This line of code loads data into the 'facultyList.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.facultyList.Faculty);
        }
        
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addfaculty_Click(object sender, EventArgs e)
        {
            (new AddFaculty(gdvfacultylist)).ShowDialog();
        }
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if(k==0)
            {
                this.gdvfacultylist.Enabled = true;
                k = 1;
            }
        }
        private void btndeleteexam_Click(object sender, EventArgs e)
        {
            string query = "delete from ExamTT where e_date like @value";
            DBHelper.deleteRow(gdvexam,query);
            string query2 = "select e.e_date,m.m_req,eve.eve_req from ExamTT as e,MorningExam as m,EveningExam as eve where e.e_id = m.e_id and e.e_id = eve.e_id";
            DBHelper.refreshExam(gdvexam, query2);
        }
        private void gdvfacultylist_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(DBHelper.connectionString);
            try
            {
                string col_name = "";
                string newValue = gdvfacultylist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                con.Open();
                if (e.ColumnIndex == 0)
                {
                    col_name = "f_name";
                }
                else if (e.ColumnIndex == 1)
                {
                    col_name = "f_noofalloment";
                }
                else if (e.ColumnIndex == 2)
                {
                    col_name = "f_exp";
                }
                else if (e.ColumnIndex == 3)
                {
                    col_name = "f_dept_name";
                }
                string query = "update Faculty set " + col_name + " = @value1 where f_name like @value2";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value1", newValue);
                cmd.Parameters.AddWithValue("@value2", fname);
                cmd.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
        }
        private void gdvfacultylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                if (currentRow != e.RowIndex)
                {
                    unavailablepanel.Visible = true;
                    currentRow = e.RowIndex;
                    fname = gdvfacultylist.Rows[currentRow].Cells[0].Value.ToString();
                    string q = "select f_id from Faculty where f_name like '" + fname + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(q, sqlConnection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    currentRowId = Int32.Parse((dt.Rows[0])[0].ToString());
                    q = "select un_date from FacUnavailable where f_id =" + currentRowId;
                    adapter = new SqlDataAdapter(q, sqlConnection);
                    dt.Clear();
                    adapter.Fill(dt);
                    unavailablefacname.Text = fname;
                    unavailabledates.RemoveAllBoldedDates();
                    foreach (DataRow r in dt.Rows)
                    {
                        unavailabledates.AddBoldedDate(DateTime.Parse(r["un_date"].ToString()));
                    }
                    unavailabledates.UpdateBoldedDates();
                }
            }
            catch
            {

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void gdvexam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tableName = "";
            string columnName = "";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            try
            {
                int newValue = Int32.Parse(gdvexam.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (e.ColumnIndex == 1)
                {
                    columnName = "m_req";
                    tableName = "MorningExam";
                }
                else if (e.ColumnIndex == 2)
                {
                    columnName = "eve_req";
                    tableName = "EveningExam";
                }
                string query = "update " + tableName + " set " + columnName + "= @newValue where e_id = @row";
                cmd = new SqlCommand(query,con);
                cmd.Parameters.Add("@newValue", newValue);
                cmd.Parameters.Add("@row", row);
                
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        private void unavailabledates_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                string query;
                sqlConnection.Open();
                if (unavailabledates.BoldedDates.Contains(e.Start))
                {
                    query = "delete from FacUnavailable where un_date like @value";
                }
                else
                {
                    query = "insert into FacUnavailable(f_id,un_date) values(" + currentRowId + ",@value)";
                }
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.Parameters.Add("@value", e.Start.ToString("dd-MM-yyyy"));
                cmd.ExecuteNonQuery();
                if (unavailabledates.BoldedDates.Contains(e.Start))
                {
                    unavailabledates.RemoveBoldedDate(e.Start);
                }
                else
                {
                    unavailabledates.AddBoldedDate(e.Start);
                }
                unavailabledates.UpdateBoldedDates();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void gdvexam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string date = gdvexam.Rows[e.RowIndex].Cells[0].Value.ToString();
                SqlConnection con = new SqlConnection(DBHelper.connectionString);
                con.Open();
                
                string query = "select e_id from ExamTT where e_date like @value";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.Add("@value",date);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                row = Int32.Parse((dt.Rows[0])["e_id"].ToString());
            }
            catch
            {

            }
        }

        private void gdvallotment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gdvallotment.SelectedRows.Count == 2)
            {
                dr1 = gdvallotment.SelectedRows[0];
                dr2 = gdvallotment.SelectedRows[1];
                
            }
            else
            {
                dr1 = null;
                dr2 = null;
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            string query = "delete from Faculty where  f_name like @value";
            DBHelper.deleteRow(gdvfacultylist, query);
            DBHelper.refreshFac(gdvfacultylist, "select f_name, f_noofalloment,f_exp, f_dept_name from Faculty");
        }
        private void btndateselect_Click(object sender, EventArgs e)
        {
            (new AddExam(gdvexam)).ShowDialog();
        }

        private void btnallot_Click(object sender, EventArgs e)
        {
           string  query = "select * from Allotments";
           DBHelper.allot();
            DBHelper.refreshAllotment(gdvallotment);
        }

        private void btnswap_Click(object sender, EventArgs e)
        {
            if (dr1 == null && dr2 == null)
            {
                MessageBox.Show("You Swap Only 2 Rows");
            }
            else
            {

                string query2 = "select * from Allotments";
                Tuple<int,int> details_1 = DBHelper.getAllotmentId(dr1);
                Tuple<int, int> details_2 = DBHelper.getAllotmentId(dr2);
                string query = "update Allotments set fac_id= @Item1 where allot_id= @Item2";
                SqlConnection con = new SqlConnection(connectionString);
      
                SqlCommand com = new SqlCommand(query,con);
                con.Open();
                com.Parameters.Add("@Item1", details_1.Item1);
                com.Parameters.Add("@Item2", details_2.Item2);
                com.ExecuteNonQuery();

                com = new SqlCommand(query, con);
                com.Parameters.Add("@Item1", details_2.Item1);
                com.Parameters.Add("@Item2", details_1.Item2);
                com.ExecuteNonQuery();
                DBHelper.refreshAllotment(gdvallotment);
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet ws = null;
            ws = wb.Sheets["Sheet1"];
            ws = wb.ActiveSheet;
            ws.Name = "Allotments";
            for(int i=1; i<gdvallotment.Columns.Count +1;i++)
            {
                ws.Cells[1,i] = gdvallotment.Columns[i - 1].HeaderText;
            }
            for(int i = 0; i < gdvallotment.Columns.Count; i++)
            {
                for (int j = 0; j < gdvallotment.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = gdvallotment.Rows[i].Cells[j].Value.ToString();
                }
            }
            var saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.FileName = "Allotments";
            saveFileDialogue.DefaultExt = ".xlsx";
            if (saveFileDialogue.ShowDialog()==DialogResult.OK)
            {
                ws.SaveAs(saveFileDialogue.FileName, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            excel.Quit();
            MessageBox.Show("File Saved Successfully");
        }
    }
}
