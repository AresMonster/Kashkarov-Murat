namespace _14_15_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Factorial(int a)
            {
                if (a == 1) return 1;
                return a * Factorial(a - 1);
            }

            Console.Write("Введите значение M: ");
            int M = int.Parse(Console.ReadLine());

            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());
            double S = 0;
            for (int n = 1; n <= M; n++)
            {
                S += (Math.Sin(n * x)) / (Factorial(n + 1));
            }
            Console.WriteLine($"Сумма S = ∑(sin*n*{x}/(n+1)!) от n=1 до M: {S}");
        }
    }
}
