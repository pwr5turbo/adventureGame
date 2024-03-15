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

        public BlitzEnemy(int power = 3, int health = 25, int numberMoves = 3) : base("", power, health)
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
        public string DefeatLine()
        {
            return "You defeated the Armoured Beast. \r\n" +
                   "You went a floor up \r\n" +
                   "You are now on floor 6 \r\n" +
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
    }
}
