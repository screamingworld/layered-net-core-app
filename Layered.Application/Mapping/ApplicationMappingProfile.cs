using AutoMapper;
using Layered.Application.Contract.Models;
using Layered.Business.Contract.Entities;

namespace Layered.Application.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<ItemEntity, ItemModel>().ReverseMap();
        }
    }
}
