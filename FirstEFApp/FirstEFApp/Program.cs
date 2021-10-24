using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EFDbContext db = new EFDbContext())
            {
                // создаем 4 объекта User
                User user1 = new User { SurName = "Иванов", Name = "Иван", Age = 30 };
                User user2 = new User { SurName = "Петров", Name = "Петр", Age = 31 };
                User user3 = new User { SurName = "Тест", Name = "Тест", Age = 29 };
                User user4 = new User { SurName = "Сидоров", Name = "Сидр", Age = 31 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.Users.Add(user3);
                db.Users.Add(user4);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
                Show();

                //удаляем из бд
                User usersDel = db.Users.Where(x => x.SurName == "Тест" && x.Name == "Тест").Single();
                db.Users.Remove(usersDel);
                db.SaveChanges();
                Console.WriteLine("Объект удален");
                Show();

                //редактируем
                User us = db.Users.Where(x => x.SurName == "Сидоров" && x.Name == "Сидр").Single();
                us.Name = "Сид";
                us.Age = 32;
                db.Entry(us).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine("Объект редактировался");
                Show();
            }
            Console.Read();
        }

        public static void Show()
        {
            using (EFDbContext db = new EFDbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} {2} - {3}", u.Id, u.SurName, u.Name, u.Age);
                }
                Console.WriteLine("");
            }
        }
    }
}
