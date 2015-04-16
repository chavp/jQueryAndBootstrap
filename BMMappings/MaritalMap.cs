using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class MaritalMap
        : EntityMap<Marital>
    {
        private const string TableName = "MST_APP_MARITAL";

        public MaritalMap()
            : base(TableName)
        {
            Table(TableName);

            Map(x => x.Name, "MARITAL_NAME").Length(255).Not.Nullable().Unique();
            Map(x => x.NameTH, "MARITAL_NAME_TH").Length(255).Unique();

            MapVersion();
        }
    }
}
