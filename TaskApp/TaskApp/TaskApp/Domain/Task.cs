using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Domain
{
    public partial class Task
    {
        public bool validateTask()
        {
            return this.name != null;
        }

    }
}