using AutoMapper;
using Layered.Business.Contract.Entities;
using Layered.DataLayer.Contract.Table;

namespace Layered.Application.Mapping
{
    public class BusinessMappingProfile : Profile
    {
        public BusinessMappingProfile()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<Item, ItemEntity>().ReverseMap();
        }
    }
}
