using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class Role
        : Entity
    {
        public virtual string Name { get; protected set; }

        //public virtual IEnumerable<Member> Member { get; protected set; }

        protected Role() { }

        public Role(string name)
        {
            Name = name;
        }
    }
}
