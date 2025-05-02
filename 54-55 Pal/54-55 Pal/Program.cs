using System.IO;
using System.Text;
namespace _54_55_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("c:\\54-55 Pal");
            FileStream file1 = new FileStream("c:\\54-55 Pal\\numbers.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file1);
            for (int i = 0; i < 257; i++)
            {
                if (i > 0)
                {
                    writer.Write(",");
                }
                writer.Write(i);
            }
            writer.Close();

            //2
            //string[] cars = { "Toyota", "Ford", "Chevrolet", "Honda", "Nissan", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Hyundai", "Kia" };
            //File.WriteAllLines("c:\\54-55 Pal\\cars.txt", cars);

            //3
            //FileStream file1 = new FileStream("c:\\54-55 Pal\\cars.txt", FileMode.Open);
            //StreamReader reader = new StreamReader(file1);
            //string longestLine = string.Empty;
            //string line;
            //while ((line = reader.ReadLine()) != null)
            //{
            //    if (line.Length > longestLine.Length)
            //    {
            //        longestLine = line;

            //    }
            //}
            //Console.WriteLine("Длина самой длинной строки: " + longestLine);
            //reader.Close();

            //4
            //int N = new Random().Next(1, 1000);
            //FileStream file = new FileStream("c:\\54-55 Pal\\Random.txt", FileMode.Create);
            //StreamWriter writer = new StreamWriter(file);
            //for (N = 1; N <= 1000; N++)
            //{
            //    if (N % 2 == 0)
            //    {
            //        writer.WriteLine("Четные числа: " + N);
            //    }

            //}
            //for (N = 1; N <= 1000; N++)
            //{

            //    if (N % 2 != 0)
            //    {
            //        writer.WriteLine("Нечетные числа: " + N);
            //    }
            //}
            //writer.Close();

            //5 individ
            //Directory.CreateDirectory("c:\\54-55 Pal");
            //FileStream file10 = new FileStream("c:\\54-55 Pal\\10", FileMode.Create);
            //FileStream file20 = new FileStream("c:\\54-55 Pal\\20", FileMode.Create);
            //FileStream file30 = new FileStream("c:\\54-55 Pal\\30", FileMode.Create);
            //StreamWriter writer10 = new StreamWriter(file10);
            //StreamWriter writer20 = new StreamWriter(file20);
            //StreamWriter writer30 = new StreamWriter(file30);
            //writer10.Write("Unity");
            //writer20.Write("or");
            //writer30.Write("UE?");
            //writer10.Close();
            //writer20.Close();
            //writer30.Close();
            //string f10 = File.ReadAllText("c:\\54-55 Pal\\10");
            //string f20 = File.ReadAllText("c:\\54-55 Pal\\20");
            //string f30 = File.ReadAllText("c:\\54-55 Pal\\30");
            //string f100 = f10 + " " + f20 + " " + f30;
            //File.WriteAllText("c:\\54-55 Pal\\100", f100);
        }
    }
}
