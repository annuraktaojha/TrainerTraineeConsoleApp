using System.Configuration;

namespace POSApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

          //  TaxCalculatorFactory taxCalculatorFactory = new TaxCalculatorFactory();
           // ITaxCalculatorStatergy taxCalculatorStatergy = taxCalculatorFactory.Create();
            ITaxCalculatorStatergy taxCalculatorStatergy = TaxCalculatorFactory.Instance.Create();
            //
            Console.WriteLine($"factory1 {TaxCalculatorFactory.Instance.GetHashCode()}");
            ITaxCalculatorStatergy taxCalculatorStatergy1 = TaxCalculatorFactory.Instance.Create();

            Console.WriteLine($"factory2 {TaxCalculatorFactory.Instance.GetHashCode()}");
            BillingSystem billingSystem = new BillingSystem(taxCalculatorStatergy);
            billingSystem.GenerateBill();
            // Initialize BillingSystem and perform operations
            //BillingSystem billingSystem = new BillingSystem(new KATaxCalculatorConcreteStatergy());
            //billingSystem.GenerateBill();
        }
    }

    class TaxCalculatorFactory
    {
        private TaxCalculatorFactory()
        {
            
        }
        //private static TaxCalculatorFactory _instance=null;
        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();

        //public static TaxCalculatorFactory GetInstance()
        //{
        //    if(_instance == null)
        //    {
        //        _instance = new TaxCalculatorFactory();
        //    }
        //    return _instance;
        //}
        public virtual ITaxCalculatorStatergy Create()
        {
            // read the config file
            string calcClass= ConfigurationManager.AppSettings["CALC"];

            // reflection
            Type type = Type.GetType(calcClass);
            ITaxCalculatorStatergy taxCalculatorStatergy =(ITaxCalculatorStatergy) Activator.CreateInstance(type);
            return taxCalculatorStatergy;

        }
    }
    class BillingSystem
    {
        double amount = 1000;
        //TaxCalculator taxCalculator = new TaxCalculator();

        private ITaxCalculatorStatergy taxCalculatorStatergy;

        public BillingSystem(ITaxCalculatorStatergy taxCalculatorStatergy)
        {
            this.taxCalculatorStatergy = taxCalculatorStatergy;
        }

        public double GenerateBill()
        {
            return taxCalculatorStatergy.CalculateTax(amount);
        }

        // Other methods for scanning products, applying discounts, coupons, tax, generating bill, and payment
    }

    public class UStaxCalculator
    {
        public float CalculateTax(double amount)
        {
            double tax = 385.09F;
            Console.WriteLine(" Using US Calc Tax: " + tax);
            return (float)(amount * tax);
        }
    }

    public class UstaxCalaclatorAdaptor : ITaxCalculatorStatergy
    {
        UStaxCalculator usTaxCalculator = new UStaxCalculator();
        public double CalculateTax(double amount)
        {
            return usTaxCalculator.CalculateTax(amount);
        }
    }
    public interface ITaxCalculatorStatergy
    {
        double CalculateTax(double amount);
    }
   
    public class KATaxCalculatorConcreteStatergy : ITaxCalculatorStatergy
    {
        public  double CalculateTax(double amount)
        {
            int cgst = 50;
            int sgst = 50;
            int cess = 10;
            int etax = 5;
            double tax = (cgst + sgst + cess + etax) / 100.0;
            Console.WriteLine(" Using KA Calc Tax: " + tax);
            return amount * tax;
        }
    }

    public class TNTaxCalculatorConcreteStatergy : ITaxCalculatorStatergy
    {
        public double CalculateTax(double amount)
        {
            int cgst = 50;
            int sgst = 50;
            int Acess = 10;
            int Btax = 5;
            double tax = (cgst + sgst + Acess + Btax) / 100.0;
            Console.WriteLine(" Using TN Calc Tax: " + tax);
            return amount * tax;
        }
    }

    public class MHTaxCalculatorConcreteStatergy : ITaxCalculatorStatergy
    {
        public double CalculateTax(double amount)
        {
            int cgst = 50;
            int sgst = 50;
            int cess = 10;
            int etax = 5;
            double tax = (cgst + sgst + cess + etax) / 100.0;
            Console.WriteLine(" Using MH Calc Tax: " + tax);
            return amount * tax;
        }
    }

}
