namespace _12_13_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Первую точку: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Вторую точку: ");
            int b = Convert.ToInt32(Console.ReadLine());
            if (a == 0 || b == 0)
            {
                Console.WriteLine("Одна из точек лежит в начале системы координат");
            }
            else
            {
                Console.WriteLine("Ни одна из точек не лежит в начале системы координат");
            }
        }
    }
}
