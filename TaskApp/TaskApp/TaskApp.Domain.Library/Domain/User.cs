﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Domain
{
    public partial class User
    {
        public bool validateUser()
        {
            return this.username != null && this.password != null;
        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public User() { }
        
       

    }
}