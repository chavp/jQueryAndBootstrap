using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class AppVisaTypeMap
        : EntityMap<AppVisaType>
    {
        public AppVisaTypeMap()
            : base("TRN_UI_VISA_TYPE")
        {
            Table("TRN_UI_VISA_TYPE");

            References(x => x.VisaType, "MST_VISA_TYPE_ID").Not.Nullable();

            Map(x => x.Name, "NAME");
            Map(x => x.NameTH, "NAME_TH");

            MapVersion();
        }
    }
}
