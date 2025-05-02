namespace _34_35_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintOddNumbers();
        }
        static void PrintOddNumbers()
        {
            int number;
            while (true)
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number == 0)
                    break;
                if (number % 2 != 0)
                {
                    Console.WriteLine("Нечетное число: " + number);
                }
            }
        }
    }
}
