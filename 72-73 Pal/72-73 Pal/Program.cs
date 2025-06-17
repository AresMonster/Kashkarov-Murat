namespace _72_73_Pal
{
    public interface IDocument
    {
        string Title { get; set; }
        string Author { get; set; }
        DateTime Created { get; set; }
        void Generate();
        void PrintDetails();
    }
    public abstract class DocumentBase : IDocument
    {
        public string Title { get; set; }
        public string Author { get; set; } = "Система";
        public DateTime Created { get; set; } = DateTime.Now;
        protected string DocumentType { get; init; }
        protected string Format { get; init; }
        public abstract void Generate();

        public virtual void PrintDetails()
        {
            Console.WriteLine($"\nДетали документа:");
            Console.WriteLine($"Тип: {DocumentType}");
            Console.WriteLine($"Формат: {Format}");
            Console.WriteLine($"Название: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Создан: {Created:g}");
        }
    }
    public class PdfDocument : DocumentBase
    {
        public PdfDocument(string type)
        {
            DocumentType = type;
            Format = "PDF";
        }
        public override void Generate()
        {
            Console.WriteLine($"\n[PDF] Документ '{Title}' типа '{DocumentType}' успешно создан!");
            Console.WriteLine("Дополнительные действия: конвертация в PDF/A, установка защиты");
        }
    }
    public class HtmlDocument : DocumentBase
    {
        public HtmlDocument(string type)
        {
            DocumentType = type;
            Format = "HTML";
        }
        public override void Generate()
        {
            Console.WriteLine($"\n[HTML] Документ '{Title}' типа '{DocumentType}' успешно создан!");
            Console.WriteLine("Дополнительные действия: добавление CSS стилей, валидация W3C");
        }
    }
    public class TextDocument : DocumentBase
    {
        public TextDocument(string type)
        {
            DocumentType = type;
            Format = "Plain Text";
        }
        public override void Generate()
        {
            Console.WriteLine($"\n[TEXT] Документ '{Title}' типа '{DocumentType}' успешно создан!");
            Console.WriteLine("Дополнительные действия: форматирование текста, кодировка UTF-8");
        }
    }
    public class DocxDocument : DocumentBase
    {
        public DocxDocument(string type)
        {
            DocumentType = type;
            Format = "DOCX";
        }
        public override void Generate()
        {
            Console.WriteLine($"\n[DOCX] Документ '{Title}' типа '{DocumentType}' успешно создан!");
            Console.WriteLine("Дополнительные действия: добавление оглавления, нумерация страниц");
        }
    }
    public class MarkdownDocument : DocumentBase
    {
        public MarkdownDocument(string type)
        {
            DocumentType = type;
            Format = "Markdown";
        }

        public override void Generate()
        {
            Console.WriteLine($"\n[MD] Документ '{Title}' типа '{DocumentType}' успешно создан!");
            Console.WriteLine("Дополнительные действия: конвертация в HTML, проверка синтаксиса");
        }
    }
    public static class DocumentFactory
    {
        private static readonly Dictionary<string, Func<string, DocumentBase>> FormatCreators = new()
        {
            ["pdf"] = type => new PdfDocument(type),
            ["html"] = type => new HtmlDocument(type),
            ["text"] = type => new TextDocument(type),
            ["docx"] = type => new DocxDocument(type),
            ["md"] = type => new MarkdownDocument(type)
        };

        public static IDocument CreateDocument(string format, string type, string title, string author)
        {
            if (FormatCreators.TryGetValue(format.ToLower(), out var creator))
            {
                var document = creator(type);
                document.Title = title;
                document.Author = author;
                return document;
            }
            throw new ArgumentException("Неизвестный формат документа");
        }

        public static List<string> GetAvailableFormats() => new(FormatCreators.Keys);
    }
    public class DocumentCreator
    {
        private readonly Dictionary<string, string> DocumentTypes = new()
        {
            ["1"] = "Отчет",
            ["2"] = "Письмо",
            ["3"] = "Накладная",
            ["4"] = "Счет",
            ["5"] = "Договор",
            ["6"] = "Приказ",
            ["7"] = "Заявление",
            ["8"] = "Справка",
            ["9"] = "Презентация"
        };
        public void Run()
        {
            Console.WriteLine(" Генератор документов");
            Console.WriteLine("Доступные форматы: " + string.Join(", ", DocumentFactory.GetAvailableFormats()));
            while (true)
            {
                try
                {
                    Console.WriteLine("\n МЕНЮ");
                    Console.WriteLine("1. Создать документ");
                    Console.WriteLine("2. Выход");
                    Console.Write("Выберите действие: ");
                    var action = Console.ReadLine();
                    if (action == "2") break;
                    if (action != "1") continue;
                    CreateNewDocument();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            Console.WriteLine("Работа программы завершена.");
        }

        private void CreateNewDocument()
        {
            Console.WriteLine("\nВыберите тип документа:");
            foreach (var type in DocumentTypes)
            {
                Console.WriteLine($"{type.Key}. {type.Value}");
            }
            Console.Write("Ваш выбор: ");

            var typeChoice = Console.ReadLine();
            if (!DocumentTypes.TryGetValue(typeChoice, out var docType))
                throw new ArgumentException("Неверный тип документа");

            Console.WriteLine("\nВыберите формат документа:");
            var formats = DocumentFactory.GetAvailableFormats();
            for (int i = 0; i < formats.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {formats[i].ToUpper()}");
            }
            Console.Write("Ваш выбор: ");

            var formatChoice = Console.ReadLine();
            if (!int.TryParse(formatChoice, out int formatIndex) || formatIndex < 1 || formatIndex > formats.Count)
                throw new ArgumentException("Неверный формат документа");
            var format = formats[formatIndex - 1];

            Console.Write("\nВведите название документа: ");
            var title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым");

            Console.Write("Введите автора документа: ");
            var author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
                author = "Аноним";

            var document = DocumentFactory.CreateDocument(format, docType, title, author);
            document.Generate();
            document.PrintDetails();

            Console.WriteLine("\n1. Сохранить в файл");
            Console.WriteLine("2. Отправить на печать");
            Console.WriteLine("3. Вернуться в меню");
            Console.Write("Выберите действие: ");

            var postAction = Console.ReadLine();
            switch (postAction)
            {
                case "1":
                    Console.WriteLine($"Документ сохранен как: {title}.{format}");
                    break;
                case "2":
                    Console.WriteLine("Документ отправлен на принтер");
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new DocumentCreator().Run();
        }
    }
}
