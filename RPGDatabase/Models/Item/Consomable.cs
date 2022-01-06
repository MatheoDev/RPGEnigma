using System;
using System.Collections.Generic;
using RPGDatabase.Models.Enum;
using RPGDatabase.Models.ManyToMany;

namespace RPGDatabase.Models.Item
{
    /**
     * Entité Consomable 
     */
    public class Consomable : ItemCtrl
    {
        public List<HeroConsomable> HeroConsomables { get; set; }
    }
}
