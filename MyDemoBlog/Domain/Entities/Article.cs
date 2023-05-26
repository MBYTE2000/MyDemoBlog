using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MyDemoBlog.Domain.Entities
{
    public class Article : BaseEntity
    {
        [Required]
        public Guid UserID { get; set; }

        [DisplayName("картинка")]
        public string? Image { get; set; }
    }
}
