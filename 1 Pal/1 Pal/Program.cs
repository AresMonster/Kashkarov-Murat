using System;

namespace _1_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Придумайте пароль, чтобы в нем было наличие символа '@',\nдоменная часть содержала ' . ' и длина пароля до @ было не менее 4 символов:");
            string a = Convert.ToString(Console.ReadLine());
            int b = a.IndexOf('@');
            
            if (b == -1 || b == 0 || b == a.Length - 1)
            {
                Console.WriteLine("Отсутствует символ @");
            }
            else if (b <= 4)
            {
                Console.WriteLine("Длина пароля должна быть до @ не менее 4 символов");
            }
            int c = a.IndexOf('.', b);
            if (c == -1)
            {

                Console.WriteLine("После знака @ отсутствует точка");
            }
            else if (c == b + 1)
            {
                throw new ArgumentException("Точка не должна стоять после знака @");
            }
            else if (a.Length < 5)
            {
                throw new ArgumentException("Минимальная длина всего пароля не должно быть меньше 5 символов");
            }
        }
    }
}
