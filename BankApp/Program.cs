using System.Data;
using System.Net.NetworkInformation;
using System.Security;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankApp
{
    public class Program
    {
        private static ITransactionlogger _transactionlogger = new FileLogger();
        static AccountManager accountManager = new AccountManager(_transactionlogger);
        public static void Main(string[] args)
        {
            bool exit = false;

            Console.WriteLine("Welcome to Bank Account Management System");

            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        CloseAccount();
                        break;
                    case "3":
                        DepositMoney();
                        break;
                    case "4":
                        WithdrawMoney();
                        break;
                    case "5":
                        TransferMoney();
                        break;
                    case "6":
                        DisplayAccounts();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Thank you for using Bank Account Management System");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("1. Create new account");
            Console.WriteLine("2. Close existing account");
            Console.WriteLine("3. Deposit money");
            Console.WriteLine("4. Withdraw money");
            Console.WriteLine("5. Transfer money");
            Console.WriteLine("6. Display all accounts");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }

        public static void CreateAccount()
        {
            Console.WriteLine("\n==== CREATE ACCOUNT ====");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter PIN: ");
            int pin = int.Parse(Console.ReadLine());

            try
            {
                var Account = accountManager.AccountOpen(name, pin);
                Console.WriteLine($"Account created successfully! Account number: {Account.AccNo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void CloseAccount()
        {
            Console.WriteLine("\n==== CLOSE ACCOUNT ====");

            Console.Write("Enter account number: ");
            if (int.TryParse(Console.ReadLine(), out int accNo))
            {
                try
                {
                    accountManager.AccountClose(accNo);
                    Console.WriteLine("Account closed successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number format.");
            }
        }

        static void DepositMoney()
        {
            Console.WriteLine("\n==== DEPOSIT MONEY ====");

            Console.Write("Enter account number: ");
            if (int.TryParse(Console.ReadLine(), out int accNo))
            {
                Console.Write("Enter amount to deposit: ");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    try
                    {
                        accountManager.Deposit(accNo, amount);
                        Console.WriteLine("Deposit successful!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number format.");
            }
        }

        static void WithdrawMoney()
        {
            Console.WriteLine("\n==== WITHDRAW MONEY ====");

            Console.Write("Enter account number: ");
            if (int.TryParse(Console.ReadLine(), out int accNo))
            {
                Console.Write("Enter amount to withdraw: ");
                if (double.TryParse(Console.ReadLine(), out double amount))
                {
                    Console.Write("Enter PIN: ");
                    int pin = int.Parse(Console.ReadLine());

                    try
                    {
                        accountManager.Withdraw(accNo, amount, pin);
                        Console.WriteLine("Withdrawal successful!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number format.");
            }
        }

        static void TransferMoney()
        {
            Console.WriteLine("\n==== TRANSFER MONEY ====");

            Console.Write("Enter source account number: ");
            if (int.TryParse(Console.ReadLine(), out int fromAccNo))
            {
                Console.Write("Enter target account number: ");
                if (int.TryParse(Console.ReadLine(), out int toAccNo))
                {
                    Console.Write("Enter amount to transfer: ");
                    if (double.TryParse(Console.ReadLine(), out double amount))
                    {
                        Console.Write("Enter source account PIN: ");
                        int pin = int.Parse(Console.ReadLine());

                        try
                        {
                            accountManager.Transfer(fromAccNo, toAccNo, amount, pin);
                            Console.WriteLine("Transfer successful!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount format.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid target account number format.");
                }
            }
            else
            {
                Console.WriteLine("Invalid source account number format.");
            }
        }

        static void DisplayAccounts()
        {
            Console.WriteLine("\n==== ACCOUNTS ====");

            var accounts = accountManager.GetAllAccounts();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            foreach (var account in accounts)
            {
                Console.WriteLine($"Account: {account.AccNo}, Name: {account.Name}, Balance: {account.CurrentBalance:C}, Status: {(account.IsActive ? "Active" : "Closed")}");
                Console.WriteLine($"  Opened: {account.OpeningDate}");
                if (account.ClosedDate != null)
                {
                    Console.WriteLine($"  Closed: {account.ClosedDate}");
                }
                Console.WriteLine();
            }
        }
    }

    public class Account
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public double CurrentBalance { get; set; }
        public double MinimumBalance { get; set; }
        public int PinNumber { get; set; }
        public bool IsActive { get; set; }

        public DateTime? OpeningDate { get; set; }
        public DateTime ClosedDate { get; set; }


        // Method to open an account
        public void Open()
        {
            if (OpeningDate != null)
            {
                throw new InvalidOperationException("Account has already been opened.");
            }

            OpeningDate = DateTime.UtcNow;
            IsActive = true;
        }

        // Method to close an account
        public void Close()
        {
            if (OpeningDate == null)
            {
                throw new InvalidOperationException("Cannot close an account that hasn't been opened.");
            }

            if (ClosedDate != null)
            {
                throw new InvalidOperationException("Account has already been closed.");
            }

            if (CurrentBalance > 0)
            {
                throw new InvalidOperationException("Cannot close account with positive balance.");
            }

            ClosedDate = DateTime.Now;
            IsActive = false;
        }

        // Method to deposit money
        public void Deposit(double amount)
        {
            if (!IsActive || OpeningDate == null)
            {
                throw new InvalidOperationException("Cannot deposit to an inactive or unopened account.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }

            CurrentBalance += amount;
        }

        // Method to withdraw money
        public void Withdraw(double amount, int providedPin)
        {
            if (!IsActive || OpeningDate == null)
            {
                throw new InvalidOperationException("Cannot withdraw from an inactive or unopened account.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }

            if (CurrentBalance < amount)
            {
                throw new InvalidOperationException("Insufficient balance for withdrawal.");
            }

            if (PinNumber != providedPin)
            {
                throw new SecurityException("Incorrect PIN provided.");
            }

            CurrentBalance -= amount;
        }

    }
  
    // Custom exception for security-related issues
    class SecurityException : Exception
    {
        public SecurityException(string message) : base(message) { }
    }


    public interface ITransactionlogger
    {
        void SaveTransactions(string Details);

    }

    public class AccountManager 

    {

        private List<Account> accounts = new List<Account>();
        private ITransactionlogger logger;
        public AccountManager()
        {

        }

        public AccountManager(ITransactionlogger resultlogger)
        {
            this.logger = resultlogger;
        }
        public void AccountClose(int accNo)
        {
            var account = FindAccount(accNo);
            account.Close();
            logger.SaveTransactions($"Account closed: {account.AccNo}");
        }

        public Account AccountOpen(string name, int pin)
        {

            var newAccount = new Account
            {
                AccNo = accounts.Count > 0 ? accounts.Max(a => a.AccNo) + 1 : 1000,
                Name = name,
                PinNumber = pin,
                CurrentBalance = 0
                //OpeningDate = DateTime.UtcNow

            };

            newAccount.Open();
            accounts.Add(newAccount);

            logger.SaveTransactions($"Account created: {newAccount.AccNo} for {newAccount.Name}");
            return newAccount;
        }





        public void Deposit(int accNo, double amount)
        {
            var account = FindAccount(accNo);
            account.Deposit(amount);
            logger.SaveTransactions($"Deposit: {amount:C} to account {account.AccNo}, New balance: {account.CurrentBalance:C}");
        }

        public void Transfer(int fromAccNo, int toAccNo, double amount, int fromAccPin)
        {
            var fromAccount = FindAccount(fromAccNo);
            var toAccount = FindAccount(toAccNo);

            if (!fromAccount.IsActive || !toAccount.IsActive)
            {
                throw new InvalidOperationException("Both accounts must be active for transfer.");
            }

            // First withdraw from source account (this checks pin, balance, etc.)
            fromAccount.Withdraw(amount, fromAccPin);

            // Then deposit to target account
            toAccount.Deposit(amount);

            logger.SaveTransactions($"Transfer: {amount:C} from account {fromAccount.AccNo} to account {toAccount.AccNo}");
        }

        public void Withdraw(int accNo, double amount, int pin)
        {
            var account = FindAccount(accNo);
            account.Withdraw(amount, pin);
            logger.SaveTransactions($"Withdrawal: {amount:C} from account {account.AccNo}, New balance: {account.CurrentBalance:C}");
        }

        
        // Get all accounts (for display purposes)
        public List<Account> GetAllAccounts()
        {
            return new List<Account>(accounts);
        }
        // Helper method to find an account by account number
        private Account FindAccount(int accNo)
        {
            var account = accounts.FirstOrDefault(a => a.AccNo == accNo);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with number {accNo} not found.");
            }
            return account;
        }
    }
    public class FileLogger : ITransactionlogger
    {
        public void SaveTransactions(string transactionDetails)
        {
            File.WriteAllText("D:\\NETCORE\\transactions.txt", transactionDetails);

        }
    }
}





