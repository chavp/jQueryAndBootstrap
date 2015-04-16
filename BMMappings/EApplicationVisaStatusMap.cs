using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class EApplicationVisaStatusMap
        : EntityMap<EApplicationVisaStatus>
    {
        public EApplicationVisaStatusMap()
            : base("TRN_APP_EVISA_STATUS")
        {
            Table("TRN_APP_EVISA_STATUS");

            Map(x => x.Name, "NAME").Length(20).Not.Nullable().Unique();
            Map(x => x.Display, "DISPLAY").Length(50).Not.Nullable();

            MapVersion();
        }
    }
}
