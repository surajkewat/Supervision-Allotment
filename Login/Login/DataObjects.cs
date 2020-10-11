using System.Collections.Generic;

namespace Login
{
    public class Faculty
    {
        internal int id;
        internal string name;
        internal int dept;
        internal int allotments;
        internal int remAllotments;
        internal List<int> unavailableDatesId = new List<int>(); 
        public Faculty(string name, int dept)
        {
            this.name = name;
            this.dept = dept;
        }
        public Faculty(int id,string name,int allotments,int dept,List<int> unavailableDates)
        {
            this.id = id;
            this.name = name;
            this.allotments = allotments;
            this.dept = dept;
            unavailableDatesId = unavailableDates;
            remAllotments = allotments;
        }
        public static string getDept(int dept) {
            switch (dept) {
                case 0:
                    return "CMPN";
                case 1:
                    return "INFT";
                case 2:
                    return "EXTC";
                case 3:
                    return "ETRX";
                case 4:
                    return "BIOMED";
            }
            return null;
        }
    }
    public class Exam
    {
        internal int id;
        internal string date;
        
        internal int MorningReq;
        internal int EveningReq;
        internal int remMorningAllotments;
        internal int remEveningAllotments;
        public Exam(int id, string date, int MorningReq,int EveningReq)
        {
            this.id = id;
            this.date = date;
            this.MorningReq = MorningReq;
            this.EveningReq = EveningReq;
            remMorningAllotments = MorningReq;
            remEveningAllotments = EveningReq;
        }
        
    }
    public class Allotments
    {
        internal int e_id;
        internal string e_date;
        internal int slot_id;
        internal int f_id;
        internal string f_name;
        public Allotments(int e_id, string e_date, int slot_id, int f_id, string f_name)
        {
            this.e_id = e_id;
            this.e_date = e_date;
            this.slot_id = slot_id;
            this.f_id = f_id;
            this.f_name = f_name;
        }
        public void swapAllotments(ref Allotments al1, ref Allotments al2)
        {
            int temp_id;
            string temp_name;

            temp_id = al1.f_id;
            al1.f_id = al2.f_id;
            al2.f_id = temp_id;

            temp_name = al1.f_name;
            al1.f_name = al2.f_name;
            al2.f_name = temp_name;
        }
    }
}