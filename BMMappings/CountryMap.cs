using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class CountryMap
        : EntityMap<Country>
    {
        public CountryMap()
            : base("MST_COUNTRY")
        {
            Table("MST_COUNTRY");

            Map(x => x.Name, "MST_COUNTRY_NAME_EN").Length(100).Not.Nullable().Unique();
            Map(x => x.NameTH, "MST_COUNTRY_NAME_TH").Length(100).Unique();
        }
    }
}
