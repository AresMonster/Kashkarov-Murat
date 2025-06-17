namespace _76_77_Pal
{
    internal class Program
    {
        public class Order
        {
            public string ProductName { get; set; }
            public bool IsProductAvailable { get; set; }
            public bool IsPaymentValid { get; set; }
            public bool IsDeliveryAddressValid { get; set; }
        }
        public abstract class OrderHandler
        {
            protected OrderHandler _nextHandler;

            public OrderHandler SetNext(OrderHandler handler)
            {
                _nextHandler = handler;
                return handler;
            }

            public virtual void Handle(Order order)
            {
                _nextHandler?.Handle(order);
            }
        }
        public class ProductAvailabilityHandler : OrderHandler
        {
            public override void Handle(Order order)
            {
                if (!order.IsProductAvailable)
                {
                    Console.WriteLine("Товар отсутствует. Заказ отменён.");
                    return;
                }
                Console.WriteLine("Товар есть в наличии.");
                base.Handle(order);
            }
        }
        public class PaymentValidationHandler : OrderHandler
        {
            public override void Handle(Order order)
            {
                if (!order.IsPaymentValid)
                {
                    Console.WriteLine("Платёж не прошёл. Заказ отменён.");
                    return;
                }
                Console.WriteLine("Платёж подтверждён.");
                base.Handle(order);
            }
        }
        public class DeliveryAddressHandler : OrderHandler
        {
            public override void Handle(Order order)
            {
                if (!order.IsDeliveryAddressValid)
                {
                    Console.WriteLine("Адрес доставки недействителен. Заказ отменён.");
                    return;
                }
                Console.WriteLine("Адрес доставки корректен. Заказ оформлен!");
            }
        }
        
        static void Main(string[] args)
        {
            var productCheck = new ProductAvailabilityHandler();
            var paymentCheck = new PaymentValidationHandler();
            var addressCheck = new DeliveryAddressHandler();

            productCheck
                .SetNext(paymentCheck)
                .SetNext(addressCheck);

            Console.WriteLine("=== Оформление заказа ===");
            Console.Write("Название товара: ");
            string productName = Console.ReadLine();
            Console.Write("Товар в наличии? (да/нет): ");
            bool isAvailable = !(Console.ReadLine().ToLower() != "да");
            Console.Write("Платёж успешен? (да/нет): ");
            bool isPaymentValid = Console.ReadLine().ToLower() == "да";
            Console.Write("Адрес доставки корректен? (да/нет): ");
            bool isAddressValid = Console.ReadLine().ToLower() == "да";

            var order = new Order
            {
                ProductName = productName,
                IsProductAvailable = isAvailable,
                IsPaymentValid = isPaymentValid,
                IsDeliveryAddressValid = isAddressValid
            };

            Console.WriteLine("\n=== Проверка заказа ===");
            productCheck.Handle(order);
        }
        
    }
}
