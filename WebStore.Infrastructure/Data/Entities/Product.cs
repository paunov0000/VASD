﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WebStore.Infrastructure.Data.Constants.ModelConstants.Product;

namespace WebStore.Infrastructure.Data.Entities
{
    [Comment("Holds info for the Product entity")]
    public class Product
    {
        [Key]
        [Comment("Primary key of the product")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Name of the product")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the product")]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Brand))]
        [Comment("Foreign key of the brand")]
        public Guid BrandId { get; set; }

        [Required]
        [Comment("Navigation property to the Brand")]
        public Brand Brand { get; set; } = null!;

        [Required]
        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Image URL of the product")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Date of the product creation")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("Quantity of products sold")]
        public int SoldCount { get; set; }

        [Required]
        [Comment("A flag which sets the product state whether its on sale or not")]
        public bool OnSale { get; set; }

        [Required]
        [Comment("Quantity of the product available")]
        public int Quantity { get; set; }

        [Required]
        [Comment("A flag which sets the product state as whether its visible or not")]
        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey(nameof(Category))]
        [Comment("Foreign key of the Category")]
        public Guid CategoryId { get; set; }

        [Required]
        [Comment("Navigation property to the Category")]
        public Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Subcategory))]
        [Comment("Foreign key of the Subcategory")]
        public Guid SubcategoryId { get; set; }

        [Required]
        [Comment("Navigation property to the Subcategory")]
        public Subcategory Subcategory { get; set; } = null!;

        [Required]
        [Comment("Orders of the product")]
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
