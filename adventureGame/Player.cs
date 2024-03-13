using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureGame
{
    [Serializable]
    public class Player
    {
        static Random rand = new Random();

        public string name;
        public int coins = 50;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 2;

        // dificulty kan je kopen in de shop
        public int mods = 0;

        
       
    }
}
