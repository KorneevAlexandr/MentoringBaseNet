namespace WebApiTask.Models.QueryModels
{
    public class ProductPaginationModel
    {
        public int PageNumber { get; set; } = 0;

        public int PageSize { get; set; } = 10;

        public int? CategoryId { get; set; }
    }
}
