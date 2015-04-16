using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class AccountingEntry : Entity
    {
        public virtual Account Account { get; protected set; }
        public virtual decimal AmountUSD { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Currency Currency { get; set; }

        public virtual DateTime BookedUTC { get; protected set; }

        protected AccountingEntry() { }

        public AccountingEntry(Account account,
            decimal amountUSD, decimal amount, Currency currency)
        {
            Account = account;
            AmountUSD = amountUSD;
            Amount = amount;
            Currency = currency;

            BookedUTC = DateTime.UtcNow;
        }
    }
}
