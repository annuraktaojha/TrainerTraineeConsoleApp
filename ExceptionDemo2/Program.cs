
namespace ExceptionsDemo2
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    public class Program
    {
        public static void Main(string[] args)

        {
            Console.WriteLine("");
        }
    }
    public class Account
    {
        public int AccNo { get; set; }
        public int CurrentBalance { get; set; }
        public int MinimumBalance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="amount"></param>
        /// <exception cref="InvalidAccountNumberException"></exception>
        public void Deposit(int accNo, int amount)
        {
            // valid accNo 

            if (this.AccNo != accNo)
            {
                throw new InvalidAccountNumberException("Account number not found");
            }


            // valid amount (amount > 0)

            if (this.CurrentBalance != amount) 
            {
                throw new InvalidAccountNumberException("Amount not found");
            }
            

            // should be active acc
            if (!this.IsActive)
            {
                throw new InvalidAccountNumberException("Account is not active");
            }
            this.CurrentBalance = amount;
            // else should throw exp


        }

        public void Withdraw(int accNo, int amount, int pin)
        {
            // valid accno
            if (this.AccNo != accNo)
            {
                throw new InvalidAccountNumberException("Account number not found");
            }
            // valid amount (> 0)

            if (this.CurrentBalance != amount)
            {
                throw new InvalidAccountNumberException("Amount not found");
            }
            // sufficcient balance
            if (this.CurrentBalance < amount)
            {
                throw new InvalidAccountNumberException("Insufficient balance");
            }
            // must maintain min balance 5000-1000 <= 1000

            if (this.CurrentBalance - amount < this.MinimumBalance)
            {
                throw new InvalidAccountNumberException("Minimum balance should be maintained");
            }
            // must be active account
            if (!this.IsActive)
            {
                throw new InvalidAccountNumberException("Account is not active");
            }
            // valid pin

            if (this.Pin != pin)
            {
                throw new InvalidAccountNumberException("Invalid pin");
            }

            this.CurrentBalance -= amount;
            // else throw exp

        }

        public void Transfer(int fromAccNo, int toAccNo, int amount, int fromAccPin)
        {
            // all deposit business rules

            if (this.AccNo != fromAccNo)
            {
                throw new InvalidAccountNumberException("Account number not found");
            }
            // all withdrawal business rules

            if (this.CurrentBalance != amount)
            {
                throw new InvalidAccountNumberException("Amount not found");
            }

            if (this.CurrentBalance < amount)
            {
                throw new InvalidAccountNumberException("Insufficient balance");
            }

            if (this.CurrentBalance - amount < this.MinimumBalance)
            {
                throw new InvalidAccountNumberException("Minimum balance should be maintained");
            }

            if (!this.IsActive)
            {
                throw new InvalidAccountNumberException("Account is not active");
            }

            if (this.Pin != fromAccPin)
            {
                throw new InvalidAccountNumberException("Invalid pin");
            }



            // else throw exp

        }

        public void Close(int accNo, int pin)
        {
            // valid accno
            if (this.AccNo != accNo)
            {
                throw new InvalidAccountNumberException("Account number not found");
            }
            // valid pin
            if (this.Pin != pin)
            {
                throw new InvalidAccountNumberException("Invalid pin");
            }
            // balance must be zero

            if (this.CurrentBalance != 0)
            {
                throw new InvalidAccountNumberException("Balance should be zero");
            }
            // should be active account

            if (!this.IsActive)
            {
                throw new InvalidAccountNumberException("Account is not active");
            }

            this.IsActive = false;
        }

    }

    [Serializable]
    internal class InvalidAccountNumberException : ApplicationException
    {
        public InvalidAccountNumberException()
        {
        }

        public InvalidAccountNumberException(string? message) : base(message)
        {
        }

        public InvalidAccountNumberException(string? message, ApplicationException? innerException) : base(message, innerException)
        {
        }
    }
}
