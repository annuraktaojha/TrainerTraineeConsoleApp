using System.Xml.Linq;

namespace LinqtoXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
          var xml = XDocument.Load("XMLFile1.xml");

            var titiles = from title in xml.Descendants("title")
                          select title.Value;

            var books = from book in xml.Descendants("book")
                        where double.Parse(book.Element("price").Value) <= 5
                        select new
                        {
                            Title = book.Element("title").Value,
                            Price = book.Element("price").Value,
                            Author = book.Element("author").Value
                        };// book.Element("title").Value;

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Price);
                Console.WriteLine(book.Author);


            }
        }
    }
}
