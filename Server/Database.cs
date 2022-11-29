using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Student
    {
        public string Name { get; set; }
        public User StudentParent { get; set; }
    }

    public class SchoolClass
    {
        public string Name { get; set; }
        public User ClassTeacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Dictionary<Student, int> StudentsMarks { get; set; }
        public string JoinCode { get; set; }
    }

    public class Message
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
        public List<Message> Messages { get; set; }

        public Database()
        {
            Parents = new List<User>();
            Teachers = new List<User>();
            Students = new List<Student>();
            SchoolClasses = new List<SchoolClass>();
            Messages = new List<Message>();

            Seed();
        }

        private void Seed()
        {
            Parents.Add(new User { Name="Parent1", Password="1234" });
            Parents.Add(new User { Name = "Parent2", Password = "12345" });


            Students.Add(new Student { Name = "Student1", StudentParent = Parents[0] });
            Students.Add(new Student { Name = "Student2", StudentParent = Parents[1] });


            Teachers.Add(new User { Name = "Teacher1", Password = "1234" });
            Teachers.Add(new User { Name = "Teacher2", Password = "12345" });
        }

        public IEnumerable<User> GetParents()
        {
            return Parents;
        }

        public User? GetParent(string Name)
        {
            return Parents.Find(p => p.Name.Equals(Name));
        }

        public IEnumerable<User> GetTeachers()
        {
            return Teachers;
        }

        public User? GetTeacher(string Name)
        {
            return Teachers.Find(t => t.Name.Equals(Name));
        }

        public IEnumerable<Student> GetStudents()
        {
            return Students;
        }

        public Student? GetStudent(string Name)
        {
            return Students.Find(s => s.Name.Equals(Name));
        }

        public IEnumerable<SchoolClass> GetSchoolClasses()
        {
            return SchoolClasses;
        }

        public SchoolClass? GetSchoolClass(string Name)
        {
            return SchoolClasses.Find(c => c.Name.Equals(Name));
        }

        public bool RemoveSchoolClass(string Name)
        {
            return SchoolClasses.Remove(GetSchoolClass(Name));
        }

        public IEnumerable<User> GetParentsForClass(SchoolClass Class)
        {
            List<User> Result = new List<User>();

            foreach (var StudentMark in Class.StudentsMarks)
            {
                Student student = StudentMark.Key;
                Result.Add(student.StudentParent);
            }

            return Result;
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

        public void CreateSchoolClassClass(SchoolClass NewClass)
        {
            SchoolClasses.Add(NewClass);
        }

        public void UpdateSchoolClassName(SchoolClass Class, string NewName)
        {
            SchoolClass UpdatedClass = SchoolClasses.Find(c => c.Equals(Class));

            if (UpdatedClass != null)
                UpdatedClass.Name = NewName;
        }

        public void UpdateSchoolClassTeacher(SchoolClass Class, User NewTeacher)
        {
            SchoolClass UpdatedClass = SchoolClasses.Find(c => c.Equals(Class));

            if (UpdatedClass != null)
                UpdatedClass.ClassTeacher = NewTeacher;
        }

        public void UpdateSchoolClassStartDate(SchoolClass Class, DateTime NewDate)
        {
            SchoolClass UpdatedClass = SchoolClasses.Find(c => c.Equals(Class));

            if (UpdatedClass != null)
                UpdatedClass.StartDate = NewDate;
        }

        public void UpdateSchoolClassEndDate(SchoolClass Class, DateTime NewDate)
        {
            SchoolClass UpdatedClass = SchoolClasses.Find(c => c.Equals(Class));

            if (UpdatedClass != null)
                UpdatedClass.EndDate = NewDate;
        }

        public void UpdateSchoolClassCode(SchoolClass Class, string NewCode)
        {
            SchoolClass UpdatedClass = SchoolClasses.Find(c => c.Equals(Class));

            if (UpdatedClass != null)
                UpdatedClass.JoinCode = NewCode;
        }

        public IEnumerable<Message> GetMessages(User User1, User User2)
        {
            return Messages.Where(m => ((m.Receivers.Contains(User1) && m.Sender.Equals(User2)) || (m.Receivers.Contains(User2) && m.Sender.Equals(User1))) && !m.IsBroadcast).OrderBy(m => m.Timestamp).ToList();
        }

        public void CreateMessage(Message NewMessage)
        {
            NewMessage.IsBroadcast = false;
            Messages.Add(NewMessage);
        }

        public IEnumerable<Message> GetBroadcasts(User Receiver)
        {
            return Messages.Where(m => m.Receivers.Contains(Receiver) && m.IsBroadcast);
        }

        public void CreateBroadcast(Message NewBroadcast)
        {
            NewBroadcast.IsBroadcast = true;
            Messages.Add(NewBroadcast);
        }
    }
}
