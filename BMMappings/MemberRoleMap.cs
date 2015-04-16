using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class MemberRoleMap
        : EntityMap<MemberRole>
    {
        public MemberRoleMap()
            : base("TRN_AUT_MEMBER_ROLE")
        {
            Table("TRN_AUT_MEMBER_ROLE");

            References(x => x.Member, "TRAN_AUT_MEMBER_ID").Not.Nullable();
            References(x => x.Role, "TRAN_AUT_ROLE_ID").Not.Nullable();

            MapVersion();
        }
    }
}
