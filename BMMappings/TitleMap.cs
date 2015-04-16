using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class TitleMap
        : EntityMap<Title>
    {
        public TitleMap()
            : base("MST_TITLE")
        {
            Table("MST_TITLE");

            Map(x => x.Name, "MST_TITLE_NAME_EN").Length(20).Not.Nullable().Unique();
            Map(x => x.NameTH, "MST_TITLE_NAME_TH").Length(20).Unique();
        }
    }
}
