using Reports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Результаты прохождения теста");
            var users = Generator.GetUsers(20);
            var testWorks = Generator.GetTestWorks(users);

            //Список людей, которые прошли тесты.
            //var report1 = testWorks.Select(x => x.User).ToList();
            var report1 = from t in testWorks
                          select t.User;
            Console.WriteLine("\n\nСписок людей, которые прошли тесты\n");
            ShowUsersList(report1);

            //Список тех, кто прошли тесты успешно и уложились во время.
            //var report2 = testWorks.Where(x => x.Result >= x.Test.PassingScore && x.Time <= x.Test.MaxTime).Select(x => x.User).ToList();
            var report2 = from t in testWorks
                          where t.Result >= t.Test.PassingScore && t.Time <= t.Test.MaxTime
                          select t.User;
            Console.WriteLine("\n\nСписок тех, кто прошли тесты успешно и уложились во время\n");
            ShowUsersList(report2);

            //Список людей, которые прошли тесты успешно и не уложились во время
            //var report3 = testWorks.Where(x => x.Result >= x.Test.PassingScore && x.Time > x.Test.MaxTime).Select(x => x.User).ToList();
            var report3 = from t in testWorks
                          where t.Result >= t.Test.PassingScore && t.Time > t.Test.MaxTime
                          select t.User;
            Console.WriteLine("\n\nСписок людей, которые прошли тесты успешно и не уложились во время\n");
            ShowUsersList(report3);

            //Список студентов по городам. (Из Львова: 10 студентов, из Киева: 20)
            var report4 = from t in testWorks
                          group t by t.User.City into g
                          select new { City = g.Key, Count = g.Count() };
            Console.WriteLine("\n\nСписок студентов по городам\n");
            foreach (var r in report4)
                Console.WriteLine(String.Format("{0}: {1} студентов", r.City, r.Count.ToString()));

            //Список успешных студентов по городам.
            var report5 = from t in testWorks
                          where t.Result >= t.Test.PassingScore && t.Time <= t.Test.MaxTime
                          group t by t.User.City into g
                          select new { City = g.Key, Users = g.Select(x => x.User).ToList() };
            Console.WriteLine("\n\nСписок успешных студентов по городам\n");
            foreach (var r in report5)
            {
                Console.WriteLine(String.Format("Город {0}", r.City));
                ShowUsersList(r.Users);
            }

            //Результат для каждого студента - его баллы, время, баллы в процентах для каждой категории.
            var report6 = from t in testWorks
                          select new
                          {
                              User = t.User,
                              Score = t.Result,
                              Time = t.Time,
                              ScoreByCategory = from q in t.Test.Questions
                                                group q by q.Category into g
                                                select new { Category = g.Key, Percent = (Double)g.Count() / t.Test.Questions.Count() * 100 }
                          };
            Console.WriteLine("\n\nРезультат для каждого студента - его баллы, время, баллы в процентах для каждой категории");
            foreach (var r in report6)
            {
                Console.Write(String.Format("\n{0}, баллы: {1}, время: {2}", r.User.ToString(), r.Score, r.Time));
                foreach (var cat in r.ScoreByCategory)
                    Console.Write(String.Format(", {0}: {1}%", cat.Category.Name, cat.Percent.ToString()));
            }
            Console.ReadKey();
        }

        private static void ShowUsersList(IEnumerable<User> users)
        {
            foreach (var u in users)
                Console.WriteLine(u.ToString());
        }
    }
}