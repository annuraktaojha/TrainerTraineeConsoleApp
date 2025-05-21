using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // List<string> list = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            XDocument doc = XDocument.Load("XMLFile1.xml");
            // get all short words

          //  var shortWords = list.Where(word => word.Length < 4).Select(word => word);

            // Linq to Objects

            //var shortWords2 = from word in list
            //                  where word.Length <=3
            //                  select word;

            // Linq to XML

            var shortWordsxml = from word in doc.Descendants("word")
                              where word.Value.Length <= 3
                              select word;

            foreach (var word in shortWordsxml)
            {
                Console.WriteLine(word);
            }
        }
    }
}
