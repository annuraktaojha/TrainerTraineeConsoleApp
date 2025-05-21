using BookHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);

        void Update(Book book);

        void Delete(int id);

        Book GetBookByID(int id);

        List<Book> GetAll();
    }
}
