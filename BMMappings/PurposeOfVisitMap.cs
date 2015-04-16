using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class PurposeOfVisitMap
        : EntityMap<PurposeOfVisit>
    {
        private const string TableName = "MST_APP_PURPOSE_VISIT";

        public PurposeOfVisitMap()
            : base(TableName)
        {
            Table(TableName);

            Map(x => x.Name, "PURPOSE_NAME").Length(255).Not.Nullable().Unique();
            Map(x => x.NameTH, "PURPOSE_NAME_TH").Length(255).Unique();

            MapVersion();
        }
    }
}
