using System;
namespace RPGEnigma.Character
{
    public class CharacterCtrl
    {
        protected CharacterStat _stats;

        protected int _level;

        protected int _experienceLvl;

        protected int _money;

        public CharacterCtrl(CharacterStat stats)
        {
            _stats = stats;
            _level = 0;
            _experienceLvl = 0;
            _money = 0;
        }
    }
}
