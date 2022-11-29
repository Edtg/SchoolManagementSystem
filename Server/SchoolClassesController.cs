using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class SchoolClassesController
    {
        #region Parent functions
        public static List<string> GetParentClasses(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SortBy = Request["sort"];
                string ParentName = Request["parent"];
                User parent = Database.Instance.GetParents().Where(p => p.Name.Equals(ParentName)).First();
                Student student = Database.Instance.GetStudents().Where(s => s.StudentParent.Equals(parent)).First();
                List<SchoolClass> Classes = Database.Instance.GetSchoolClasses().Where(c => c.StudentsMarks.ContainsKey(student)).ToList();

                if (SortBy.Equals("date"))
                {
                    Classes = Classes.OrderBy(c => c.StartDate).ToList();
                }

                if (Classes.Count == 0)
                {
                    Response.Add("empty");
                    return Response;
                }

                foreach (SchoolClass schoolClass in Classes)
                {
                    int Marks = -1;
                    if (Session.Instance.SimulatedDate >= schoolClass.EndDate)
                    {
                        schoolClass.StudentsMarks.TryGetValue(student, out Marks);
                    }
                    Response.Add(schoolClass.Name + "|" + schoolClass.StartDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.EndDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.ClassTeacher.Name + "|" + Marks.ToString());
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Classes Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> JoinClass(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string Code = Request["code"];
                string ParentName = Request["parent"];
                SchoolClass schoolClass = Database.Instance.GetSchoolClasses().Where(c => c.JoinCode.Equals(Code)).First();
                User parent = Database.Instance.GetParents().Where(p => p.Name.Equals(ParentName)).First();
                Student student = Database.Instance.GetStudents().Where(s => s.StudentParent.Equals(parent)).First();

                if (!schoolClass.StudentsMarks.ContainsKey(student))
                {
                    schoolClass.StudentsMarks.Add(student, -1);
                    Console.WriteLine("Student joined " + schoolClass.Name);
                    Response.Add("success");
                    return Response;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Join Class Failed");
            }
            Response.Add("fail");
            return Response;
        }

        #endregion

        #region Teacher functions

        public static List<string> GetTeacherClasses(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SortBy = Request["sort"];
                string TeacherName = Request["teacher"];
                User teacher = Database.Instance.GetTeachers().Where(t => t.Name.Equals(TeacherName)).First();
                List<SchoolClass> Classes = Database.Instance.GetSchoolClasses().Where(c => c.ClassTeacher.Equals(teacher)).ToList();

                if (SortBy.Equals("name"))
                {
                    Classes = Classes.OrderBy(c => c.Name).ToList();
                }
                else if (SortBy.Equals("date"))
                {
                    Classes = Classes.OrderBy(c => c.StartDate).ToList();
                }
                else if (SortBy.Equals("students"))
                {
                    Classes = Classes.OrderByDescending(c => c.StudentsMarks.Count).ToList();
                }

                foreach (SchoolClass schoolClass in Classes)
                {
                    Response.Add(schoolClass.Name + "|" + schoolClass.StartDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.EndDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.StudentsMarks.Count.ToString());
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Classes Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> GetClassInfo(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                SchoolClass schoolClass = Database.Instance.GetSchoolClass(Request["classname"]);
                Response.Add(schoolClass.Name + "|" + schoolClass.StartDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.EndDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + schoolClass.JoinCode);

                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Class Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> GetClassMarks(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                SchoolClass schoolClass = Database.Instance.GetSchoolClass(Request["classname"]);

                if (schoolClass.StudentsMarks.Count > 0)
                {
                    foreach (var Marks in schoolClass.StudentsMarks)
                    {
                        Response.Add(Marks.Key.Name + "|" + Marks.Value);
                    }
                }
                else
                {
                    Response.Add("empty");
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Class Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> CreateClass(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                User Teacher = Database.Instance.GetTeachers().Where(t => t.Name.Equals(Request["teacher"])).First();
                SchoolClass NewClass = new SchoolClass()
                {
                    Name = Request["name"],
                    ClassTeacher = Teacher,
                    StartDate = DateTime.ParseExact(Request["date"], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact(Request["enddate"], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture),
                    StudentsMarks = new Dictionary<Student, int>(),
                    JoinCode = Request["code"]
                };

                Database.Instance.CreateSchoolClassClass(NewClass);

                Response.Add("success");
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Updating Class Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> UpdateClass(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SchoolClassName = Request["classname"];
                SchoolClass UpdatingClass = Database.Instance.GetSchoolClasses().Where(c => c.Name == SchoolClassName).First();

                if (Request.ContainsKey("name"))
                {
                    Database.Instance.UpdateSchoolClassName(UpdatingClass, Request["name"]);
                }
                if (Request.ContainsKey("teacher"))
                {
                    User Teacher = Database.Instance.GetTeachers().Where(t => t.Name == Request["Name"]).First();
                    Database.Instance.UpdateSchoolClassTeacher(UpdatingClass, Teacher);
                }
                if (Request.ContainsKey("year") && Request.ContainsKey("month") && Request.ContainsKey("day"))
                {
                    Database.Instance.UpdateSchoolClassStartDate(UpdatingClass, new DateTime(Int32.Parse(Request["year"]), Int32.Parse(Request["month"]), Int32.Parse(Request["day"])));
                }
                if (Request.ContainsKey("endyear") && Request.ContainsKey("endmonth") && Request.ContainsKey("endday"))
                {
                    Database.Instance.UpdateSchoolClassEndDate(UpdatingClass, new DateTime(Int32.Parse(Request["endyear"]), Int32.Parse(Request["endmonth"]), Int32.Parse(Request["endday"])));
                }
                if (Request.ContainsKey("code"))
                {
                    Database.Instance.UpdateSchoolClassCode(UpdatingClass, Request["code"]);
                }
                Response.Add("success");
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Updating Class Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> UpdateMarks(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string ClassName = Request["classname"];
                string StudentName = Request["student"];
                int Marks = Int32.Parse(Request["marks"]);

                SchoolClass Class = Database.Instance.GetSchoolClass(ClassName);
                Student student = Database.Instance.GetStudent(StudentName);
                Class.StudentsMarks[student] = Marks;

                Response.Add("success");
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Updating Marks Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> GetClassParents(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                string SchoolClassName = Request["class"];
                SchoolClass Class = Database.Instance.GetSchoolClasses().Where(c => c.Name.Equals(SchoolClassName)).First();

                List<User> Parents = Database.Instance.GetParentsForClass(Class).ToList();

                if (Parents.Count == 0)
                {
                    Console.WriteLine("No Students In Class");
                    Response.Add("empty");
                    return Response;
                }

                foreach (User Parent in Parents)
                {
                    Response.Add(Parent.Name);
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Getting Class Parents Failed");
            }
            Response.Add("fail");
            return Response;
        }

        public static List<string> RemoveClass(Dictionary<string, string> Request)
        {
            List<string> Response = new List<string>();

            try
            {
                if (Database.Instance.RemoveSchoolClass(Request["classname"]))
                {
                    Response.Add("success");
                }
                else
                {
                    Response.Add("fail");
                }
                return Response;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Getting Class Parents Failed");
            }
            Response.Add("fail");
            return Response;
        }

        #endregion
    }
}
