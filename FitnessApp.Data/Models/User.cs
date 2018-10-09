namespace FitnessApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public decimal? BodyFat { get; set; }

        public ICollection<FoodDiary> FoodDiaries { get; set; } = new List<FoodDiary>();

        public ICollection<Food> MyFoods { get; set; } = new List<Food>();

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();

    }
}
