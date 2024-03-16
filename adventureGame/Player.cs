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
        //Player info
        public string name;
        public int id =0;
        public int coins = 1111111111;        
        public int levelUpXp = 50;
        public int currentLevel = 1;
        public int skillpoints = 0;
        //Player skills
        public int maxHealth = 11111110;
        public int health = 15;
        public int playerDamage = 1;
        public int playerSpeed = 3;        
        //Player inventory
        public int armorValue = 1;
        public int potion = 10;        
        public int weaponValue = 2;
        // player stats
        public int monsterSlays = 0;
        

        // dificulty kan je kopen in de shop
        public int mods = 0;

        
       
    }
}
