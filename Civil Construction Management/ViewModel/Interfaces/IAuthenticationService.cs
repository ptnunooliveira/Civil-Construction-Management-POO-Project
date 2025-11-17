using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civil_Construction_Management.ViewModel.Interfaces
{
    public interface IAuthenticationService
    {

        bool UserExists(string username, string password);
    }
}
