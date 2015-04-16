using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class VisaTypeMap
        : ClassMap<VisaType>
    {
        public VisaTypeMap()
        {
            Table("MST_VISA_TYPE");

            Id(t => t.ID, "MST_VISA_TYPE_ID");

            Map(x => x.Code, "MST_VISA_TYPE_CODE").Not.Nullable();
            Map(x => x.Name, "MST_VISA_TYPE_NAME_EN").Not.Nullable();
            Map(x => x.NameTH, "MST_VISA_TYPE_NAME_TH").Not.Nullable();
        }
    }
}
