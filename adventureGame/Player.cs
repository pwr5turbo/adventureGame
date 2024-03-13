using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Player
    {
        static Random rand = new Random();

        public string name;
        public int id =0;
        public int coins = 50;        
        public int levelUpXp = 50;
        public int currentLevel = 1;
        public int skillpoints = 0;
        public int maxHealth = 10;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int playerDamage = 1;
        public int weaponValue = 2;
        public int monsterSlays = 0;

        // dificulty kan je kopen in de shop
        public int mods = 0;

        
       
    }
}
