using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class MemberMap
        : EntityMap<Member>
    {
        public MemberMap()
            : base("TRN_AUT_MEMBER")
        {
            Table("TRN_AUT_MEMBER");

            Map(x => x.Username, "USERNAME").Length(100).Not.Nullable().Unique();
            Map(x => x.Password, "PASSWORD");

            //HasMany(x => x.Roles)
            //    .KeyColumn("AUT_ROLE_ID")
            //    .LazyLoad();

            MapVersion();
        }
    }
}
