using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Player
    {
        static Random rand = new Random();

        public string name;
        public int coins = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 2;

        // dificulty kan je kopen in de shop
        public int mods = 0;

        
        public int GetStatsP()
        {
            // voor de power stat
            int upper = (2 * mods + 4);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }
        public int GetStatsH()
        {
            //voor de health stat
            int upper = (2 * mods + 6);
            int lower = (mods + 1);
            return rand.Next(lower, upper);
        }
    }
}
