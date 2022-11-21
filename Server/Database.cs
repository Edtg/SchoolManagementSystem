using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public struct Parent
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public struct Teacher
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public struct Student
    {
        public string Name { get; set; }
        public Parent StudentParent { get; set; }
    }

    public struct SchoolClass
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public Dictionary<Student, int> StudentsMarks { get; set; }

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



        public List<Parent> Parents { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<SchoolClass> SchoolClasses { get; set; }

        public Database()
        {
            Parents = new List<Parent>();
            Teachers = new List<Teacher>();
            Students = new List<Student>();
            SchoolClasses = new List<SchoolClass>();

            Seed();
        }

        private void Seed()
        {
            Parents.Add(new Parent { Name="Ed", Password="1234" });
        }

        public IEnumerable<Parent> GetParents()
        {
            return Parents;
        }

        public IEnumerable<Teacher> GetTeachers()
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
