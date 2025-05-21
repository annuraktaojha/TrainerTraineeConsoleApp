namespace DelgatesDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Greetings("Good Morning");

            Program obj = new Program();
            MyDelegate objDel2 = new MyDelegate(obj.Hello);// step2 : instantiation and initialization :  pass the address (method name) of the method to the delegate object
            objDel2 += Greetings; // subscription: subscribing another method to the delegate object
            objDel2 -= obj.Hello; // unsubscription: unsubscribing a method from the delegate object
            objDel2("Good afternoon");// step3: call the method using delegate object
            // indirect way of calling a method


            //// 1. Create a delegate object
            //MyDelegate objDel = new MyDelegate(Greetings);// step2 : instantiation and initialization :  pass the address (method name) of the method to the delegate object
            //objDel.Invoke("Hello");// step3: call the method using delegate object


            // Delegate objDel = new Delegate(Greetings);
        }

        public static void Greetings(string text)
        {
            Console.WriteLine($"Greetings: {text}");
        }

       public void Hello(string text)
        {
            Console.WriteLine($"Hello: {text}");
        }


    }
    // create delegate class by using keyword delegate and give the signature of the method that you want to point to
    delegate void MyDelegate(string text);// step1- delegate declaration tells compiler that this delegate can point to a method that takes a string as an argument and returns void
    //class MyDelegate : Delegate // can't inherit from sealed class
    //{

    //}
}
