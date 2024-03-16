using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.enemy
{
    public class BlitzEnemy : Enemy
    {
        public int numberMoves { get; private set; }

        public BlitzEnemy(int power = 3, int health = 25,int speed = 10 ,int numberMoves = 3) : base("", power, health, speed)
        {
            this.name = "Blitz beast";
            this.numberMoves = numberMoves;
        }
        public string OpeningsLine()
        {
            return "As you stumble into the labyrinth, you take a look around the corner.\r\n" +
                   "You find an armored beast.\r\n" +
                   "This enemy has armor, and you need to deplete it before you can damage him.\r\n";
        }
        public override void DefeatLine(string name)
        {
            Console.WriteLine("You defeated the Armoured Beast. \r\n" +
                   "You went a floor up \r\n" +
                   "You are now on floor 11 \r\n");
            Console.ReadKey();
        }

        public override string Status()
        {   
            return base.Status() + " Max moves: " + numberMoves;
        }

        public override string DamageDealt(int damage, Player currentPlayer, string n)
        {
            int actualDamage = 0;
            Random random = new Random();
            int rand = random.Next(1, numberMoves+1);
            for (int i = 0; i < rand; i++)
            {
                currentPlayer.health -= damage;
                actualDamage += damage;
            }            
            return "The blitzenemy attacks: "+rand + " times and deals: " + actualDamage;
        }

        public override void GetCoins(string name, Player currentPlayer)
        {
            int c = 1000;
            currentPlayer.coins += c;            
            Console.WriteLine("When you defeated the " + name + " his body turns in to a sack of gold!");
            Console.WriteLine("you gain: " + c + " gold.");
        }

        public override void GetXP(Player currentPlayer)
        {
            int xp = 1000;

            // adds xp
            Console.WriteLine("You gain: " + xp + " XP");
            currentPlayer.levelUpXp -= xp;

            // checks for level up
            if (currentPlayer.levelUpXp <= 0)
            {
                currentPlayer.currentLevel++;
                Console.WriteLine("Level up you are now level: " + currentPlayer.currentLevel);
                currentPlayer.levelUpXp += Convert.ToInt32(250 * (Math.Pow(1.2, currentPlayer.currentLevel)));
                currentPlayer.skillpoints += 3;
                Console.WriteLine("Ammount of skill points: " + currentPlayer.skillpoints);
                Console.WriteLine("Ammount of XP for next level up: " + currentPlayer.levelUpXp + " XP");
            }
            else
                Console.WriteLine("Xp to level up: " + currentPlayer.levelUpXp + " XP");
        }
    }
}
