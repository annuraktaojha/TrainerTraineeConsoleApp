using BookHub.Core.Entities;
using BookHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core
{
    // Example BookService class 
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public bool AddBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || book.Price < 0)
                return false;
            _bookRepository.Add(book);
            return true;
        }

        public bool UpdateBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || book.Price < 0)
                return false;
            _bookRepository.Update(book);
            return true;
        }

        public bool Delete(int Id)
        {
           _bookRepository.Delete(Id);
            return true;
        }

        public Book GetBookByID(int Id)
        {
            
            return _bookRepository.GetBookByID(Id);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
        // Other methods... 
    }

}
