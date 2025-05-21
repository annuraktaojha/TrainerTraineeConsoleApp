using BookHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHub.Core.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
    }
}
