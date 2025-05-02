using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace _70_71_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите вывод задания:");
            int Taskss = Convert.ToInt32(Console.ReadLine());
            switch (Taskss)
            {
                case 1:
                    var employees = new[]
                    {
                            new { Name = "Иван", Age = 28, Department = "IT" },
                            new { Name = "Мария", Age = 34, Department = "HR" },
                            new { Name = "Анна", Age = 25, Department = "Finance" },
                            new { Name = "Дмитрий", Age = 30, Department = "IT" },
                        };
                    var Depp = employees.Where(d => d.Department == "IT");
                    foreach (var d in Depp)
                    {
                        Console.WriteLine(d);
                    }
                    break;
                case 2:
                    var products = new[]
                    {
                            new { Name = "Яблоко", Price = 100 },
                            new { Name = "Банан", Price = 80 },
                            new { Name = "Груша", Price = 120 },
                        };
                    var pro = products.Select(p => p.Name).ToList();
                    foreach (var p in pro)
                    {
                        Console.WriteLine(p);
                    }
                    break;
                case 3:
                    var books = new[]
                    {
                            new { Title = "Война и мир", Author = "Лев Толстой" },
                            new { Title = "1984", Author = "Джордж Оруэлл" },
                            new { Title = "Собачье сердце", Author = "Михаил Булгаков" },
                        };
                    var bo = books.First(b => b.Author == "Лев Толстой");
                    Console.WriteLine(bo);
                    break;
                case 4:
                    var cars = new[]
                    {
                            new { Brand = "Toyota", Year = 2020 },
                            new { Brand = "Honda", Year = 2018 },
                            new { Brand = "Ford", Year = 2021 },
                        };
                    var ca = cars.OrderBy(c => c.Year).ToList();
                    foreach (var c in ca)
                    {
                        Console.WriteLine(c);
                    }
                    break;
                case 5:
                    var students = new[]
                    {
                          new { Name = "Алексей", Grade = 5 },
                          new { Name = "Мария", Grade = 4 },
                          new { Name = "Дмитрий", Grade = 5 },
                          new { Name = "Елена", Grade = 3 },
                      };
                    var st = students.GroupBy(s => s.Grade).ToList();
                    foreach (var s in st)
                    {
                        foreach (var c in s)
                        {
                            Console.WriteLine(c);
                        }
                    }
                    break;
                case 6:
                    var movies = new[]
                    {
                            new { Title = "Звёздные войны", Genre = "Фантастика" },
                            new { Title = "Зелёная миля", Genre = "Драма" },
                            new { Title = "Властелин колец", Genre = "Фантастика" },
                        };
                    var mo = movies.Count(m => m.Genre == "Фантастика");
                    Console.WriteLine("Количество фильмов с жанром фантастика" + mo);
                    break;
                case 7:
                    var clients = new[]
                    {
                            new { Name = "Андрей", IsActive = false },
                            new { Name = "Светлана", IsActive = true },
                            new { Name = "Николай", IsActive = false },
                        };
                    var cl = clients.Any(cs => cs.IsActive);
                    Console.WriteLine(cl);
                    break;
                case 8:
                    var moviess = new[]
                    {
                            new { Title = "Терминатор", Year = 1984 },
                            new { Title = "Матрица", Year = 1999 },
                            new { Title = "Начало", Year = 2010 },
                            new { Title = "Интерстеллар", Year = 2014 },
                        };
                    var mov = moviess.Last();
                    Console.WriteLine(mov);
                    break;
                case 9:
                    var genres = new[]
                    {
                            new { Name = "Фантастика" },
                            new { Name = "Драма" },
                            new { Name = "Приключения" },
                            new { Name = "Фантастика" },
                            new { Name = "Комедия" },
                        };
                    var ge = genres.Distinct();
                    foreach (var g in ge)
                    {
                        Console.WriteLine(g);
                    }
                    break;
                case 10:
                    var studentss = new[]
                    {
                        new { Name = "Аня", Age = 18 },
                        new { Name = "Борис", Age = 19 },
                        new { Name = "Света", Age = 20 },
                        new { Name = "Игорь", Age = 21 },
                        new { Name = "Фидель", Age = 22 }
                    };
                    var stu = studentss.Take(3);
                    foreach (var ss in stu)
                    {
                        Console.WriteLine(ss);
                    }
                    break;
                case 11:
                    var bookss = new[]
                    {
                        new { Title = "1984", Author = "Джордж Оруэлл" },
                        new { Title = "Гарри Поттер", Author = "Дж.К. Роулинг" },
                        new { Title = "Война и мир", Author = "Лев Толстой" },
                        new { Title = "Мастер и Маргарита", Author = "Михаил Булгаков" },
                        new { Title = "Убить пересмешника", Author = "Харпер Ли" }
                    };
                    var booo = bookss.Skip(2);
                    foreach (var ss in booo)
                    {
                        Console.WriteLine(ss);
                    }
                    break;
                case 12:
                    var courses = new[]
                    {
                        new { CourseName = "Математика", Students = new[] { "Аня", "Борис" } },
                        new { CourseName = "Физика", Students = new[] { "Света", "Игорь", "Фидель" } }
                    };
                    var co = courses.SelectMany(cc => cc.Students);
                    foreach (var cc in co)
                    {
                        Console.WriteLine(cc);
                    }
                    break;
                case 13:
                    var customers = new[]
                    {
                        new { CustomerId = 1, Name = "Иван" },
                        new { CustomerId = 2, Name = "Алексей" },
                    };
                    var orders = new[]
                    {
                        new { OrderId = 101, CustomerId = 1 },
                        new { OrderId = 102, CustomerId = 2 },
                        new { OrderId = 103, CustomerId = 1 },
                    };
                    var jojo = customers.Join(orders,
                    customer => customer.CustomerId,
                    order => order.CustomerId,
                    (customer, order) => new
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.Name,
                        OrderId = order.OrderId
                    });
                    foreach (var jo in jojo)
                    {
                        Console.WriteLine(jo.CustomerId + " " + jo.OrderId + " " + jo.Name);
                    }
                    break;
                case 14:
                    var services = new[]
                    {
                        new { ServiceName = "Стрижка", Price = 500 },
                        new { ServiceName = "Укладка", Price = 1000 },
                        new { ServiceName = "Маникюр", Price = 700 }
                    };
                    var ser = services.Select(ser => new { ser.ServiceName, ser.Price }).ToList();
                    foreach (var se in ser)
                    {
                        Console.WriteLine(se.ServiceName + " " + se.Price );
                    }
                    break;
                case 15:
                    var ordersss = new[]
                    {
                        new { OrderId = 1, Product = "Шоколад", Quantity = 3 },
                        new { OrderId = 2, Product = "Чай", Quantity = 5 },
                        new { OrderId = 3, Product = "Шоколад", Quantity = 2 },
                        new { OrderId = 4, Product = "Кофе", Quantity = 1 },
                        new { OrderId = 5, Product = "Чай", Quantity = 4 }
                    };
                    var ordd = ordersss.GroupBy(or => or.Product)
                        .Select(orr => new {Product = orr.Key, Summa = orr.Sum(or => or.Quantity) });
                    foreach (var orrrd in ordd)
                    {
                        Console.WriteLine(orrrd);
                    }
                    break;
                case 16:
                    var studentsss = new[]
                    {
                        new { Name = "Анна", Score = 85 },
                        new { Name = "Иван", Score = 95 },
                        new { Name = "Мария", Score = 90 },
                        new { Name = "Дмитрий", Score = 78 },
                        new { Name = "Светлана", Score = 88 },
                    };
                    var stud = studentsss.OrderByDescending(ssss => ssss.Score).Take(3);
                    foreach (var ssss in stud)
                    {
                        Console.WriteLine(ssss);
                    }
                    break;
                case 17:
                    var productss = new[]
                    {
                        new { Name = "Яблоко", Price = 100, IsAvailable = true },
                        new { Name = "Банан", Price = 80, IsAvailable = false },
                        new { Name = "Груша", Price = 120, IsAvailable = true },
                        new { Name = "Апельсин", Price = 90, IsAvailable = false }
                    };
                    var pppp = productss.Any(pop => pop.Price < 90);
                        Console.WriteLine(pppp);
                    break;
                case 18:
                    var studentsc = new[] { "Алексей", "Аня", "Мария" };
                    var scores = new[] { 85, 90, 75 };
                    var sts = studentsc.Zip(scores, (first, second) => first + " " + second);
                    foreach (var sc in sts)
                    {
                        Console.WriteLine(sc);
                    }
                    break;
                case 19:
                    var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    var sg = numbers.TakeWhile(sg => sg < 6);
                    foreach (var sq in sg)
                    {
                        Console.WriteLine(sq);
                    }
                    break;
                case 20:
                    var incomes = new[] { 50000, 75000, 64000, 48000, 54000 };
                    var ini = incomes.Aggregate((x, y) => x + y);
                    Console.WriteLine(ini);
                    break;
                case 21:
                    var studentGrades = new[]
                    {
                        new { Name = "Аня", Subject = "Математика", Grade = 5 },
                        new { Name = "Борис", Subject = "Математика", Grade = 4 },
                        new { Name = "Аня", Subject = "Физика", Grade = 5 },
                        new { Name = "Борис", Subject = "Физика", Grade = 3 },
                    };
                    var sgg = studentGrades.GroupBy(sqq => sqq.Name)
                        .Select(gr => new { Name = gr.Key, Average = gr.Average(grade => grade.Grade) });
                    foreach (var sqq in sgg)
                    {
                        Console.WriteLine(sqq);
                    }
                    break;
            }
        }
    }
}   
    

        
    

