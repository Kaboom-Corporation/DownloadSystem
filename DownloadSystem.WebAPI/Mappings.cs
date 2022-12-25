using AutoMapper;
using DownloadSystem.Shared.EditModels;
using DownloadSystem.Shared.ViewModels;
using DownloadSystem.WebAPI.Entitites;

namespace DownloadSystem.WebAPI
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ProductEntity, ProductViewModel>().ReverseMap();
            CreateMap<ProductEntity, ProductEditModel>().ReverseMap();
            CreateMap<ProductEditModel, ProductViewModel>().ReverseMap();

            CreateMap<ProductVersionEntity, ProductVersionViewModel>().ReverseMap();
            CreateMap<ProductVersionEntity, ProductVersionEditModel>().ReverseMap();
            CreateMap<ProductVersionEditModel, ProductVersionViewModel>().ReverseMap();
        }
    }
}
