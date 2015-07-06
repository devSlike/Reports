using Reports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public static class Generator
    {
        private static String[] _Cities = { "Киев", "Львов", "Днепропетровск" };
        private static String[] _Names = { "Саша", "Петя", "Вася", "Толя", "Женя", "Гриша" };
        private static Category[] _Categories = 
        {
            new Category(".Net"),
            new Category("JS"),
            new Category("PHP"),
            new Category("DB"),
            new Category("OOP"),
            new Category("English")
        };
        private static Random _Random = new Random();

        public static List<User> GetUsers(Int32 count)
        {
            var users = new List<User>();
            for (var i = 0; i < count; ++i)
            {
                var user = new User()
                {
                    Age = _Random.Next(18, 35),
                    Category = _Categories[_Random.Next(_Categories.Count())],
                    City = _Cities[_Random.Next(_Cities.Count())],
                    Email = String.Format("email{0}@email.com", i.ToString()),
                    Name = _Names[_Random.Next(_Names.Count())],
                    University = "Some University"
                };
                users.Add(user);
            }
            return users;
        }

        public static List<Question> GetQuestions(Int32 count)
        {
            var questions = new List<Question>();
            for (var i = 0; i < count; ++i)
            {
                var question = new Question()
                {
                    Category = _Categories[_Random.Next(_Categories.Count())],
                    Text = String.Format("Question number {0}", i.ToString())
                };
                questions.Add(question);
            }
            return questions;
        }

        public static List<TestWork> GetTestWorks(IEnumerable<User> users)
        {
            var testWorks = new List<TestWork>();
            var testNumber = 0;
            foreach (var user in users)
            {
                var testWork = new TestWork()
                {
                    User = user,
                    Time = new TimeSpan(_Random.Next(2), _Random.Next(60), _Random.Next(60)),
                    Result = _Random.Next(100),
                    Test = new Test()
                    {
                        Category = _Categories[_Random.Next(_Categories.Count())],
                        MaxTime = new TimeSpan(1, 0, 0),
                        Name = String.Format("Test number {0}", testNumber.ToString()),
                        PassingScore = 50,
                        Questions = GetQuestions(40)
                    }
                };
                testWorks.Add(testWork);
            }
            return testWorks;
        }
    }
}