using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

class Student
{
    public string FullName { get; set; }
    public string Group { get; set; }
    public double Score { get; set; }

    public Student(string fullName, string group, double score)
    {
        FullName = fullName;
        Group = group;
        Score = score;
    }
}

class Program
{
    static string path = @"C:\40-41 Pal\Data.txt";

    static void Main()
    {
        List<Student> students = LoadStudentsFromFile(path);

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Показать данные студентов");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Выполнить анализ");
            Console.WriteLine("5. Выйти");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"ФИО: {student.FullName}, Группа: {student.Group}, Баллы: {student.Score}");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Введите ФИО студента для удаления:");
                string inputName = Console.ReadLine();
                Student studentToRemove = students.Find(s => s.FullName.Equals(inputName, StringComparison.OrdinalIgnoreCase));

                if (studentToRemove != null)
                {
                    students.Remove(studentToRemove);
                    SaveStudentsToFile(students);
                    Console.WriteLine($"Студент {inputName} был удалён.");
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Введите данные студента (ФИО, Группа, Баллы):");
                string input = Console.ReadLine();
                string[] parts = input.Split(',');

                if (parts.Length == 3)
                {
                    string fullName = parts[0].Trim();
                    string group = parts[1].Trim();

                    if (double.TryParse(parts[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double score))
                    {
                        students.Add(new Student(fullName, group, score));
                        SaveStudentsToFile(students);
                        Console.WriteLine($"Студент {fullName} добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректные баллы. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный формат ввода. Убедитесь, что введены все поля.");
                }
            }
            else if (choice == "4")
            {
                // Выполняем анализ
                AnalyzeStudents(students);
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Некорректный выбор. Попробуйте снова.");
            }
        }
    }

    static List<Student> LoadStudentsFromFile(string path)
    {
        List<Student> students = new List<Student>();
        foreach (string line in File.ReadLines(path))
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3 && double.TryParse(parts[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double score))
            {
                students.Add(new Student(parts[0].Trim(), parts[1].Trim(), score));
            }
            else
            {
                Console.WriteLine($"Ошибка в строке: {line}");
            }
        }
        return students;
    }

    static void SaveStudentsToFile(List<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (var student in students)
            {
                writer.WriteLine($"{student.FullName}, {student.Group}, {student.Score}");
            }
        }
    }

    static void AnalyzeStudents(List<Student> students)
    {
        // 3.1.1) Фамилии и их количество
        var surnames = students
            .Select(s => s.FullName.Split(' ')[0])
            .GroupBy(s => s)
            .Select(g => new { Surname = g.Key, Count = g.Count() });
        Console.WriteLine("Фамилии и количество студентов:");
        foreach (var item in surnames)
            Console.WriteLine($"{item.Surname} - {item.Count}");

        // 3.1.2) Имена и их количество
        var names = students
            .Select(s => s.FullName.Split(' ')[1])
            .GroupBy(s => s)
            .Select(g => new { Name = g.Key, Count = g.Count() });
        Console.WriteLine("\nИмена и количество студентов:");
        foreach (var item in names)
            Console.WriteLine($"{item.Name} - {item.Count}");

        // 3.1.3) Отчества и их количество
        var patro = students
            .Select(s => s.FullName.Split(' ')[2])
            .GroupBy(s => s)
            .Select(g => new { Patronymic = g.Key, Count = g.Count() });
        Console.WriteLine("\nОтчества и количество студентов:");
        foreach (var item in patro)
            Console.WriteLine($"{item.Patronymic} - {item.Count}");

        // 3.1.4) Группы и число студентов в них
        var groups = students
            .GroupBy(s => s.Group)
            .Select(g => new { Group = g.Key, Count = g.Count() });
        Console.WriteLine("\nГруппы и количество студентов:");
        foreach (var g in groups)
            Console.WriteLine($"{g.Group} - {g.Count}");

        // 3.1.5) Баллы и число студентов с таким баллом
        var scores = students
            .GroupBy(s => s.Score)
            .Select(g => new { Score = g.Key, Count = g.Count() });
        Console.WriteLine("\nБалы и сколько студентов набрали такие баллы:");
        foreach (var s in scores)
            Console.WriteLine($"{s.Score} - {s.Count}");

        // 3.1.6) Имена, встречающиеся максимальное количество раз
        int maxNameCount = names.Max(n => n.Count);
        var maxNames = names.Where(n => n.Count == maxNameCount).Select(n => n.Name).Distinct();
        Console.WriteLine("\nИмена, встречающиеся максимальное количество раз:");
        foreach (var n in maxNames)
            Console.WriteLine(n);

        // 3.1.7) Группы, в которых максимальное число студентов
        int maxGroupCount = groups.Max(g => g.Count);
        var maxGroups = groups.Where(g => g.Count == maxGroupCount).Select(g => g.Group);
        Console.WriteLine("\nГруппы с максимальным количеством студентов:");
        foreach (var g in maxGroups)
            Console.WriteLine(g);

        // 3.1.8) Студенты, набравшие максимальный балл
        double maxScore = students.Max(s => s.Score);
        var topStudents = students.Where(s => s.Score == maxScore);
        Console.WriteLine($"\nСтуденты с максимальным баллом ({maxScore}):");
        foreach (var s in topStudents)
            Console.WriteLine($"{s.FullName} — группа: {s.Group}");

        // 3.1.9) Группы, где есть студенты с максимальным баллом
        var groupsWithMaxScoreStudents = topStudents
            .Select(s => s.Group)
            .Distinct();
        Console.WriteLine("\nГруппы, в которых есть студенты с максимальным баллом:");
        foreach (var g in groupsWithMaxScoreStudents)
            Console.WriteLine(g);

        // 3.1.10) Группы с максимальным средним баллом
        var groupAvgScores = students
            .GroupBy(s => s.Group)
            .Select(g => new { g.Key, AvgScore = g.Average(s => s.Score) });
        double maxAvgScore = groupAvgScores.Max(g => g.AvgScore);
        var groupsMaxAvg = groupAvgScores.Where(g => g.AvgScore == maxAvgScore).Select(g => g.Key);
        Console.WriteLine("\nГруппы с максимальным средним баллом:");
        foreach (var g in groupsMaxAvg)
            Console.WriteLine(g);
    }
}
