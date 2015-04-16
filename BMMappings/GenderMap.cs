using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class GenderMap
        : EntityMap<Gender>
    {
        private const string TableName = "MST_APP_GENDER";

        public GenderMap()
            : base(TableName)
        {
            Table(TableName);

            Map(x => x.Name, "GENDER_NAME").Length(255).Not.Nullable().Unique();
            Map(x => x.NameTH, "GENDER_NAME_TH").Length(255).Unique();

            MapVersion();
        }
    }
}
