namespace FitnessApp.Data.Models
{
    using FitnessApp.Common.Contants;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MinCommentTitleLength)]
        [MaxLength(DataConstants.MaxCommentTitleLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

    }
}