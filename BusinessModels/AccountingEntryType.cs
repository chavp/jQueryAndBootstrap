using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class AccountingEntryType : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; set; }

        protected AccountingEntryType() { }

        public AccountingEntryType(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Please require Name");

            Name = name;
        }
    }
}
