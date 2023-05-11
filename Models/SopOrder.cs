using System;
using System.Collections.Generic;

namespace Peak.Models
{
    public partial class SopOrder
    {
        public SopOrder()
        {
        }

        public long SopOrderId { get; set; }
        public short? CreateScsUserId { get; set; }
        public DateTime? CreateTimeStampUtc { get; set; }
        public short? CreateScsSqlUserId { get; set; }
        public short? UpdateScsUserId { get; set; }
        public DateTime? UpdateTimeStampUtc { get; set; }
        public short? UpdateScsSqlUserId { get; set; }
        public Guid TransactionGuid { get; set; }
        public string OrderNumberCode { get; set; } = null!;
        public long ActCompanyDivisionId { get; set; }
        public long SellingActCompanyLocationId { get; set; }
        public long SopPartyId { get; set; }
        public long MchPriceLevelId { get; set; }
        public long SopOrderMethodReferenceId { get; set; }
        public long ActPaymentTermId { get; set; }
        public string EnteredMktKeyCode { get; set; } = null!;
        public long ResolvedMktKeyCodeId { get; set; }
        public string? PurchaseOrderNumber { get; set; }
        public long? SopExternalOrderSourceId { get; set; }
        public string? ExternalOrderNumber { get; set; }
        public DateTime OrderCreateTimeStampUtc { get; set; }
        public DateTime OrderCreateTimeStampLocal { get; set; }
        public string OrderCreateTimeStampTz { get; set; } = null!;
        public long TakerScsUserId { get; set; }
        public decimal SellAmount { get; set; }
        public decimal ShipmentAndLineChargeAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal OrderAmount { get; set; }
        public DateTime PriceTimeDateUtc { get; set; }
        public DateTime TaxTimeDateUtc { get; set; }
        public string SourceIdentifier { get; set; } = null!;
        public long? SopCancelReasonId { get; set; }
        public DateTime? OrderCancelTimeStampUtc { get; set; }
        public DateTime? OrderCancelTimeStampLocal { get; set; }
        public string? OrderCancelTimeStampTz { get; set; }
        public decimal PaymentAmount { get; set; }
        public long SopOrderTypeReferenceId { get; set; }
        public DateTime? IceTimeStampUtc { get; set; }
        public string? OrderCreateWorkstationName { get; set; }
        public string? OrderCreateIpaddress { get; set; }
        public DateTime? TaxCommitDateTimeUtc { get; set; }
        public long? SopOrderContextReferenceId { get; set; }
        public Guid? OrderGuid { get; set; }
        public virtual SopOrderMethodReference SopOrderMethodReference { get; set; } = null!;
    }
}
