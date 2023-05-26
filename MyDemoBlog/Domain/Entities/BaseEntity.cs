using Microsoft.Build.Framework;
using System.ComponentModel;

namespace MyDemoBlog.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public virtual string? Title { get; set; }

        [DisplayName("дата создания")]
        public virtual DateTime DateOfCreate { get; set; }

        public BaseEntity() => DateOfCreate = DateTime.UtcNow;
    }
}
