using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class MemberProfileMap
        : EntityMap<MemberProfile>
    {
        public MemberProfileMap()
            : base("TRN_AUT_MEMBER_PROFILE")
        {
            Table("TRN_AUT_MEMBER_PROFILE");

            References(x => x.Member, "TRN_AUT_MEMBER_ID").Not.Nullable().Unique();

            Map(x => x.FirstName, "FIRST_NAME").Not.Nullable().UniqueKey("KEY_FULLNAME");
            Map(x => x.LastName, "FAMILY_NAME").Not.Nullable().UniqueKey("KEY_FULLNAME");

            MapVersion();
        }
    }
}
