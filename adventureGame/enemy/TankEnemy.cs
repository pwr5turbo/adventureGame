using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.enemy
{
    public class TankEnemy : Enemy
    {
        public int Armor { get; private set; }

        public TankEnemy(int power = 1, int health = 25, int armor = 5) : base("", power, health)
        {
            this.name = "Armoured Beast";
            this.Armor = armor;
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
                   "You went a floor up \r\n"+
                   "You are now on floor 6 \r\n"+
                   Console.ReadKey();
                   

        }
        public override void DamageTaken(int damage)
        {
            int actualDamage = damage - Armor;
            if (actualDamage > 0)
            {
                base.DamageTaken(actualDamage);
            }
        }

        public override string Status()
        {
            return base.Status() + " armor: " + Armor;
        }
    }
}
