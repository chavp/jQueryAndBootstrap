using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class EApplicationVisaStatus
        : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Display { get; set; }

        protected EApplicationVisaStatus() { }

        public EApplicationVisaStatus(string name)
            : this(name, name) { }

        public EApplicationVisaStatus(string name, string display)
        {
            Name = name;
            Display = display;
        }
    }
}
