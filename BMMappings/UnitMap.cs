using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class UnitMap
        : EntityMap<Unit>
    {
        public UnitMap()
            : base("MST_UNIT")
        {
            Table("MST_UNIT");

            Map(x => x.Code, "MST_UNIT_CODE").Length(6).Not.Nullable().Unique();
            Map(x => x.Name, "MST_UNIT_NAME_EN").Length(200).Not.Nullable().Unique();
            Map(x => x.NameTH, "MST_UNIT_NAME_TH").Length(200).Unique();

            Map(x => x.CountryID, "MST_COUNTRY_ID");
        }
    }
}
