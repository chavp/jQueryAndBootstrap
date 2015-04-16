using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class MemberRole 
        : Entity
    {
        public virtual Member Member { get; protected set; }
        public virtual Role Role { get; protected set; }

        protected MemberRole() { }

        public MemberRole(Member member, Role role)
        {
            Member = member;
            Role = role;
        }
    }
}
