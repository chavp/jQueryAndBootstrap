using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class NationMap
        : EntityMap<Nation>
    {
        public NationMap()
            : base("MST_NATION")
        {
            Table("MST_NATION");

            Map(x => x.Name, "MST_NATION_NAME_EN").Length(100).Not.Nullable().Unique();
            Map(x => x.NameTH, "MST_NATION_NAME_TH").Length(100).Unique();
        }
    }
}
