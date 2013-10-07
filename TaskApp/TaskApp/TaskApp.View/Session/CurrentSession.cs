using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.View.Session
{
    public class CurrentSession : ISession
    {
        private User user;

        public User getCurrentUser()
        {
            return user;
        }
        public void setCurrentUser(User user)
        {
            this.user = user;
        }

    }
}