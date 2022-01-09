using EFCoreRelationship.Models;

namespace EFCoreRelationship.DTO.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoint { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPG RPGClass { get; set; } = RPG.Knight;
    }
}
