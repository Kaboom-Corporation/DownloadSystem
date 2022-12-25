
using System.ComponentModel.DataAnnotations;

namespace DownloadSystem.WebAPI.Entitites
{
    public class ProductEntity
    {
        [Key]
        public Guid ID { get; set; }
        
        [Required, StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string? Description { get; set; }

        [StringLength(150), Url]
        public string? Url { get; set; }

        public virtual HashSet<ProductVersionEntity> Versions { get; set; } = new();

        public ProductEntity() { }
    }
}
