using Moq;

namespace SimpleCalcLib.TestProject
{

    //public class MockResultLogger : IResultlogger
    //{
    //    public void SaveResult(int input1, int input2, int result)
    //    {
    //        // Mock implementation
    //    }
    //}

    [TestClass]
    public sealed class CalculatorTest
    {

        Calculator target = null;
        Moq.Mock<IResultlogger> mockLogger = new Moq.Mock<IResultlogger>();
        [TestInitialize]

        public void TestInit()
        {
            // will 

            

            mockLogger.Setup(ml => ml.SaveResult(1, 1, 1));
            target = new Calculator(mockLogger.Object);

        }

        public void TestClean()
        {
            target = null;
        }
        public void SumTest_WithValidInput_ShouldReturnValidResult()//Test Case
        {
            //AAA

            //A-Arrange
           

            int input1= 1;
            int input2= 2;

            int expected= 3;

            // Act
            int actual= target.Sum(input1, input2);
            //A=Assert
            Assert.AreEqual(expected, actual);


        }
        [TestMethod]
        [ExpectedException(typeof(NegativeInputException))]
        [DataRow(-1, -2)]
        [DataRow(1, -1)]
        [DataRow(-2, 2)]

        public void SumTest_WithAllNegativeInput_ThrowsException(int a, int b)
        {
            
            int actual = target.Sum(a,b);
        }

        [TestMethod]
        [ExpectedException(typeof(ZeroInputException))]
        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(0, 2)]
        public void SumTest_ZeroInput_ThrowsException(int a, int b) 
        {
          //  Calculator   calculator = new Calculator();

            int actual = target.Sum(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(OddInputException))]
        [DataRow(3, 5)]
        [DataRow(2, 5)]
        [DataRow(3,2)]
        public void SumTest_OddInput_ThrowsException(int a, int b)
        {
            int actual= target.Sum(a,b);
        }

        public void SumTest_SaveResult_ShouldCallSaveresultMethod()
        {
            target.Sum(2, 4);
            mockLogger.Verify(mockLogger => mockLogger.SaveResult(1,2,3), Times.Once());
        }
       
            

    }

    
}
