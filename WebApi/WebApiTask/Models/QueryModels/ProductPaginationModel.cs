namespace WebApiTask.Models.QueryModels
{
    public class ProductPaginationModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int? CategoryId { get; set; }
    }
}
