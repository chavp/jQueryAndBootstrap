using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class Member : Entity
    {
        public virtual MemberProfile Profile { get; protected set; }

        public virtual string Username { get; protected set; }
        public virtual string Password { get; protected set; }

        //public virtual IEnumerable<Role> Roles { get; protected set; }

        protected Member() { }

        public Member(string userName)
        {
            Username = userName;

            Profile = new MemberProfile(this);
        }
    }
}
