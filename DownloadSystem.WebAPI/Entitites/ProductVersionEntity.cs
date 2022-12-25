using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DownloadSystem.WebAPI.Entitites
{
    public class ProductVersionEntity
    {
        [Key]
        public Guid ID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string? Description { get; set; }
        public DateTime DateTimeLoad { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string? Version { get; set; }
        public Guid? InternalID { get; set; }
        public string? InternalVersion { get; set; }
        [Required]
        public string FileFullName { get; set; }
        [Required]
        public string FileContentType { get; set; }
        [Required]
        public byte[] FileByteArray { get; set; }

        [Required]
        public Guid ProductID { get; set; }
        [ForeignKey(nameof(ProductID))] 
        public virtual ProductEntity Product { get; set; }
    }
}
