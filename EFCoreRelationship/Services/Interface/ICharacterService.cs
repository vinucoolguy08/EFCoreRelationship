using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreRelationship.Services.Interface
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();

        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id);
    }
}
