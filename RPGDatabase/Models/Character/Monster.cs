using System;
using RPGDatabase.Models.Enum;

namespace RPGDatabase.Models.Character
{
    public class Monster : CharacterCtrl
    {
        public TypeEnum Type { get; set; }

        public Monster(string name, TypeEnum type) : base(name)
        {
            Type = type;
        }
    }
}
