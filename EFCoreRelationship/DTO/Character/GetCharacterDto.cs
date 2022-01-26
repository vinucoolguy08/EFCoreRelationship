using EFCoreRelationship.DTO.Skill;
using EFCoreRelationship.DTO.Weapon;
using EFCoreRelationship.Models;
using System.Collections.Generic;

namespace EFCoreRelationship.DTO.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoint { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPG RPGClass { get; set; } = RPG.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skills { get; set; }
    }
}
