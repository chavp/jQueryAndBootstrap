using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class RoleMap
         : EntityMap<Role>
    {
        public RoleMap()
            : base("TRN_AUT_ROLE")
        {
            Table("TRN_AUT_ROLE");

            Map(x => x.Name, "NAME").Not.Nullable().Unique();

            //HasMany(x => x.Member)
            //    .KeyColumn("AUT_MEMBER_ID")
            //    .LazyLoad();

            MapVersion();
        }
    }
}
