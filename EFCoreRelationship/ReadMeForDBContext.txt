Table
-----
User
Character
Skill
Weapon

One to Many
User -> Character

One to One
Character -> Weapon

Many to Many
Character -> Skill (CharacterSkill)

Character Table
------------------
User
Weapon
CharacterSkill (List)