using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    public class Unit
        : Entity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string NameTH { get; set; }

        public virtual long? CountryID { get; set; }
    }
}
