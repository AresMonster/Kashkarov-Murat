namespace _60_61_Pal
{
    delegate double Addition(double a, double b);
    delegate double Subtraction(double a, double b);
    delegate double Multiplication(double a, double b);
    delegate double Division(double a, double b);
    delegate double Degree(double a, double b);
    delegate double WholeRoot(double a, double b);
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> historyAddition = new();
            List<string> historySubtraction = new();
            List<string> historyMultiplication = new();
            List<string> historyDivision = new();
            List<string> historyDegree = new();
            List<string> historyRoot = new();

            Addition add = Add;
            Subtraction sub = Sub;
            Multiplication mult = Mult;
            Division div = Div;
            Degree deg = Deg;
            WholeRoot root = Root;

            while (true)
            {
                Console.WriteLine("\nВведите число a:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите число b:");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Выберите операцию: 1-сложение, 2-вычитание," +
                    " 3-умножение, 4-деление, 5-степень, 6-корень, 0-Выход");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                {
                    break;
                }

                double result = 0;
                switch (choice)
                {
                    case 1:
                        result = add(a, b);
                        historyAddition.Add($"{a} + {b} = {result}");
                        break;
                    case 2:
                        result = sub(a, b);
                        historySubtraction.Add($"{a} - {b} = {result}");
                        break;
                    case 3:
                        result = mult(a, b);
                        historyMultiplication.Add($"{a} * {b} = {result}");
                        break;
                    case 4:
                        result = div(a, b);
                        historyDivision.Add($"{a} / {b} = {result}");
                        break;
                    case 5:
                        result = deg(a, b);
                        historyDegree.Add($"{a} ^ {b} = {result}");
                        break;
                    case 6:
                        result = root(a, b);
                        historyRoot.Add($"Квадратный корень из {a} = {result}");
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }
                Console.WriteLine($"Результат: {result}");
            }
            Console.WriteLine("\nИстория операций:\n");
            Console.WriteLine("Сложение:");
            foreach (var entry in historyAddition)
                Console.WriteLine(entry);
            Console.WriteLine("Вычитание:");
            foreach (var entry in historySubtraction)
                Console.WriteLine(entry);
            Console.WriteLine("Умножение:");
            foreach (var entry in historyMultiplication)
                Console.WriteLine(entry);
            Console.WriteLine("Деление:");
            foreach (var entry in historyDivision)
                Console.WriteLine(entry);
            Console.WriteLine("Степень:");
            foreach (var entry in historyDegree)
                Console.WriteLine(entry);
            Console.WriteLine("Квадратный корень:");
            foreach (var entry in historyRoot)
                Console.WriteLine(entry);
        }
            static double Add(double a, double b) => a + b;
            static double Sub(double a, double b) => a - b;
            static double Mult(double a, double b) => a * b;
            static double Div(double a, double b) => a / b;
            static double Deg(double a, double b) => Math.Pow(a, b);
            static double Root(double a, double b) => Math.Sqrt(a); 
    }
}
