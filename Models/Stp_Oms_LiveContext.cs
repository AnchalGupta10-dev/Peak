using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Peak.Queries;

namespace Peak.Models
{
    public partial class Stp_Oms_LiveContext : DbContext
    {
        public Stp_Oms_LiveContext()
        {
        }

        public Stp_Oms_LiveContext(DbContextOptions<Stp_Oms_LiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GetCategoryResult> GetCategoryResults { get; set; } = null!;
        public virtual DbSet<GetTopFiveProductsResult> GetTopFiveProductsResult { get; set; } = null!;

        public virtual DbSet<SopOrder> SopOrders { get; set; } = null!;
        public virtual DbSet<SopOrderMethodReference> SopOrderMethodReferences { get; set; } = null!;
        public virtual DbSet<SopSalesChannelReference> SopSalesChannelReferences { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SopOrder>(entity =>
            {
                entity.ToTable("SopOrder");

                entity.HasIndex(e => e.ExternalOrderNumber, "IX_SopOrder_ExternalOrderNumber");

                entity.HasIndex(e => e.IceTimeStampUtc, "IX_SopOrder_IceTimeStampUtc");

                entity.HasIndex(e => e.OrderCreateTimeStampLocal, "IX_SopOrder_OrderCreateTimeStampLocal");

                entity.HasIndex(e => e.OrderCreateTimeStampUtc, "IX_SopOrder_OrderCreateTimeStampUtc");

                entity.HasIndex(e => e.ResolvedMktKeyCodeId, "IX_SopOrder_ResolvedMktKeyCodeID");

                entity.HasIndex(e => e.SopPartyId, "IX_SopOrder_SopPartyID")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.SopPartyId, e.SopOrderId, e.SopOrderMethodReferenceId }, "IX_SopOrder_SopPartyID_SopOrderID_SopOrderMethodReferenceID")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.SopPartyId, e.SopOrderId, e.SopOrderMethodReferenceId, e.TakerScsUserId, e.SopOrderTypeReferenceId, e.SellingActCompanyLocationId }, "IX_SopOrder_SopPartyID_SopOrderID_SopOrderMethodReferenceID_TakerScsUserID_SopOrderTypeReferenceID_SellingActCompanyLocationID");

                entity.HasIndex(e => e.OrderGuid, "UIX_SopOrder_OrderGuid")
                    .IsUnique()
                    .HasFilter("([OrderGuid] IS NOT NULL)");

                entity.HasIndex(e => e.OrderNumberCode, "UIX_SopOrder_OrderNumberCode")
                    .IsUnique();

                entity.HasIndex(e => e.SourceIdentifier, "UIX_SopOrder_SourceIdentifier")
                    .IsUnique();

                entity.Property(e => e.SopOrderId).HasColumnName("SopOrderID");

                entity.Property(e => e.ActCompanyDivisionId).HasColumnName("ActCompanyDivisionID");

                entity.Property(e => e.ActPaymentTermId).HasColumnName("ActPaymentTermID");

                entity.Property(e => e.CreateScsSqlUserId).HasColumnName("CreateScsSqlUserID");

                entity.Property(e => e.CreateScsUserId).HasColumnName("CreateScsUserID");

                entity.Property(e => e.CreateTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.EnteredMktKeyCode).HasMaxLength(64);

                entity.Property(e => e.ExternalOrderNumber).HasMaxLength(50);

                entity.Property(e => e.IceTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.MchPriceLevelId).HasColumnName("MchPriceLevelID");

                entity.Property(e => e.OrderAmount).HasColumnType("money");

                entity.Property(e => e.OrderCancelTimeStampLocal).HasColumnType("datetime");

                entity.Property(e => e.OrderCancelTimeStampTz).HasMaxLength(15);

                entity.Property(e => e.OrderCancelTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.OrderCreateIpaddress)
                    .HasMaxLength(15)
                    .HasColumnName("OrderCreateIPAddress");

                entity.Property(e => e.OrderCreateTimeStampLocal).HasColumnType("datetime");

                entity.Property(e => e.OrderCreateTimeStampTz).HasMaxLength(15);

                entity.Property(e => e.OrderCreateTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.OrderCreateWorkstationName).HasMaxLength(50);

                entity.Property(e => e.OrderNumberCode).HasMaxLength(15);

                entity.Property(e => e.PaymentAmount).HasColumnType("money");

                entity.Property(e => e.PriceTimeDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(50);

                entity.Property(e => e.ResolvedMktKeyCodeId).HasColumnName("ResolvedMktKeyCodeID");

                entity.Property(e => e.SellAmount).HasColumnType("money");

                entity.Property(e => e.SellingActCompanyLocationId).HasColumnName("SellingActCompanyLocationID");

                entity.Property(e => e.ShipmentAndLineChargeAmount).HasColumnType("money");

                entity.Property(e => e.ShippingAmount).HasColumnType("money");

                entity.Property(e => e.SopCancelReasonId).HasColumnName("SopCancelReasonID");

                entity.Property(e => e.SopExternalOrderSourceId).HasColumnName("SopExternalOrderSourceID");

                entity.Property(e => e.SopOrderContextReferenceId).HasColumnName("SopOrderContextReferenceID");

                entity.Property(e => e.SopOrderMethodReferenceId).HasColumnName("SopOrderMethodReferenceID");

                entity.Property(e => e.SopOrderTypeReferenceId).HasColumnName("SopOrderTypeReferenceID");

                entity.Property(e => e.SopPartyId).HasColumnName("SopPartyID");

                entity.Property(e => e.SourceIdentifier).HasMaxLength(50);

                entity.Property(e => e.TakerScsUserId).HasColumnName("TakerScsUserID");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.TaxCommitDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.TaxTimeDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UpdateScsSqlUserId).HasColumnName("UpdateScsSqlUserID");

                entity.Property(e => e.UpdateScsUserId).HasColumnName("UpdateScsUserID");

                entity.Property(e => e.UpdateTimeStampUtc).HasColumnType("datetime");

                entity.HasOne(d => d.SopOrderMethodReference)
                    .WithMany(p => p.SopOrders)
                    .HasForeignKey(d => d.SopOrderMethodReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SopOrder_SopOrderMethodReference");
            });

            modelBuilder.Entity<SopOrderMethodReference>(entity =>
            {
                entity.ToTable("SopOrderMethodReference");

                entity.HasIndex(e => e.SopSalesChannelReferenceId, "IX_SopOrderMethodReference_SopSalesChannelReferenceID");

                entity.HasIndex(e => e.OrderMethodCode, "UIX_SopOrderMethodReference_OrderMethodCode")
                    .IsUnique();

                entity.HasIndex(e => e.OrderMethodName, "UIX_SopOrderMethodReference_OrderMethodName")
                    .IsUnique();

                entity.Property(e => e.SopOrderMethodReferenceId).HasColumnName("SopOrderMethodReferenceID");

                entity.Property(e => e.CreateScsSqlUserId).HasColumnName("CreateScsSqlUserID");

                entity.Property(e => e.CreateScsUserId).HasColumnName("CreateScsUserID");

                entity.Property(e => e.CreateTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.OrderMethodCode).HasMaxLength(15);

                entity.Property(e => e.OrderMethodName).HasMaxLength(50);

                entity.Property(e => e.SopSalesChannelReferenceId).HasColumnName("SopSalesChannelReferenceID");

                entity.Property(e => e.UpdateScsSqlUserId).HasColumnName("UpdateScsSqlUserID");

                entity.Property(e => e.UpdateScsUserId).HasColumnName("UpdateScsUserID");

                entity.Property(e => e.UpdateTimeStampUtc).HasColumnType("datetime");

                entity.HasOne(d => d.SopSalesChannelReference)
                    .WithMany(p => p.SopOrderMethodReferences)
                    .HasForeignKey(d => d.SopSalesChannelReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SopOrderMethodReference_SopSalesChannelReference");
            });

            modelBuilder.Entity<SopSalesChannelReference>(entity =>
            {
                entity.ToTable("SopSalesChannelReference");

                entity.Property(e => e.SopSalesChannelReferenceId).HasColumnName("SopSalesChannelReferenceID");

                entity.Property(e => e.CreateScsSqlUserId).HasColumnName("CreateScsSqlUserID");

                entity.Property(e => e.CreateScsUserId).HasColumnName("CreateScsUserID");

                entity.Property(e => e.CreateTimeStampUtc).HasColumnType("datetime");

                entity.Property(e => e.SalesChannelCode).HasMaxLength(15);

                entity.Property(e => e.SalesChannelName).HasMaxLength(50);

                entity.Property(e => e.UpdateScsSqlUserId).HasColumnName("UpdateScsSqlUserID");

                entity.Property(e => e.UpdateScsUserId).HasColumnName("UpdateScsUserID");

                entity.Property(e => e.UpdateTimeStampUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<GetCategoryResult>().HasNoKey();
            modelBuilder.Entity<GetTopFiveProductsResult>()
                .HasNoKey();// for the table having primary key
                //.Property(entity => entity.Rank)
                //.HasConversion<int>();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
