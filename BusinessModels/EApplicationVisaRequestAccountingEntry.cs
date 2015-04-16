using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class EApplicationVisaRequestAccountingEntry
        : Entity
    {
        public virtual Receipt Receipt { get; protected set; }
        public virtual EApplicationVisa EApplicationVisa { get; protected set; }
        public virtual AccountingEntry AccountingEntry { get; protected set; }

        protected EApplicationVisaRequestAccountingEntry() { }

        public EApplicationVisaRequestAccountingEntry(
            AccountingEntry accountingEntry, EApplicationVisa eApplicationVisa, Receipt receipt)
        {
            if (accountingEntry == null)
                throw new ArgumentNullException("Please require AccountingEntry");

            if (eApplicationVisa == null) 
                throw new ArgumentNullException("Please require EApplicationVisa");

            if (receipt == null)
                throw new ArgumentNullException("Please require Receipt");

            AccountingEntry = accountingEntry;
            EApplicationVisa = eApplicationVisa;
            Receipt = receipt;
        }
    }
}
