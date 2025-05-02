
//using System.Linq;
//using System.Net;
//using System.Xml.Linq;
//public struct Journal
//{
//    public string Name;
//    public int Year;
//    public int Number;
//    public string Direction;

//    public Journal(string name, int year, int number, string direction)
//    {
//        Name = name;
//        Year = year;
//        Number = number;
//        Direction = direction;
//    }
//}


//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            List<Journal> journals = new List<Journal>
//            {
//                new Journal("Just some shityo", 2032, 27,"shityo"),
//                new Journal("Vyazanie eto prosto", 2200, 108,"vyazanie"),
//                new Journal("Kak shit sebe chtoto", 2077, 77,"shityo")
//            };

//            Console.WriteLine("Введите направление искомого журнала(shityo,vyazanie):");
//            string searchDirection = Convert.ToString(Console.ReadLine());


//            var available = journals.Where(journal = searchDirection);

//            if (journals != null)
//            {
//                foreach (var journal in searchDirection)
//                {
//                    Console.WriteLine($"Имя: {journal.Name}, Год: {journal.Year}, Номер: {journal.Number}, Напраление: {journal.Direction}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Запись не найдена.");
//            }
//        }
//    }
public struct Journal
{
    public string Name;
    public int Year;
    public int Number;
    public string Direction;

    public Journal(string name, int year, int number, string direction)
    {
        Name = name;
        Year = year;
        Number = number;
        Direction = direction;
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        List<Journal> journals = new List<Journal>
            {
                new Journal("Just some shityo", 2032, 27, "shityo"),
                new Journal("Vyazanie eto prosto", 2200, 108, "vyazanie"),
                new Journal("Kak shit sebe chtoto", 2077, 77, "shityo")
            };

        Console.WriteLine("Введите направление искомого журнала (shityo, vyazanie):");
        string searchDirection = Console.ReadLine();

        var availableJournals = journals.Where(journal => journal.Direction.Equals(searchDirection)).ToList();

        if (availableJournals.Any())
        {
            foreach (var journal in availableJournals)
            {
                Console.WriteLine($"Имя: {journal.Name}, Год: {journal.Year}, Номер: {journal.Number}, Направление: {journal.Direction}");
            }
        }
        else
        {
            Console.WriteLine("Запись не найдена.");
        }
    }
}



//Journal a;
//a.name = "Just some shityo";
//a.year = 2032;
//a.number = 27;
//a.direction = "shityo";
//Journal b;
//b.name = "Vyazanie eto prosto";
//b.year = 2200;
//b.number = 108;
//b.direction = "vyazanie";
//Journal c;
//c.name = "Kak shit sebe chtoto";
//c.year = 2077;
//c.number = 77;
//c.direction = "shityo";

//Console.WriteLine($"Имя: {a.name} Год: {a.year} Номер: {a.number} Направление: {a.direction} .");

//new Journal { name = "Just some shityo", year = 2032, number = 27, direction = "shityo" },
//new Journal { name = "Vyazanie eto prosto", year = 2200, number = 108, direction = "vyazanie" },
//new Journal { name = "Kak shit sebe chtoto", year = 2077, number = 77, direction = "shityo" }