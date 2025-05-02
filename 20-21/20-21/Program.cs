namespace _20_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Первую точку: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Вторую точку: ");
            int b = Convert.ToInt32(Console.ReadLine());
            string jojo = ("");
            if (a == 0 || b == 0)
            {
                jojo = ("Одна из точек лежит в начале системы координат");
                goto da;
            }
            else
            {
                jojo = ("Ни одна из точек не лежит в начале системы координат");
                goto da;
            }

        da: Console.WriteLine(jojo);
        }
    }
}
