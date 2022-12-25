using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DownloadSystem.Shared.ViewModels;

public class ProductVersionViewModel
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }
    public Guid? InternalID { get; set; }
    public string? InternalVersion { get; set; }

    public Guid ProductID { get; set; }
    public ProductViewModel Product { get; set; }
}