namespace FitnessApp.Data.Models
{
    using FitnessApp.Common.Contants;
    using System.ComponentModel.DataAnnotations;


    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.MinReplyContentLength)]
        [MaxLength(DataConstants.MaxReplyContentLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}