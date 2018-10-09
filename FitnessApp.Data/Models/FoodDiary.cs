namespace FitnessApp.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class FoodDiary
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Food> Meals { get; set; } = new List<Food>();

    }
}
