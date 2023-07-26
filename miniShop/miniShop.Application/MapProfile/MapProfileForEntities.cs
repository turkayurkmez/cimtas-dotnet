using AutoMapper;
using miniShop.Application.DataTransferObjects.Requests;
using miniShop.Entities;

namespace miniShop.Application.MapProfile
{
    public class MapProfileForEntities : Profile
    {
        public MapProfileForEntities()
        {
            CreateMap<CreateNewProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
