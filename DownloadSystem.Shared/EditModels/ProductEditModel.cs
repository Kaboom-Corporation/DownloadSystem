using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSystem.Shared.EditModels
{
    public class ProductEditModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string? Description { get; set; }

        [MaxLength(150), Url]
        public string? Url { get; set; }
    }
}
