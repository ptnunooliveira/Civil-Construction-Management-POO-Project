using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}
