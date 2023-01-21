﻿using LinqToDB.Mapping;

namespace Orm.Task.Models
{
    [Table("Products")]
    public class Product : IDbModel
    {
        [Identity]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(Name))]
        public string Name { get; set; }

        [Column(nameof(Description))]
        public string Description { get; set; }

        [Column(nameof(Weight))]
        public double Weight { get; set; }

        [Column(nameof(Height))]
        public double Height { get; set; }

        [Column(nameof(Width))]
        public double Width { get; set; }

        [Column(nameof(Length))]
        public double Length { get; set; }
    }
}
