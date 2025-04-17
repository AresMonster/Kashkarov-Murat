namespace _10_11_Pal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите r(полярное расстояние): ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите q(полярный угол): ");
            double q = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(Perevod(r, q));
            (double x, double y) Perevod(double r, double q)
            {
                double _x = r * Math.Cos(q);
                double _y = r * Math.Sin(q);
                return (_x, _y);
            }
        }
    }
}
