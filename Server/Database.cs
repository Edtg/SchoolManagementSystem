using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public struct User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public struct Student
    {
        public string Name { get; set; }
        public User StudentParent { get; set; }
    }

    public struct SchoolClass
    {
        public string Name { get; set; }
        public User ClassTeacher { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<Student, int> StudentsMarks { get; set; }
        public string JoinCode { get; set; }
    }

    public struct Message
    {
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public User Sender { get; set; }
        public List<User> Receivers { get; set; }
        public bool IsBroadcast { get; set; }
    }

    
    public sealed class Database
    {
        private static Database instance = null;
        private static readonly object padlock = new object();

        public static Database Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Database();
                    }
                    return instance;
                }
            }
        }



        public List<User> Parents { get; set; }
        public List<User> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<SchoolClass> SchoolClasses { get; set; }

        public Database()
        {
            Parents = new List<User>();
            Teachers = new List<User>();
            Students = new List<Student>();
            SchoolClasses = new List<SchoolClass>();

            Seed();
        }

        private void Seed()
        {
            Parents.Add(new User { Name="P1", Password="1234" });


            Students.Add(new Student { Name = "S1", StudentParent = Parents[0] });


            Teachers.Add(new User { Name = "T1", Password = "1234" });

            Dictionary<Student, int> Class1Marks = new Dictionary<Student, int>();
            Class1Marks.Add(Students[0], -1);
            SchoolClasses.Add(new SchoolClass { Name = "Class 1", ClassTeacher = Teachers[0], Date = new DateTime(2022, 12, 1), StudentsMarks = Class1Marks, JoinCode = "C1" });

            Dictionary<Student, int> Class2Marks = new Dictionary<Student, int>();
            //Class2Marks.Add(Students[0], -1);
            SchoolClasses.Add(new SchoolClass { Name = "Class 2", ClassTeacher = Teachers[0], Date = new DateTime(2022, 12, 3), StudentsMarks = Class2Marks, JoinCode = "C2" });

            Dictionary<Student, int> Class3Marks = new Dictionary<Student, int>();
            //Class3Marks.Add(Students[0], -1);
            SchoolClasses.Add(new SchoolClass { Name = "Class 3", ClassTeacher = Teachers[0], Date = new DateTime(2022, 12, 2), StudentsMarks = Class3Marks, JoinCode = "C3" });
        }

        public IEnumerable<User> GetParents()
        {
            return Parents;
        }

        public IEnumerable<User> GetTeachers()
        {
            return Teachers;
        }

        public IEnumerable<Student> GetStudents()
        {
            return Students;
        }

        public IEnumerable<SchoolClass> GetSchoolClasses()
        {
            return SchoolClasses;
        }

        public Dictionary<string, int> GetStudentMarks(Student student)
        {
            var Classes = GetSchoolClasses();
            var StudentClasses = Classes.Where(c => c.StudentsMarks.ContainsKey(student)).ToList();
            Dictionary<string, int> StudentMarks = new Dictionary<string, int>();

            foreach(var StudentClass in StudentClasses)
            {
                StudentMarks.Add(StudentClass.Name, StudentClass.StudentsMarks[student]);
            }

            return StudentMarks;
        }

    }
}
