using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class AccountMap
        : EntityMap<Account>
    {
        public AccountMap()
            : base("TRN_ACC_ACCOUNT")
        {
            Table("TRN_ACC_ACCOUNT");

            References(x => x.Owner, "TRN_AUT_MEMBER_ID").Not.Nullable().UniqueKey("KEY_CUST_ACC");
            References(x => x.EntryType, "TRN_ACC_ENTRY_TYPE_ID").Not.Nullable().UniqueKey("KEY_CUST_ACC");

            HasMany(x => x.AccountingEntries)
                .KeyColumn("TRN_ACC_ACCOUNT_ID")
                .Cascade
                .All()
                .LazyLoad();

            MapVersion();
        }
    }
}
