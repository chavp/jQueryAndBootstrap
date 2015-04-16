using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using FluentNHibernate.Mapping;
    using Cwn.eVisa.BusinessModels;

    public class EApplicationVisaRequestAccountingEntryMap
        : EntityMap<EApplicationVisaRequestAccountingEntry>
    {
        public EApplicationVisaRequestAccountingEntryMap()
            : base("TRN_APP_EVISA_ACC_ENTRY")
        {
            Table("TRN_APP_EVISA_ACC_ENTRY");

            References(x => x.EApplicationVisa, "TRN_APP_EVISA_ID").Unique();
            References(x => x.AccountingEntry, "TRN_ACC_ACCOUNTING_ENTRY_ID").Unique();

            References(x => x.Receipt, "TRN_ACC_RECEIPT_ID");

            //References(x => x., "AUT_MEMBER_ID").Not.Nullable();

            MapVersion();
        }
    }
}
