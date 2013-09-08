using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskApp.Domain
{
    public partial class Estimate
    {
        public bool validateEstimate()
        {
            return this.id != null
                && this.time != null
                && this.type != null;
        }
    }
}