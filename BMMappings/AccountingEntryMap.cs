using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class AccountingEntryMap
        : EntityMap<AccountingEntry>
    {
        public AccountingEntryMap()
            : base("TRN_ACC_ACCOUNTING_ENTRY")
        {
            Table("TRN_ACC_ACCOUNTING_ENTRY");

            Map(x => x.AmountUSD, "AMOUNT_USD");
            Map(x => x.Amount, "AMOUNT");
            Map(x => x.BookedUTC, "BOOKED_DATE_UTC").CustomSqlType("DATE").Not.Nullable();

            References(x => x.Account, "TRN_ACC_ACCOUNT_ID").Not.Nullable();
            References(x => x.Currency, "TRN_ACC_CURRENCY_ID").Not.Nullable();
            
            MapVersion();
        }
    }
}
