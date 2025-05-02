namespace _36_37_Pal
{
    internal class Program
    {
        //2
        static void Main(string[] args)
        { 
        string randomString = GenerateRandomString(32);
        Console.WriteLine("Сгенерированная строка:");
            Console.WriteLine(randomString);
        }
    static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random random = new Random();
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
        }
    }
    //3
    //static void Main(string[] args)
    //{
    //    string input = "PMZYQlypJMHyOLtsrXWdkygdUkkUxqvg";
    //    Duplicate(input);
    //}

    //static void Duplicate(string input)
    //{
    //    Dictionary<char, int> Count = new Dictionary<char, int>();

    //    foreach (char c in input)
    //    {
    //        if (Count.ContainsKey(c))
    //        {
    //            Count[c]++;
    //        }
    //        else
    //        {
    //            Count[c] = 1;
    //        }
    //    }
    //    List<char> duplicates = new List<char>();
    //    foreach (var pair in Count)
    //    {
    //        if (pair.Value > 1)
    //        {
    //            duplicates.Add(pair.Key);
    //        }
    //    }
    //    Console.WriteLine("Повторяющиеся символы: " + string.Join(", ", duplicates));
    //}


    //1
    //static void Main(string[] args)
    //{

    //    Console.WriteLine("Введите текст");
    //    string inputString = Console.ReadLine();
    //    Console.WriteLine("Введите символ, который заменить");
    //    char charToReplace = Console.ReadKey().KeyChar;
    //    Console.WriteLine();
    //    Console.WriteLine("Введите символ, на который нужно заменить");
    //    char replaceWith = Console.ReadKey().KeyChar;
    //    Console.WriteLine();

    //    string resultString = "";

    //    for (int i = 0; i < inputString.Length; i++)
    //    {
    //        if (inputString[i] == charToReplace){resultString += replaceWith;}
    //        else{resultString += inputString[i];}
    //    }
    //    Console.WriteLine("Итог: " + resultString);

    //}
}





