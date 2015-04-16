using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cwn.eVisa.NH.Mappings
{
    using Cwn.eVisa.BusinessModels;
    using FluentNHibernate.Mapping;

    public class ReceiptMap
        : EntityMap<Receipt>
    {
        public ReceiptMap()
            : base("TRN_ACC_RECEIPT")
        {
            Table("TRN_ACC_RECEIPT");

            References(x => x.ReceivedBy, "TRN_AUT_MEMBER_ID").Not.Nullable();

            Map(x => x.ReceiptDateUTC, "RECEIPT_DATE_UTC").CustomSqlType("DATE").Not.Nullable();
            Map(x => x.ReceivedAmountUSD, "RECEIVED_AMOUNT_USD");
            Map(x => x.Method, "PAYMENT_METHOD").Length(50);

            MapVersion();
        }
    }
}
