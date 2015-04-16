using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class MemberProfile
        : Entity
    {
        public virtual Member Member { get; protected set; }

        public virtual string FirstName { get; set; }
        public virtual string MidleName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string PhoneNumber { get; set; }

        protected MemberProfile() { }

        public MemberProfile(Member member)
        {
            Member = member;
        }
    }
}
