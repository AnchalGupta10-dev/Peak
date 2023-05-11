using System;
using System.Collections.Generic;

namespace Peak.Models
{
    public partial class SopSalesChannelReference
    {
        public SopSalesChannelReference()
        {
            SopOrderMethodReferences = new HashSet<SopOrderMethodReference>();
        }

        public long SopSalesChannelReferenceId { get; set; }
        public short? CreateScsUserId { get; set; }
        public DateTime? CreateTimeStampUtc { get; set; }
        public short? CreateScsSqlUserId { get; set; }
        public short? UpdateScsUserId { get; set; }
        public DateTime? UpdateTimeStampUtc { get; set; }
        public short? UpdateScsSqlUserId { get; set; }
        public Guid TransactionGuid { get; set; }
        public string SalesChannelCode { get; set; } = null!;
        public string SalesChannelName { get; set; } = null!;
        public virtual ICollection<SopOrderMethodReference> SopOrderMethodReferences { get; set; }
    }
}
