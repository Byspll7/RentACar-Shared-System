using AutoMapper;
using Layout.Models;
using Layout.ViewModels;

namespace Layout.Mapping
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();  
        }
    }
}
