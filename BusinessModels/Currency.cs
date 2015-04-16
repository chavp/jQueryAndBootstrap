using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/ISO_4217
    /// Thai Baht (THB)
    /// United States dollar (USD)
    /// Chinese Yuan (CNY)
    /// </summary>
    public class Currency : Entity
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }

        protected Currency() { }

        public Currency(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException("Please require Code");

            Code = code;
        }
    }
}
