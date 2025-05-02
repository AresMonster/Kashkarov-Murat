namespace _18_19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int sum = 0;
            int count = 0;
            Console.Write("Введите число(number): ");
            number = Convert.ToInt32(Console.ReadLine());
            int i = 1;
            do
            {
                sum += i;
                count++;
                i++;
            } while (i <= number);
            double average = (double)sum / count;
            Console.WriteLine($"Среднее арифметическое чисел от 1 до {number} равно {average}");
        }
    }
}
