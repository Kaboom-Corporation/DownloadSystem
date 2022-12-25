
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSystem.Shared.EditModels
{
    public class ProductVersionEditModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Version { get; set; }
        public Guid? InternalID { get; set; }
        public string? InternalVersion { get; set; }

        [Required]
        public Guid ProductID { get; set; }
        public ProductEditModel? Product { get; set; }
    }
}
