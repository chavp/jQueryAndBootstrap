using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class TravellingMap
        : EntityMap<Travelling>
    {
        private const string TableName = "MST_APP_TRAVELLING";

        public TravellingMap()
            : base(TableName)
        {
            Table(TableName);

            Map(x => x.Name, "TRAVELLING_NAME").Length(255).Not.Nullable().Unique();
            Map(x => x.NameTH, "TRAVELLING_NAME_TH").Length(255).Unique();

            MapVersion();
        }
    }
}
