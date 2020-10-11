using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login
{
    class DBHelper
    {
        internal static int dept = 0;
        internal static int current_id = 0;
        internal static string current_password = "";
        internal static int DEPT_CMPN = 0;
        internal static int DEPT_INFT = 1;
        internal static int DEPT_EXTC = 2;
        internal static int DEPT_ETRX = 3;
        internal static int DEPT_BIOMED = 4;
        internal const string TABLE_NAME = "Details";
        internal const string ID_COLUMN = "u_id";
        internal const string USERNAME_COLUMN = "u_name";
        internal const string PASSWORD_COLUMN = "u_pass";
        internal static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|base.mdf;Integrated Security=True";
        static DataGridView gdv = new DataGridView();
        static SqlDataAdapter gridAdapter;
        static Dictionary<int, Faculty> faculties;
        

        internal static string getPassword(SqlConnection con, int id)
        {
            DataTable dt = new DataTable();
            string query = "select u_pass from Details where u_id=" + id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            return (dt.Rows[0])[PASSWORD_COLUMN].ToString();
        }
        internal static int getID(SqlConnection con, string username)
        {
            DataTable dt = new DataTable();
            string query = "select u_id,u_name from Details";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            foreach (DataRow d in dt.Rows)
            {
                if (username == ((d[USERNAME_COLUMN]).ToString()))
                {
                    return Int32.Parse(d[ID_COLUMN].ToString());
                }
            }
            return -1;
        }
        internal static bool checkDateAvail(SqlConnection con, string date)
        {
            DataTable dt = new DataTable();
            string query = "select e_date from ExamTT where e_date ='" + date + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static bool AddExam(SqlConnection con, string date, int m, int n)
        {
            string query1 = "insert into ExamTT (e_date) values (@date)";
            SqlCommand cmd = new SqlCommand(query1, con);
            con.Open();
            cmd.Parameters.Add("@date", date);
            cmd.ExecuteNonQuery();

            string query2 = "select e_id from ExamTT where e_date = @date";
            cmd = new SqlCommand(query2, con);
            cmd.Parameters.Add("@date", date);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            int eid = Int32.Parse((dt.Rows[0])["e_id"].ToString());

            string query3 = "insert into MorningExam (e_id, m_req) values(@eid,@m)";
            cmd = new SqlCommand(query3, con);
            cmd.Parameters.Add("@eid", eid);
            cmd.Parameters.Add("@m", m);
            cmd.ExecuteNonQuery();

            string query4 = "insert into EveningExam (e_id, eve_req) values(@eid,@n)";
            cmd = new SqlCommand(query4, con);
            cmd.Parameters.Add("@eid", eid);
            cmd.Parameters.Add("@n", n);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        internal static bool addData(SqlConnection con, String username, String name, String password)
        {
            SqlCommand com = new SqlCommand();
            com.ExecuteNonQuery();
            return true;
        }
        internal static bool isFacultyPresent(SqlConnection con, string name)
        {
            DataTable dt = new DataTable();
            string query = "select f_name from Faculty where f_name like '" + name + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static bool addNewUser(SqlConnection con, string u_name, string u_pass)
        {
            SqlCommand com = new SqlCommand("insert into Details(u_name,u_pass) values(@u_name ,@u_pass)", con);
            com.Parameters.Add("@u_pass", u_pass);
            com.Parameters.Add("@u_name", u_name);
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static bool addFaculty(SqlConnection con, string name, int dept, int experience)
        {
            string dept_name = null;
            if (dept == DEPT_CMPN)
            {
                dept_name = "CMPN";
            }
            else if (dept == DEPT_INFT)
            {
                dept_name = "INFT";
            }
            else if (dept == DEPT_EXTC)
            {
                dept_name = "EXTC";
            }
            else if (dept == DEPT_ETRX)
            {
                dept_name = "ETRX";
            }
            else if (dept == DEPT_BIOMED)
            {
                dept_name = "BIOMED";
            }
            SqlCommand com = new SqlCommand("insert into Faculty(f_name,f_dept,f_dept_name,f_exp) values('" + name + "'," + dept + ",'" + dept_name + "'," + experience + ")", con);
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static void deleteRow(DataGridView gdv, string query)
        {
            if (gdv.SelectedRows.Count > 0)
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd;
                con.Open();
                foreach (DataGridViewRow r in gdv.SelectedRows)
                {
                    string value = r.Cells[0].Value.ToString();
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@value", value);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }
        internal static bool changePassword(SqlConnection con, string password)
        {
            SqlCommand com = new SqlCommand("update Details set u_pass = @password where u_id = @current_id", con);
            com.Parameters.Add("@password", password);
            com.Parameters.Add("@current_id", current_id);
            if (com.ExecuteNonQuery() == 1)
            {
                current_password = password;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal static void addDates(SqlConnection con, List<string> selectedDates)
        {


            int e_id;
            string query = "insert into ExamTT (e_date) values (@value)";
            string query2 = "select e_id from ExamTT where e_date = @date";
            string query3 = "insert into MorningExam (e_id,m_req) values (@value,0)";
            string query4 = "insert into EveningExam (e_id,eve_req) values (@value,0)";
            SqlCommand cmd;
            con.Open();
            if (selectedDates.Count != 0)
            {
                //selectedDates = selectedDates.OrderByDescending(x => DateTime.Parse(x));
                foreach (string date in selectedDates)
                {
                    if (checkDateAvail(con, date))
                    {
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add("@value", date);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(query2, con);
                        cmd.Parameters.Add("@date", date);
                        SqlDataReader dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        e_id = Int32.Parse((dt.Rows[0])["e_id"].ToString());

                        cmd = new SqlCommand(query3, con);
                        cmd.Parameters.Add("@value", e_id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand(query4, con);
                        cmd.Parameters.Add("@value", e_id);
                        cmd.ExecuteNonQuery();

                    }
                }
            }
        }

        internal static void refreshFac(DataGridView gdv, string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                gridAdapter = new SqlDataAdapter(query, con);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(gridAdapter);
                DataTable dt = new DataTable();
                gridAdapter.Fill(dt);
                gdv.DataSource = dt;
            }
            catch { }
            finally
            {
                con.Close();
            }
        }

        internal static void refreshAllotment(DataGridView gdv)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                string query_exam = "select e.e_date,m.m_req,eve.eve_req,e.e_id from ExamTT as e,MorningExam as m,EveningExam as eve where e.e_id = m.e_id and e.e_id = eve.e_id and m.e_id = eve.e_id";
                con.Open();
                SqlCommand cmd = new SqlCommand(query_exam, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                Dictionary<int, string> exam = new Dictionary<int, string>();
                foreach (DataRow r in dt.Rows)
                {
                    exam.Add(Int32.Parse(r[3].ToString()), r[0].ToString());
                }
                dt.Columns.RemoveAt(3);
                string faculty_query = "select f_id,f_name,f_dept from Faculty";
                DataTable dt_faculties = new DataTable();
                SqlDataReader dtr = (new SqlCommand(faculty_query, con)).ExecuteReader();
                dt_faculties.Load(dtr);

                Dictionary<int, Faculty> fac = new Dictionary<int, Faculty>();
                foreach (DataRow r in dt_faculties.Rows)
                {
                    fac.Add(Int32.Parse(r[0].ToString()), new Faculty(r[1].ToString(), Int32.Parse(r[2].ToString())));
                }

                string allotment_query = "select * from Allotments";
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
                    int fid = Int32.Parse(drow[2].ToString());
                    datarow["Faculty Name"] = fac[fid].name;
                    datarow["Department"] = Faculty.getDept(fac[fid].dept);
                    if (Int32.Parse(drow[3].ToString()) == 1)
                    {
                        datarow["Shift"] = "Morning";
                    }
                    else if (Int32.Parse(drow[3].ToString()) == 2)
                    {
                        datarow["Shift"] = "Evening";
                    }
                    datarow["Date"] = exam[Int32.Parse(drow[1].ToString())];
                    dt_allotments.Rows.Add(datarow);
                }

                gdv.DataSource = dt_allotments;
                gdv.Columns[0].Width = 300;
                gdv.Columns[1].Width = 300;
                gdv.Columns[2].Width = 200;
                gdv.Columns[3].Width = 250;
                gdv.Columns[0].ReadOnly = true;
                gdv.ForeColor = System.Drawing.Color.Black;
                first.dt_excel = dt_allotments;
                con.Close();
            }
            catch { }
            finally
            {
                con.Close();
            }
        }


        internal static void refreshExam(DataGridView gdv, string query)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                gdv.DataSource = dt;
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        internal static void allot()
        {
            string query = "select * from ExamTT";
            string query2 = "select * from Faculty";
            string query3 = "select m_req from MorningExam where e_id=";
            string query4 = "select eve_req from EveningExam where e_id=";
            string query5 = "select * from FacUnavailable where f_id=";
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter ad;
            con.Open();

            ad = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ad = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            ad.Fill(dt2);
            int teacherAllotTotal = 0;
            int totalReqAllot = 0;

            faculties = new Dictionary<int, Faculty>();
            DataTable unavailable;

            foreach (DataRow r in dt2.Rows)
            {
                int id = Int32.Parse(r[0].ToString());
                string name = r[1].ToString();
                int all = Int32.Parse(r[2].ToString());
                teacherAllotTotal += all;
                List<int> unavail = new List<int>();
                ad = new SqlDataAdapter(query5 + id, con);
                int dept = Int32.Parse(r[4].ToString());
                unavailable = new DataTable();
                ad.Fill(unavailable);
                foreach (DataRow dr in unavailable.Rows)
                {
                    int eid = getDateId(con, dr[2].ToString());
                    if (eid != -1)
                    {
                        unavail.Add(eid);
                    }
                }
                faculties.Add(id, new Faculty(id, name, all, dept, unavail));
            }


            DataTable table;
            List<Exam> exams = new List<Exam>();
            foreach (DataRow r in dt.Rows)
            {
                int id = Int32.Parse(r[0].ToString());
                string date = r[1].ToString();

                ad = new SqlDataAdapter(query3 + id, con);
                table = new DataTable();
                ad.Fill(table);
                int morning = Int32.Parse(table.Rows[0][0].ToString());
                ad = new SqlDataAdapter(query4 + id, con);
                table = new DataTable();
                ad.Fill(table);
                int evening = Int32.Parse(table.Rows[0][0].ToString());
                totalReqAllot += morning + evening;
                exams.Add(new Exam(id, date, morning, evening));
            }

            if (totalReqAllot <= teacherAllotTotal)
            {
                List<int> facultiesId = new List<int>();
                List<int> examsId = new List<int>();
                Dictionary<int, List<int>> facAvailable = new Dictionary<int, List<int>>();
                foreach (Exam e in exams)
                {
                    int eid = e.id;
                    examsId.Add(eid);
                    facultiesId.Clear();
                    foreach (KeyValuePair<int, Faculty> f in faculties)
                    {
                        if (!f.Value.unavailableDatesId.Contains(eid))
                        {
                            facultiesId.Add(f.Value.id);
                        }
                    }
                    facAvailable.Add(eid, facultiesId);

                }
                Dictionary<Tuple<int, int>, List<int>> allotments = new Dictionary<Tuple<int, int>, List<int>>();
                bool noerror = true;
                foreach (Exam e in exams)
                {
                    int eid = e.id;
                    List<Faculty> availFac = new List<Faculty>();
                    foreach (int f in facAvailable[eid])
                    {
                        if (faculties[f].remAllotments >= 1)
                        {
                            availFac.Add(faculties[f]);
                        }
                    }
                    int total = e.MorningReq + e.EveningReq;
                    if (total <= availFac.Count)
                    {
                        allotments.Add(Tuple.Create(eid, 1), allotFaculties(eid, 1, e.MorningReq, availFac));
                        allotments.Add(Tuple.Create(eid, 2), allotFaculties(eid, 2, e.EveningReq, availFac));
                    }
                    else
                    {
                        MessageBox.Show("No faculty available for " + e.date);
                        noerror = false;
                        break;
                    }
                }
                if (noerror)
                {
                    string q = "truncate table Allotments";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    q = "insert into allotments(exam_id,shift,fac_id) values (@val_eid,@val_shift,@val_fid)";
                    foreach (KeyValuePair<Tuple<int, int>, List<int>> a in allotments)
                    {
                        foreach (int f in a.Value)
                        {
                            cmd = new SqlCommand(q, con);
                            cmd.Parameters.Add("@val_eid", a.Key.Item1);
                            cmd.Parameters.Add("@val_shift", a.Key.Item2);
                            cmd.Parameters.Add("@val_fid", f);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Done");

                }

            }
            else
            {
                MessageBox.Show("Total of faculties' allotments are less than total examination allotments.\n\nTotal of faculties' allotments: " + teacherAllotTotal + "\nTotal examination allotments: " + totalReqAllot);
            }
        }

        internal static int getDateId(SqlConnection con, string date)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select e_id from ExamTT where e_date like '" + date + "'", con);
            adapter.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return Int32.Parse(dt.Rows[0][0].ToString());
            }
            else
            {
                return -1;
            }
        }

        internal static List<int> allotFaculties(int eid, int shift, int totalRequired, List<Faculty> availFac)
        {
            int allotCount = 0;
            List<int> fidList = new List<int>();

            while (allotCount < totalRequired)
            {

                foreach (Faculty f in availFac)
                {

                    if (f.dept == dept)
                    {
                        faculties[f.id].remAllotments--;
                        fidList.Add(f.id);
                        availFac.Remove(f);
                        allotCount++;
                        break;
                    }
                }
                dept = (dept + 1) % 5;
            }
            return fidList;
        }

        internal static Tuple<int, int> getAllotmentId(DataGridViewRow dr)
        {
            string date = dr.Cells[0].Value.ToString();
            int allot_id = 0;
            int date_id = 0;
            int fac_id = 0;
            string fac_name = dr.Cells[1].Value.ToString();
            string query1 = "select f_id from Faculty where f_name like '" + fac_name+"'";
            string query2 = "select e_id from ExamTT where e_date like '" + date+ "'";
            
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter(query1, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            fac_id = Int32.Parse(dt.Rows[0][0].ToString());

            ad = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            ad.Fill(dt2);
            date_id = Int32.Parse(dt2.Rows[0][0].ToString());

            string query = "select allot_id from Allotments where exam_id = " + date_id + "and fac_id = " + fac_id;

            ad = new SqlDataAdapter(query, con);
            DataTable dt3 = new DataTable();
            ad.Fill(dt3);
            allot_id = Int32.Parse(dt3.Rows[0][0].ToString());
            con.Close();

            Tuple<int, int> tup = Tuple.Create(fac_id, allot_id);
            return tup;

        }
    }
}