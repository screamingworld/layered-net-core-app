using AutoMapper;
using Layered.Application.Contract.Models;
using Layered.DataLayer.Contract.Entities;

namespace Layered.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<ItemEntity, ItemModel>().ReverseMap();
        }
    }
}
