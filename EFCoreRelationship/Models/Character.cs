using System.Collections.Generic;

namespace EFCoreRelationship.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Frodo";

        public int HitPoint { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defence { get; set; } = 10;

        public int Intelligence { get; set; } = 10;

        public RPG RPGClass { get; set; } = RPG.Knight;

        public User User { get; set; }

        public Weapon Weapon { get; set; }

        public List<CharacterSkill> CharacterSkill { get; set; }
    }
}
