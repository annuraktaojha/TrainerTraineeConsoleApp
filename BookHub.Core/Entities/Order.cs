using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core.Entities
{
    public class Order
    {
        int OrderId { get; set; }

        public List<Book> Books { get; set; }
        public int BookId { get; set; }
    }
}
