using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class CurrencyMap
        : EntityMap<Currency>
    {
        public CurrencyMap()
            : base("TRN_ACC_CURRENCY")
        {
            Table("TRN_ACC_CURRENCY");

            Map(x => x.Code, "CODE").Length(3).Not.Nullable().Unique();
            Map(x => x.Description, "DESCRIPTION");

            MapVersion();
        }
    }
}
