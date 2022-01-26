using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.DTO.CharacterSkill;
using EFCoreRelationship.Models;
using System.Threading.Tasks;

namespace EFCoreRelationship.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}
