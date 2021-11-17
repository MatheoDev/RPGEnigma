using System;
namespace RPGEnigma.Menu
{
    /**
     * Interface IMenuItem
     * Permet de donner un nom à l'élément
     * et lui donner accès à une methode commune pour tous les éléments
     */
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
