namespace Delegate_Task
{
    internal class Program
    {
        static event Notify Event;
        static List<string> messages = new List<string>();
        static Dictionary<int, string> users = new Dictionary<int, string>
        {
            {4, "User1"},
            {5, "User2"}
        };
        static Dictionary<string, List<string>> subscriptions = new Dictionary<string, List<string>>()
        {
            {"User1", new List<string>()},
            {"User2", new List<string>()}
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите за какого пользователя вы хотите зайти:");
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Value} - {user.Key}");
                }
                Console.WriteLine("0 - Выход");

                int choiceUser;
                if (!int.TryParse(Console.ReadLine(), out choiceUser))
                {
                    Console.WriteLine("Ошибка: введите число!");
                    Console.ReadKey();
                    continue;
                }

                if (choiceUser == 0) break;

                if (!users.ContainsKey(choiceUser))
                {
                    Console.WriteLine("Неверный выбор пользователя!");
                    Console.ReadKey();
                    continue;
                }

                string currentUser = users[choiceUser];
                Console.WriteLine($"Вы зашли за {currentUser}");

                while (true)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Написать сообщение");
                    Console.WriteLine("2 - Подписаться на другого пользователя");
                    Console.WriteLine("3 - Просмотреть полученные сообщения");
                    Console.WriteLine("4 - Выйти из аккаунта");

                    int action;
                    if (!int.TryParse(Console.ReadLine(), out action))
                    {
                        Console.WriteLine("Ошибка: введите число!");
                        continue;
                    }

                    if (action == 1)
                    {
                        Console.WriteLine("Напишите сообщение для подписчиков:");
                        string message = $"{currentUser}: {Console.ReadLine()}";
                        messages.Add(message);
                        Event?.Invoke(message);
                        Console.WriteLine("Сообщение отправлено!");
                    }
                    else if (action == 2)
                    {
                        Console.WriteLine("На кого хотите подписаться?");
                        foreach (var user in users)
                        {
                            if (user.Key != choiceUser)
                                Console.WriteLine($"{user.Value} - {user.Key}");
                        }

                        int subChoice;
                        if (int.TryParse(Console.ReadLine(), out subChoice) && users.ContainsKey(subChoice) && subChoice != choiceUser)
                        {
                            string subscribedTo = users[subChoice];
                            if (!subscriptions[currentUser].Contains(subscribedTo))
                            {
                                subscriptions[currentUser].Add(subscribedTo);
                                Event += ReceiveMessage;
                                Console.WriteLine($"Вы подписались на {subscribedTo}!");
                            }
                            else
                            {
                                Console.WriteLine("Вы уже подписаны на этого пользователя!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор!");
                        }
                    }
                    else if (action == 3)
                    {
                        Console.WriteLine("\nПолученные сообщения:");
                        foreach (var msg in messages)
                        {
                            if (msg.StartsWith(subscriptions[currentUser].Find(x => msg.Contains(x)) ?? ""))
                            {
                                Console.WriteLine(msg);
                            }
                        }
                    }
                    else if (action == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор!");
                    }

                    Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ReceiveMessage(string message) {}
    }
    delegate void Notify(string message);
}
    

