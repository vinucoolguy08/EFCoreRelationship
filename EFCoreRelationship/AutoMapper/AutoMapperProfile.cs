using AutoMapper;
using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.DTO.Skill;
using EFCoreRelationship.DTO.Weapon;
using EFCoreRelationship.Models;
using System.Linq;

namespace EFCoreRelationship.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => 
                c.MapFrom(c => c.CharacterSkill.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}
