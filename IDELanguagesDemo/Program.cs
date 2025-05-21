namespace IDELanguagesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE iDE = new IDE();
          LangCSharp  CS = new LangCSharp();
            iDE.Languages.Add(CS);
            //iDE.CS = CS;
            LangJava Java = new LangJava();
            iDE.Languages.Add(Java);
           // iDE.Java = Java;
            LangC   C = new LangC();
            iDE.Languages.Add(C);

            LangTypeScript TypeScript = new LangTypeScript();
            iDE.Languages.Add(TypeScript);
            // iDE.C = C;


            iDE.DoWork(); 
        }
    }

    class IDE // OCP(Open Close Principle) - Open for Extension, Close for Modification
    {
        //public  LangCSharp CS { get; set; }

        //public  LangJava Java { get; set; }

        //public  LangC C { get; set; }

        //public IDE()
        //{
        //    CS = new LangCSharp();
        //    Java = new LangJava();
        //    C = new LangC();
        //}

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void DoWork()
        {

            foreach (var language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.getUnit());
                Console.WriteLine(language.getParadigm());
            }
            //CS
            //Console.WriteLine(CS.GetName());
            //Console.WriteLine(CS.getUnit());
            //Console.WriteLine(CS.getParadigm());

            //Console.WriteLine(Java.GetName());
            //Console.WriteLine(Java.getUnit());
            //Console.WriteLine(Java.getParadigm());

            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.getUnit());
            //Console.WriteLine(C.getParadigm());
        }
    }

    interface ILanguage
    {
        string GetName();
        string getUnit();
        string getParadigm();
    }

    abstract class OOLanguage : ILanguage
    {
        public abstract string GetName();
       
        public  string getUnit()
        {
            return "Classes";
        }
        public  string getParadigm()
        {
              return "Object Oriented";
        }
    }
    abstract class ProcedureOLanguage : ILanguage
    {
        public abstract string GetName();

        public string getUnit()
        {
            return "Functions";
        }

        public string getParadigm()
        {
            return "Procedure Oriented";
        }
    }
    class LangTypeScript : OOLanguage
    {
        public override string GetName()
        {
            return "TypeScript";
        }
       
    }
    class LangC : ProcedureOLanguage
    {
        public override string GetName()
        {
            return "C Language";
        }

       
    }

    class LangCSharp : OOLanguage
    {
        public override string GetName()
        { 
            return "C Sharp"; 
        }

        //public string getUnit()
        //{
        //    return "Classes";
        //}

        //public string getParadigm() 
        //{
        //    return "Object Oriented";
        //}
    }
    class LangJava : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }

        //public string getUnit()
        //{
        //    return "Classes";
        //}

        //public string getParadigm()
        //{
        //    return "Object Oriented";
        //}
    }

}
