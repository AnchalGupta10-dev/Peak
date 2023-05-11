using System;
using System.Collections.Generic;

namespace Peak.Models
{
    public partial class SopOrderMethodReference
    {
        public SopOrderMethodReference()
        {
            SopOrders = new HashSet<SopOrder>();
        }

        public long SopOrderMethodReferenceId { get; set; }
        public short? CreateScsUserId { get; set; }
        public DateTime? CreateTimeStampUtc { get; set; }
        public short? CreateScsSqlUserId { get; set; }
        public short? UpdateScsUserId { get; set; }
        public DateTime? UpdateTimeStampUtc { get; set; }
        public short? UpdateScsSqlUserId { get; set; }
        public Guid TransactionGuid { get; set; }
        public string OrderMethodCode { get; set; } = null!;
        public string OrderMethodName { get; set; } = null!;
        public bool UserSelectable { get; set; }
        public long SopSalesChannelReferenceId { get; set; }

        public virtual SopSalesChannelReference SopSalesChannelReference { get; set; } = null!;
        public virtual ICollection<SopOrder> SopOrders { get; set; }
    }
}
