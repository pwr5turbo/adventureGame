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
        public int speed;
        
        public string openingsLine = "You open the first door you see a monster.\r\n" +
                    "While you pick up the wooden sword you just found the monster comes charging at you.\r\n";

        private static Random rand = new Random();

        public string OpeningsLine()
        {
            return openingsLine;
        }

        public virtual void DefeatLine(string name)
        {            
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("You defeated " + name);
            Console.BackgroundColor = ConsoleColor.Black;            
        }

        public Enemy(string name, int power, int health, int speed)
        {
            this.name = name;
            this.power = power;
            this.health = health;
            this.speed = speed;
        }

        public virtual void DamageTaken(int damage)
        {
            health -= damage;
            // health < 0 death
            // 
        }
        public virtual string DamageDealt(int damage, Player currentPlayer, string n)
        {
            currentPlayer.health -= damage;
            return "The "+n+" deals: " + damage + " damage.";
        }
        public bool IsAlive()
        {
            return health > 0;
        }

        public virtual string Status()
        {
            if (health < 0) 
                health = 0; 
            return name + " health: " + health + " Power: " + power + " speed:" + speed;
        }

        public static Enemy CreateRandomEnemy(Player p)
        {
            Enemy randomE = new Enemy(Names.GetName(), GetStatsP(p), GetStatsH(p), GetStatsSpeed(p));
            randomE.openingsLine = "You turn the corner and encounter a monster.\r\n";
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
        private static int GetStatsSpeed(Player currentPlayer)
        {
            //voor de health stat
            int upper = 2 * currentPlayer.mods + 6;
            int lower = currentPlayer.mods + 1;
            return rand.Next(lower, upper);
        }
        public virtual void GetCoins(string name, Player currentPlayer)
        {
            int lower = 10 + (25 * currentPlayer.mods);
            int upper = 50 + (25 * currentPlayer.mods);
            int c = rand.Next(lower, upper);
            currentPlayer.coins += c;
            Console.WriteLine("When you defeated the " + name + " his body turns in to a sack of gold!");
            Console.WriteLine("you gain: " + c + " gold.");
        }

        public virtual void GetXP(Player currentPlayer)
        {
            // creates xp variable
            int lower = (10 + (25 * currentPlayer.mods));
            int upper = (30 + (25 * currentPlayer.mods));
            int xp = rand.Next(lower, upper);

            // adds xp
            Console.WriteLine("You gain: " + xp + " XP");
            currentPlayer.XP += xp;
            LevelUp(currentPlayer);
        
        }

        public void LevelUp(Player currentPlayer)
        {
            int levelUp = currentPlayer.levelUpXp - currentPlayer.XP;
            if (levelUp < 0)
                levelUp = 0;
            // checks for level up
            if (levelUp == 0)
            {
                //level up
                currentPlayer.currentLevel++;
                Console.WriteLine("Level up you are now level: " + currentPlayer.currentLevel);

                // new level up xp
                currentPlayer.XP -= currentPlayer.levelUpXp;
                currentPlayer.levelUpXp = Convert.ToInt32(100 * (Math.Pow(1.2, currentPlayer.currentLevel)));                
                currentPlayer.skillpoints += 3;
                Console.WriteLine("Ammount of skill points: " + currentPlayer.skillpoints);
                LevelUp(currentPlayer);
            }
            else
                Console.WriteLine("Xp to level up: " + levelUp + " XP");
        }
    }
}
