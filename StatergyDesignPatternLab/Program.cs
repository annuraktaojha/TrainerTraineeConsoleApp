using System.Configuration;

namespace StatergyDesignPatternLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //IPaymentStartegy paymentStartegy = PaymentGatewayFactory.Instance.Create();
            PaymentContext processor = new PaymentContext();

            // choose payment method at runtime

            Console.WriteLine("Enter the payment method: 1 for CreditCardPayment, 2 for PayPalPayment, 3 for BitcoinPayment");
            int paymentMethod = int.Parse(Console.ReadLine());

            switch (paymentMethod)
            {
                case 1:
                    processor.SetPaymentStartegy(new CreditCardPayment());
                    break;
                case 2:
                    processor.SetPaymentStartegy(new PayPalPayment());
                    break;
                case 3:
                    processor.SetPaymentStartegy(new BitcoinPayment());
                    break;
                default:
                    break;
            }
            // process the payment
            processor.ProcessPayment(1000);
            // paymentContext.SetPaymentStartegy(paymentStartegy);
            // paymentContext.ProcessPayment(1000);

        }
    }

    //public class PaymentGatewayFactory
    //{
    //    private PaymentGatewayFactory()
    //    {
    //    }

    //    public static readonly PaymentGatewayFactory Instance = new PaymentGatewayFactory();

    //    public virtual IPaymentStartegy Create()
    //    {
    //        // read the config file
    //        string PaymentG = ConfigurationManager.AppSettings["PAYG"];

    //        // reflection
    //        Type type = Type.GetType(PaymentG);
    //        IPaymentStartegy  paymentStartegy = (IPaymentStartegy)Activator.CreateInstance(type);
    //        return paymentStartegy;

    //    }
    //}

    public class PaymentContext
    {
        private IPaymentStartegy _paymentStartegy;
        public void SetPaymentStartegy(IPaymentStartegy paymentStartegy)
        {
            _paymentStartegy = paymentStartegy;
        }

        public void ProcessPayment(decimal amount)
        {
             _paymentStartegy.Pay(amount);
            Console.WriteLine("Payment processed successfully");
        }
    }

    public  interface IPaymentStartegy
    {
        void Pay(decimal amount);
    }

    //reditCardPayment, PayPalPayment, and BitcoinPayment.

    public class CreditCardPayment : IPaymentStartegy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"CreditCardPayment of {amount} is successful");
        }
    }

    public class PayPalPayment : IPaymentStartegy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"PayPalPayment of {amount} is successful");
        }
    }

    public class BitcoinPayment : IPaymentStartegy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"BitcoinPayment of {amount} is successful");
        }
    }


}
