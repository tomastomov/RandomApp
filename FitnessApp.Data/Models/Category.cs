namespace FitnessApp.Data.Models
{
    using FitnessApp.Common.Contants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MinCategoryNameLength)]
        [MaxLength(DataConstants.MaxCategoryNameLength)]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<CategoryArticle> Articles { get; set; } = new List<CategoryArticle>();

    }
}
