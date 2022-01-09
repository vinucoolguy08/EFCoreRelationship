using AutoMapper;
using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.Models;

namespace EFCoreRelationship.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}
