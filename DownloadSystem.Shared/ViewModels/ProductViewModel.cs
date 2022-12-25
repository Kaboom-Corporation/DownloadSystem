using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSystem.Shared.ViewModels
{
    public class ProductViewModel
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Url { get; set; }

        public List<ProductVersionViewModel> Versions { get; set; } = new();
    }
}
