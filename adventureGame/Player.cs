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
        public int id =0;
        public int coins = 111111150;        
        public int levelUpXp = 50;
        public int currentLevel = 1;
        public int skillpoints = 0;
        public int maxHealth = 11111110;
        public int health = 11111110;
        public int damage = 1;
        public int armorValue = 1;
        public int potion = 10;
        public int playerDamage = 1;
        public int weaponValue = 2;
        public int monsterSlays = 0;

        // dificulty kan je kopen in de shop
        public int mods = 4;

        
       
    }
}
