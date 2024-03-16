using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.enemy;

namespace AdventureGame
{
    public class Encounters
    {
       
        public Random rand = new Random();
        // Encounter Generic

        public Player p = null;
        // First encounter
        public  void FirstEncounter()
        {
            Combat c = new Combat(p);
            Enemy e = new Enemy("Goblin", 2, 4, 3);
            Console.WriteLine(e.OpeningsLine());

            Console.ReadKey();
            Console.Clear();

            c.battle(e);
        }
        public  void basicEncounter()
        {            
          
            Combat c = new Combat(p);
            Enemy re = Enemy.CreateRandomEnemy(p);
            Console.WriteLine(re.OpeningsLine()) ;
            Console.ReadKey();

            c.battle(re);                        
        }
        //custom encounters
        public  void mageEncounter()
        {
            Console.WriteLine("As you find a white door that shines bright you go and open it.");
            Console.WriteLine("it is a mage but it looks like he's being controlled by a other being");
            Console.WriteLine("You almost have no time to react but het attacks.");
            Combat c = new Combat(p);
            Enemy e = new Enemy("Possessed mage", 5, 8, 5);
            c.battle(e);
            Console.WriteLine("As you defeated the otherworldly being leaves his body.");
            Console.WriteLine("Before he breathe's his last breath he thanks you for defeating him");
            Console.WriteLine("And warns you for the Labyrinth of Shadows");
        }

        public void TankEnemy()
        {            
            TankEnemy e = new TankEnemy();
            Combat c = new Combat(p);
            Console.WriteLine(e.OpeningsLine());

            Console.ReadKey();
            Console.Clear();

            c.battle(e);
        }

        public  void BlitzEnemy()
        {
            BlitzEnemy e = new BlitzEnemy();
            Combat c = new Combat(p);
            Console.WriteLine(e.OpeningsLine());

            Console.ReadKey();
            Console.Clear();

            c.battle(e);
        }

        public void PolymorphEnemy()
        {
            PolymorphEnemy e = new PolymorphEnemy();
            Combat c = new Combat(p);
            Console.WriteLine(e.OpeningsLine());

            Console.ReadKey();
            Console.Clear();

            c.battle(e);
        }





        // Encounter Tools
        public  void randomEncounter()
        {
            switch(rand.Next(0,1))
            {
                case 0:
                    basicEncounter();
                    break;
            }
        }

       

       
    }
}
