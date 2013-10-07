using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Domain;

namespace TaskApp.View.Session
{
    public interface ISession
    {
        User getCurrentUser();
        void setCurrentUser(User user);
    }
}
