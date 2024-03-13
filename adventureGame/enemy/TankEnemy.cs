using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.enemy
{

    public class TankEnemy : Enemy
    {

        public int armor = 0;
        public TankEnemy(int power = 1, int health = 12, int armor = 2) : base("", power, health)
        {
            this.name = "Armoured Beast";
            this.armor = armor;
        }

        public string OpeningsLine()
        {
            return "As you strumble to the labrint you take a look around the corner.\r\n " +
                    "You find an armored beast.\r\n" +
                    "This enemy has armor and you need to take his armor out before you can damage him.\r\n";
        }
        public new void DamageTaken(int damage)
        {
            damage -= armor ;
            if (damage < 0)
            {
                base.DamageTaken(damage);
            }
        }
        public new string Status()
        {
            return base.Status() + " armor: " + armor;
        }

    }
}
