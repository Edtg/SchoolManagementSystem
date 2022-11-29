using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System;
using System.Collections.Generic;

namespace ServerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RequestParseTest()
        {
            string TestRequest = "instruction=test|key1=val1";
            Dictionary<string, string> TestResponse = RequestHandler.ParseRequest(TestRequest);
            Assert.IsNotNull(TestResponse);
            Assert.AreEqual("test", TestResponse["instruction"]);
            Assert.AreEqual("val1", TestResponse["key1"]);
        }

        [TestMethod]
        public void DatabaseCreateAndGetClassTest()
        {
            Database.Instance.SchoolClasses.Clear();

            SchoolClass TestClass = new SchoolClass()
            {
                Name = "TestClass",
                ClassTeacher = Database.Instance.GetTeacher("Teacher1"),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                JoinCode = "TC",
                StudentsMarks = new Dictionary<Student, int>()
            };
            Database.Instance.CreateSchoolClass(TestClass);

            Assert.AreEqual(TestClass, Database.Instance.GetSchoolClass("TestClass"));
        }

        [TestMethod]
        public void SchoolClassControllerParentClassTest()
        {
            DateTime NowDate = DateTime.Now;

            Database.Instance.SchoolClasses.Clear();

            SchoolClass TestClass = new SchoolClass()
            {
                Name = "TestClass",
                ClassTeacher = Database.Instance.GetTeacher("Teacher1"),
                StartDate = NowDate,
                EndDate = NowDate.AddDays(2),
                JoinCode = "TC",
                StudentsMarks = new Dictionary<Student, int>() { { Database.Instance.GetStudent("Student1"), -1} }
            };
            Database.Instance.CreateSchoolClass(TestClass);

            Dictionary<string, string> TestRequest = new Dictionary<string, string>();
            TestRequest.Add("instruction", "parentclasses");
            TestRequest.Add("sort", "date");
            TestRequest.Add("parent", "Parent1");

            List<string> TestResponse = SchoolClassesController.GetParentClasses(TestRequest);

            Assert.AreEqual(1, TestResponse.Count);

            string ExpectedResponse = "TestClass|" + NowDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + NowDate.AddDays(2).ToString("yyyyMMdd:HH:mm:ss") + "|Teacher1|-1";
            Assert.AreEqual(ExpectedResponse, TestResponse[0]);
        }

        [TestMethod]
        public void SchoolClassControllerTeacherClassTest()
        {
            DateTime NowDate = DateTime.Now;

            Database.Instance.SchoolClasses.Clear();

            SchoolClass TestClass = new SchoolClass()
            {
                Name = "TestClass",
                ClassTeacher = Database.Instance.GetTeacher("Teacher1"),
                StartDate = NowDate,
                EndDate = NowDate.AddDays(2),
                JoinCode = "TC",
                StudentsMarks = new Dictionary<Student, int>() { { Database.Instance.GetStudent("Student1"), -1 } }
            };
            Database.Instance.CreateSchoolClass(TestClass);

            Dictionary<string, string> TestRequest = new Dictionary<string, string>();
            TestRequest.Add("instruction", "teacherclasses");
            TestRequest.Add("sort", "date");
            TestRequest.Add("teacher", "Teacher1");

            List<string> TestResponse = SchoolClassesController.GetTeacherClasses(TestRequest);

            Assert.AreEqual(1, TestResponse.Count);

            string ExpectedResponse = "TestClass|" + NowDate.ToString("yyyyMMdd:HH:mm:ss") + "|" + NowDate.AddDays(2).ToString("yyyyMMdd:HH:mm:ss") + "|1";
            Assert.AreEqual(ExpectedResponse, TestResponse[0]);
        }

        [TestMethod]
        public void SchoolClassControllerCreateClasstest()
        {
            DateTime NowDate = DateTime.Now;

            Database.Instance.SchoolClasses.Clear();

            Dictionary<string, string> TestRequest = new Dictionary<string, string>();
            TestRequest.Add("instruction", "createclass");
            TestRequest.Add("name", "TestClass");
            TestRequest.Add("teacher", "Teacher1");
            TestRequest.Add("date", NowDate.ToString("yyyyMMdd:HH:mm:ss"));
            TestRequest.Add("enddate", NowDate.AddDays(2).ToString("yyyyMMdd:HH:mm:ss"));
            TestRequest.Add("code", "TC");

            List<string> TestResponse = SchoolClassesController.CreateClass(TestRequest);

            Assert.AreEqual("success", TestResponse[0]);

            SchoolClass ExpectedClass = new SchoolClass()
            {
                Name = "TestClass",
                ClassTeacher = Database.Instance.GetTeacher("Teacher1"),
                StartDate = NowDate,
                EndDate = NowDate.AddDays(2),
                JoinCode = "TC",
                StudentsMarks = new Dictionary<Student, int>()
            };
            Assert.AreEqual(ExpectedClass, Database.Instance.SchoolClasses[0]);
        }
    }
}