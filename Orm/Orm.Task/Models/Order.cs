using LinqToDB.Mapping;
using System;

namespace Orm.Task.Models
{
    [Table("Orders")]
    public class Order : IDbModel
    {
        [Identity]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(Status))]
        public OrderStatus Status { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime UpdatedDate { get; set; }

        [Column(nameof(ProductId))]
        public int ProductId { get; set; }
    }
}
