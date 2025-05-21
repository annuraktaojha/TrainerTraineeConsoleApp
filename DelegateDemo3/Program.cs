using System.Diagnostics;

namespace DelegateDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Account account1= new Account();
            

           
          //  Console.WriteLine($"Account Balance: {account1.Balance}");

            account1.notifyDelegate += NotificationService.SendSMS;
            account1.notifyDelegate += NotificationService.SendEmail;
            account1.notifyDelegate += NotificationService.WhatsApp;
           // account1.notifyDelegate($"Your account has been credited with 1000000");
            account1.Deposit(1000);

            account1.Withdraw(500);
            //account1.notifyDelegate += NotificationService.SendSMS;
        }
    }

    public delegate void NotifyDelegate(string sms); // step1
    class Account // SRP (Single Responsibility Principle) // OCP (Open Close Principle)
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public double Balance { get; private set; }

        public event NotifyDelegate notifyDelegate; //= new NotifyDelegate(NotificationService.SendSMS); // step2
        public bool IsNotificationEnabled { get; set; }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                if (notifyDelegate != null)
                {
                    notifyDelegate($"Your account has been credited with {amount}. Your current balance is {Balance}");
                }
            }

          

            // w
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;

                if (notifyDelegate != null)
                {
                    notifyDelegate($"Your account has been debited with {amount}. Your current balance is {Balance}");
                }

            }
           
          
        }
    }

    public class NotificationService
    {
        public static void SendEmail(string msg)
        {
            Console.WriteLine($"Email : {msg}");
        }
        public static void SendSMS(string msg)
        {
            // write code to send SMS
            Console.WriteLine($"SMS :{msg} ");
        }

        public static void WhatsApp(string msg)
        {
            // write code to send WhatsApp
            Console.WriteLine($"WhatsApp :{msg} ");
        }
    }
}
