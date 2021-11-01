using System;
namespace RPGEnigma.Menu
{
    public interface IMenuItem
    {
        string name
        {
            get;
            set;
        }

        void InitItem();
    }
}
