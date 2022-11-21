using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class SchoolClassesController
    {
        public static void GetParentClasses(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            try
            {
                string SortBy = Request["sort"];
                string ParentName = Request["parent"];
                User parent = Database.Instance.GetParents().Where(p => p.Name.Equals(ParentName)).First();
                Student student = Database.Instance.GetStudents().Where(s => s.StudentParent.Equals(parent)).First();
                List<SchoolClass> Classes = Database.Instance.GetSchoolClasses().Where(c => c.StudentsMarks.ContainsKey(student)).ToList();

                if (SortBy.Equals("date"))
                {
                    Classes = Classes.OrderBy(c => c.Date).ToList();
                }

                sw.WriteLine("class|date");

                foreach (SchoolClass schoolClass in Classes)
                {
                    sw.WriteLine(schoolClass.Name + "|" + schoolClass.Date.ToString());
                }
                sw.Flush();
                return;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Classes Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void JoinClass(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

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
                    sw.WriteLine("success");
                    sw.Flush();
                    return;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Join Class Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void GetTeacherClasses(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

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
                    Classes = Classes.OrderBy(c => c.Date).ToList();
                }
                else if (SortBy.Equals("students"))
                {
                    Classes = Classes.OrderByDescending(c => c.StudentsMarks.Count).ToList();
                }

                sw.WriteLine("class|date|students");

                foreach (SchoolClass schoolClass in Classes)
                {
                    sw.WriteLine(schoolClass.Name + "|" + schoolClass.Date.ToString() + "|" + schoolClass.StudentsMarks.Count.ToString());
                }
                sw.Flush();
                return;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Get Classes Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }

        public static void CreateClass(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

            User Teacher = Database.Instance.GetTeachers().Where(t => t.Name.Equals(Request["teacher"])).First();
            SchoolClass NewClass = new SchoolClass() {
                Name = Request["name"],
                ClassTeacher = Teacher,
                Date = new DateTime(Int32.Parse(Request["year"]),
                Int32.Parse(Request["month"]), Int32.Parse(Request["day"])),
                StudentsMarks = new Dictionary<Student, int>(),
                JoinCode = Request["code"]
            };

            Database.Instance.CreateSchoolClassClass(NewClass);
        }

        public static void UpdateClass(Dictionary<string, string> Request, TcpClient Client)
        {
            StreamWriter sw = new StreamWriter(Client.GetStream(), Encoding.ASCII);

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
                    Database.Instance.UpdateSchoolClassDate(UpdatingClass, new DateTime(Int32.Parse(Request["year"]), Int32.Parse(Request["month"]), Int32.Parse(Request["day"])));
                }
                if (Request.ContainsKey("code"))
                {
                    Database.Instance.UpdateSchoolClassCode(UpdatingClass, Request["code"]);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Updating Class Failed");
            }
            sw.WriteLine("fail");
            sw.Flush();
        }
    }
}
