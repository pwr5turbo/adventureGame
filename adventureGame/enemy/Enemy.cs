using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.enemy
{
    public class Enemy
    {
        // public int id;  
        public string name;
        public int power;
        public int health;
        
        public string openingsLine = "You open the first door you see a monster./r/n" +
                    "While you pick up the wooden sword you just found the monster comes charging at you./r/n";



        private static Random rand = new Random();

        public string OpeningsLine()
        {
            return openingsLine;

        }
        public Enemy(string name, int power, int health)
        {
            this.name = name;
            this.power = power;
            this.health = health;
        }

        public void DamageTaken(int damage)
        {
            health -= damage;
            // health < 0 death
            // 
        }
        public bool IsAlive()
        {
            return health > 0;
        }

        public string Status()
        {
            return name + " health: " + health + " Power: " + power;
        }































        public static Enemy CreateRandomEnemy(Player p)
        {
            Enemy randomE = new Enemy(Names.GetName(), GetStatsP(p), GetStatsH(p));
            randomE.openingsLine = "You turn the corner and encounter a monster./r/n";
            return randomE;
        }

        private static int GetStatsP(Player currentPlayer)
        {
            // voor de power stat
            int upper = 2 * currentPlayer.mods + 4;
            int lower = currentPlayer.mods + 1;
            return rand.Next(lower, upper);
        }
        private static int GetStatsH(Player currentPlayer)
        {
            //voor de health stat
            int upper = 2 * currentPlayer.mods + 6;
            int lower = currentPlayer.mods + 1;
            return rand.Next(lower, upper);
        }


    }
}
