namespace _74_75_Pal
{
    // 1. Общий интерфейс для всех платежных систем
public interface IPaymentSystem
    {
        bool ProcessPayment(decimal amount);
        string GetPaymentDetails();
    }
    public abstract class PaymentDecorator : IPaymentSystem
    {
        protected readonly IPaymentSystem _paymentSystem;
        protected readonly ILogger _logger;

        protected PaymentDecorator(IPaymentSystem paymentSystem, ILogger logger)
        {
            _paymentSystem = paymentSystem;
            _logger = logger;
        }
        public virtual bool ProcessPayment(decimal amount)
        {
            if (amount <= 0)
            {
                _logger.Log($"Ошибка валидации: сумма платежа должна быть положительной (попытка оплаты {amount})");
                return false;
            }
            return _paymentSystem.ProcessPayment(amount);
        }
        public virtual string GetPaymentDetails()
        {
            return _paymentSystem.GetPaymentDetails();
        }
    }
    public class LoggingPaymentDecorator : PaymentDecorator
    {
        public LoggingPaymentDecorator(IPaymentSystem paymentSystem, ILogger logger)
            : base(paymentSystem, logger) { }

        public override bool ProcessPayment(decimal amount)
        {
            _logger.Log($"Начало обработки платежа: {amount}");

            if (!base.ProcessPayment(amount))
            {
                _logger.Log("Платеж не прошел базовую валидацию");
                return false;
            }
            bool result = _paymentSystem.ProcessPayment(amount);
            if (result)
            {
                _logger.Log($"Платеж успешно обработан: {_paymentSystem.GetPaymentDetails()}");
            }
            else
            {
                _logger.Log("Ошибка при обработке платежа");
            }
            return result;
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath = "payment_log.txt")
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
            File.AppendAllText(_filePath, logMessage);
            Console.WriteLine(logMessage.Trim());
        }
    }
    public class StripePayment : IPaymentSystem
    {
        private readonly string _apiKey;
        private readonly string _email;
        public StripePayment(string apiKey, string email)
        {
            _apiKey = apiKey;
            _email = email;
        }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Обращение к Stripe API: платеж {amount} для {_email}");
            return true;
        }
        public string GetPaymentDetails()
        {
            return $"Stripe Payment | API Key: {_apiKey.Mask(4)}, Email: {_email}";
        }
    }
    public class PayPalPayment : IPaymentSystem
    {
        private readonly string _token;
        private readonly string _currency;
        public PayPalPayment(string token, string currency)
        {
            _token = token;
            _currency = currency;
        }
        public bool ProcessPayment(decimal amount)
        {
            // Реальная логика PayPal API
            Console.WriteLine($"Обращение к PayPal API: {amount} {_currency}");
            return true;
        }
        public string GetPaymentDetails()
        {
            return $"PayPal Payment | Token: {_token.Mask(4)}, Currency: {_currency}";
        }
    }
    public class CryptoPayment : IPaymentSystem
    {
        private readonly string _walletAddress;
        private readonly string _cryptoType;
        public CryptoPayment(string walletAddress, string cryptoType)
        {
            _walletAddress = walletAddress;
            _cryptoType = cryptoType;
        }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Блокчейн транзакция: {amount} {_cryptoType} -> {_walletAddress.Mask(4)}");
            return true;
        }
        public string GetPaymentDetails()
        {
            return $"Crypto Payment | Wallet: {_walletAddress.Mask(4)}, Type: {_cryptoType}";
        }
    }
    public static class PaymentSystemFactory
    {
        public static IPaymentSystem CreatePaymentSystem(ILogger logger)
        {
            Console.WriteLine("Выберите платежную систему:");
            Console.WriteLine("1. Stripe");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Crypto");
            Console.Write("Ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());
            IPaymentSystem system = choice switch
            {
                1 => CreateStripeSystem(),
                2 => CreatePayPalSystem(),
                3 => CreateCryptoSystem(),
                _ => throw new ArgumentException("Неверный выбор платежной системы.")
            };
            return new LoggingPaymentDecorator(system, logger);
        }

        private static IPaymentSystem CreateStripeSystem()
        {
            Console.Write("Введите API Key Stripe: ");
            string apiKey = Console.ReadLine();
            Console.Write("Введите Email: ");
            string email = Console.ReadLine();
            return new StripePayment(apiKey, email);
        }
        private static IPaymentSystem CreatePayPalSystem()
        {
            Console.Write("Введите PayPal Token: ");
            string token = Console.ReadLine();
            Console.Write("Введите валюту (USD/EUR): ");
            string currency = Console.ReadLine();
            return new PayPalPayment(token, currency);
        }
        private static IPaymentSystem CreateCryptoSystem()
        {
            Console.Write("Введите адрес кошелька: ");
            string wallet = Console.ReadLine();
            Console.Write("Введите тип криптовалюты (BTC/ETH): ");
            string cryptoType = Console.ReadLine();
            return new CryptoPayment(wallet, cryptoType);
        }
    }
    public static class StringExtensions
    {
        public static string Mask(this string value, int showLastChars)
        {
            if (string.IsNullOrEmpty(value) || value.Length <= showLastChars)
                return value;

            return new string('*', value.Length - showLastChars) + value.Substring(value.Length - showLastChars);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Cистема обработки платежей");
            ILogger logger = new FileLogger();
            logger.Log("Запуск платежной системы");
            try
            {
                IPaymentSystem paymentSystem = PaymentSystemFactory.CreatePaymentSystem(logger);

                Console.Write("Введите сумму платежа: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                bool isSuccess = paymentSystem.ProcessPayment(amount);
                if (isSuccess)
                {
                    Console.WriteLine(" Платеж успешно обработан!");
                    Console.WriteLine(paymentSystem.GetPaymentDetails());
                }
                else
                {
                    Console.WriteLine(" Ошибка при обработке платежа.");
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Критическая ошибка: {ex.Message}");
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nЛоги сохранены в payment_log.txt");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
