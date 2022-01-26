using EFCoreRelationship.DTO.Character;
using EFCoreRelationship.DTO.Weapon;
using EFCoreRelationship.Models;
using System.Threading.Tasks;

namespace EFCoreRelationship.Services.WeaponService
{
    public interface IWeaponService
    {
       Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
