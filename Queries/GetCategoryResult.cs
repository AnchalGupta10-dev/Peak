using System.ComponentModel.DataAnnotations;

namespace Peak.Queries
{
    public partial class GetCategoryResult
    {
        public GetCategoryResult()
        {

        }
        public string? OrderMethodName { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]// annotation
        public DateTime? Date { get; set; } = null!;

        public decimal? sales { get; set; } = null!;

        public decimal? max_Order { get; set; } = null!;

        public Int32? OrderCount { get; set; } = null!;
    }
}
