namespace Peak.Queries
{
    public class GetTopFiveProductsResult
    { 
        public DateTime? DATE { get; set; }

        public string? OrderMethodName { get; set; }

        public string? OrderLineCode { get; set; }

        public decimal? Quantity { get; set;}

        public Int64? Rank { get; set; }

    }
}
