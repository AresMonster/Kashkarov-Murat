namespace _16_17_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во чисел a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int count = 1;
            int result = 1;
            while (count <= a)
            {
                count++;
                result += count;
            }
            result = (result / a) - 1;
            Console.WriteLine($"Среднее арифметическое чисел от 1 до {a}: {result}");
        }
    }
}
