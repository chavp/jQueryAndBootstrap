using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    /// <summary>
    /// http://www.pattanakit.net/
    /// </summary>
    public class Account 
        : Entity
    {
        public virtual Member Owner { get; protected set; }
        public virtual AccountingEntryType EntryType { get; protected set; }
        public virtual IList<AccountingEntry> AccountingEntries { get; set; }

        protected Account() { }

        public Account(Member customer, AccountingEntryType entryType)
        {
            if (customer == null) throw new ArgumentNullException("Please require Customer");
            if (entryType == null) throw new ArgumentNullException("Please require EntryType");

            Owner = customer;
            EntryType = entryType;
            AccountingEntries = new List<AccountingEntry>();
        }
    }
}
