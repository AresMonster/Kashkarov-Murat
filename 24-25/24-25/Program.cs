using System;
namespace _24_25
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Введите количество элементов массива:");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            Console.WriteLine("Введите элементы массива(ненулевые):");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i < n; i++)
            {
                if (array[i] * array[i - 1] >= 0)
                {
                    Console.WriteLine("Элемент черт: ");
                    Console.WriteLine(i + 1);
                    return;
                }
            }
            Console.WriteLine(0);
        }
    }
}
