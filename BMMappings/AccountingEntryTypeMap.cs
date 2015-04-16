using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class AccountingEntryTypeMap
        : EntityMap<AccountingEntryType>
    {
        public AccountingEntryTypeMap()
            : base("TRN_ACC_ENTRY_TYPE")
        {
            Table("TRN_ACC_ENTRY_TYPE");

            Map(x => x.Name, "NAME").Length(100).Not.Nullable().Unique();
            Map(x => x.Description, "DESCRIPTION");

            MapVersion();
        }
    }
}
