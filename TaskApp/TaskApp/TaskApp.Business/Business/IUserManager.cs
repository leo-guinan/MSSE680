using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Business
{
    public interface IUserManager
    {
        Boolean addUser(String username, String password);
        Boolean login(String username, String password);
    }
}
