using System;

namespace _30_31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите размер массива N:");
            //int N = int.Parse(Console.ReadLine());

            //int[] array = new int[N];
            //Console.WriteLine("Введите элементы массива через пробел:");
            //string[] input = Console.ReadLine().Split(' ');

            //for (int i = 0; i < N; i++)
            //{
            //    array[i] = int.Parse(input[i]);
            //}

            //int temp;
            //for (int i = 0; i < N - 1; i++)
            //{
            //    for (int j = i + 1; j < N; j++)
            //    {
            //        if (array[i] > array[j])
            //        {
            //            temp = array[i];
            //            array[i] = array[j];
            //            array[j] = temp;

            //        }

            //    }
            //}

            //Console.WriteLine("Вывод отсортированного массива по возрастанию: ");
            //for (int i = 0; i < N; i++)
            //{
            //    Console.Write(array[i]);
            //    Console.Write(",");
            //}

            Console.WriteLine("Введите размер массива N:");
            int N = int.Parse(Console.ReadLine());

            int a;
            int[] array = new int[N];
            Console.WriteLine("Введите элементы массива через пробел:");
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < N; i++)
            {
                array[i] = int.Parse(input[i]);
            }

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        a = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = a;
                    }
                }
            }

            Console.WriteLine("Вывод отсортированного массива по убыванию: ");
            for (int i = 0; i < N; i++)
            {
                Console.Write(array[i] + " ");
            }

        }
    }
}
