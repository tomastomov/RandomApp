namespace FitnessApp.Data.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Calories => 4 * this.Protein + 4 * this.Carbohydrates + 9 * this.Fats;

        public decimal Protein { get; set; }

        public decimal Carbohydrates { get; set; }

        public decimal Fats { get; set; }
    }
}
