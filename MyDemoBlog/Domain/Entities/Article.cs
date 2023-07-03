using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MyDemoBlog.Domain.Entities
{
    public class Article : BaseEntity
    {
        [Required]
        public string? ShortTitle { get; set; }
        [Required]
        public Guid UserID { get; set; }

        [DisplayName("картинка")]
        public string? Image { get; set; }
        [Required]
        public string? Text { get; set; }
    }
}
