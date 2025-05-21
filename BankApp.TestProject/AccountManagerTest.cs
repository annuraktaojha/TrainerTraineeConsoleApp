using System.Security;
using System.Security.Principal;
using Moq;
namespace BankApp.TestProject
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Open_ShouldSetOpeningDateAndActivateAccount()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };

            // Act
            account.Open();

            // Assert
            Assert.IsNotNull(account.OpeningDate);
            Assert.IsTrue(account.IsActive);
            Assert.IsNull(account.ClosedDate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Open_WhenAlreadyOpened_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();

            // Act
            account.Open(); // Should throw exception
        }

        [TestMethod]
        public void Close_ShouldSetClosingDateAndDeactivateAccount()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();

            // Act
            account.Close();

            // Assert
            Assert.IsNotNull(account.ClosedDate);
            Assert.IsFalse(account.IsActive);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Close_WhenNotOpened_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User",            };

            // Act
            account.Close(); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Close_WhenAlreadyClosed_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Close();

            // Act
            account.Close(); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Close_WithPositiveBalance_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Deposit(100);

            // Act
            account.Close(); // Should throw exception
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();

            // Act
            account.Deposit(100);

            // Assert
            Assert.AreEqual(100, account.CurrentBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Deposit_WhenAccountNotActive_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };

            // Act
            account.Deposit(100); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Deposit_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();

            // Act
            account.Deposit(-100); // Should throw exception
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Deposit(100);

            // Act
            account.Withdraw(50, 1234);

            // Assert
            Assert.AreEqual(50, account.CurrentBalance);    
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_WhenAccountNotActive_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };

            // Act
            account.Withdraw(50, 1234); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Withdraw_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Deposit(100);

            // Act
            account.Withdraw(-50, 1234); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_WithInsufficientBalance_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Deposit(100);

            // Act
            account.Withdraw(150, 1234); // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(SecurityException))]
        public void Withdraw_WithIncorrectPin_ShouldThrowException()
        {
            // Arrange
            var account = new Account { AccNo = 1000, Name = "Test User", PinNumber = 1234 };
            account.Open();
            account.Deposit(100);

            // Act
            account.Withdraw(50, 4321); // Should throw exception
        }
    }

    [TestClass]
    public class AccountManagerTests
    {
        AccountManager manager;
        Moq.Mock<ITransactionlogger> mockLogger = new Moq.Mock<ITransactionlogger>();
        [TestInitialize]
        public void TestInit()
        {
            // will 

            mockLogger.Setup(ml => ml.SaveTransactions("transaction saved"));
            manager = new AccountManager(mockLogger.Object);

        }

        public void TestClean()
        {
            manager = null;
        }

        [TestMethod]
        public void CreateAccount_ShouldAddNewAccountToList()
        {
            // Arrange
            //var manager = new AccountManager(logger);

            // Act
            var account = manager.AccountOpen("Test User", 1234);

            // Assert
            Assert.AreEqual(1000, account.AccNo);  // First account gets this number
            Assert.AreEqual("Test User", account.Name);
            Assert.IsTrue(account.IsActive);
            Assert.IsNotNull(account.OpeningDate);

            var accounts = manager.GetAllAccounts();
            Assert.AreEqual(1, accounts.Count);
        }

        [TestMethod]
        public void CreateAccount_MultipleTimes_ShouldAssignUniqueAccountNumbers()
        {
            // Arrange
            //var manager = new AccountManager(logger);

            // Act
            var account1 = manager.AccountOpen("User 1", 1111);
            var account2 = manager.AccountOpen("User 2", 2222);
            var account3 = manager.AccountOpen("User 3", 3333);

            // Assert
            Assert.AreEqual(1000, account1.AccNo);
            Assert.AreEqual(1001, account2.AccNo);
            Assert.AreEqual(1002, account3.AccNo);

            var accounts = manager.GetAllAccounts();
            Assert.AreEqual(3, accounts.Count);
        }

        [TestMethod]
        public void CloseAccount_ShouldDeactivateAccount()
        {
            // Arrange
            //var manager = new AccountManager(logger);
            var account = manager.AccountOpen("Test User", 1234);

            // Act
            manager.AccountClose(account.AccNo);

            // Assert
            var accounts = manager.GetAllAccounts();
            Assert.IsFalse(accounts[0].IsActive);
            Assert.IsNotNull(accounts[0].ClosedDate);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CloseAccount_WithNonExistentAccount_ShouldThrowException()
        {
            // Arrange
            //var manager = new AccountManager(logger);

            // Act
            manager.AccountClose(9999); // Should throw exception
        }

        [TestMethod]
        public void Deposit_ShouldIncreaseAccountBalance()
        {
            // Arrange
           // var manager = new AccountManager(logger);
            var account = manager.AccountOpen("Test User", 1234);

            // Act
            manager.Deposit(account.AccNo, 100);

            // Assert
            var accounts = manager.GetAllAccounts();
            Assert.AreEqual(100, accounts[0].CurrentBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Deposit_ToNonExistentAccount_ShouldThrowException()
        {
            // Arrange
            //var manager = new AccountManager(logger);

            // Act
            manager.Deposit(9999, 100); // Should throw exception
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseAccountBalance()
        {
            // Arrange
           // var manager = new AccountManager(logger);
            var account = manager.AccountOpen("Test User", 1234);
            manager.Deposit(account.AccNo, 100);

            // Act
            manager.Withdraw(account.AccNo, 50, 1234);

            // Assert
            var accounts = manager.GetAllAccounts();
            Assert.AreEqual(50, accounts[0].CurrentBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Withdraw_FromNonExistentAccount_ShouldThrowException()
        {
            // Arrange
          //  var manager = new AccountManager(logger);

            // Act
            manager.Withdraw(9999, 50, 1234); // Should throw exception
        }

        [TestMethod]
        public void Transfer_ShouldMoveMoneyBetweenAccounts()
        {
            // Arrange
           // var manager = new AccountManager(logger);
            var account1 = manager.AccountOpen("User 1", 1111);
            var account2 = manager.AccountOpen("User 2", 2222);
            manager.Deposit(account1.AccNo, 100);

            // Act
            manager.Transfer(account1.AccNo, account2.AccNo, 50, 1111);

            // Assert
            var accounts = manager.GetAllAccounts();
            Assert.AreEqual(50, accounts[0].CurrentBalance);
            Assert.AreEqual(50, accounts[1].CurrentBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Transfer_BetweenInactiveAccounts_ShouldThrowException()
        {
            // Arrange
            //var manager = new AccountManager(logger);
            var account1 = manager.AccountOpen("User 1", 1111);
            var account2 = manager.AccountOpen("User 2", 2222);   
            manager.Deposit(account1.AccNo, 100);
            manager.AccountClose(account2.AccNo);

            // Act
            manager.Transfer(account1.AccNo, account2.AccNo, 50, 1111); // Should throw exception
        }

        [TestMethod]
        public void SaveTransactionLog_ShouldCallSaveresultMethod()
        {
            manager.AccountOpen("User 1", 1111);
            mockLogger.Verify(mockLogger => mockLogger.SaveTransactions($"Account created:  for User 1"), Times.Once());
        }
        
    }
}
