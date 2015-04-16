using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.BusinessModels
{
    /// <summary>
    /// http://www.pattanakit.net/%E0%B8%A3%E0%B8%A7%E0%B8%A1%E0%B8%9A%E0%B8%97%E0%B8%84%E0%B8%A7%E0%B8%B2%E0%B8%A1%E0%B8%A0%E0%B8%B2%E0%B8%A9%E0%B8%B5/%E0%B9%83%E0%B8%9A%E0%B8%81%E0%B8%B3%E0%B8%81%E0%B8%B1%E0%B8%9A%E0%B8%A0%E0%B8%B2%E0%B8%A9%E0%B8%B5%E0%B9%81%E0%B8%A5%E0%B8%B0%E0%B9%83%E0%B8%9A%E0%B9%80%E0%B8%AA%E0%B8%A3%E0%B9%87%E0%B8%88%E0%B8%A3%E0%B8%B1%E0%B8%9A%E0%B9%80%E0%B8%87%E0%B8%B4%E0%B8%99-%E0%B8%AD%E0%B8%AD%E0%B8%81%E0%B8%AD%E0%B8%A2%E0%B9%88%E0%B8%B2%E0%B8%87%E0%B9%84%E0%B8%A3%E0%B9%84%E0%B8%A1%E0%B9%88%E0%B8%A1%E0%B8%B5%E0%B8%9B%E0%B8%B1%E0%B8%8D%E0%B8%AB%E0%B8%B2.html
    /// </summary>
    public class Receipt : Entity
    {
        public virtual DateTime ReceiptDateUTC { get; set; }
        public virtual Member ReceivedBy { get; set; }
        public virtual string Method { get; set; }

        public virtual decimal ReceivedAmountUSD { get; protected set; }

        protected Receipt() { }

        public Receipt(
            DateTime receiptDate, 
            Member receivedBy, 
            decimal receivedAmountUSD)
        {
            ReceiptDateUTC = receiptDate;
            ReceivedBy = receivedBy;
            ReceivedAmountUSD = receivedAmountUSD;
        }
    }
}
