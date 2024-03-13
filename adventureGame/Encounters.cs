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
            Enemy e = new Enemy("Goblin", 2, 4);
            Console.WriteLine(e.OpeningsLine());

            Console.ReadKey();
            Console.Clear();

            c.Battle2(e);
        }
        public  void basicEncounter()
        {            
          
            Combat c = new Combat(p);
            Enemy re = Enemy.CreateRandomEnemy(p);
            Console.WriteLine(re.OpeningsLine()) ;
            Console.ReadKey();

            c.Battle2(re);                        
        }
        //custom encounters
        public  void mageEncounter()
        {
            Console.WriteLine("As you find a white door that shines bright you go and open it.");
            Console.WriteLine("it is a mage but it looks like he's being controlled by a other being");
            Console.WriteLine("You almost have no time to react but het attacks.");
            Combat c = new Combat(p);
            Enemy e = new Enemy("Possessed mage", 5, 8);
            c.Battle2(e);
            Console.WriteLine("As you defeated the otherworldly being leaves his body.");
            Console.WriteLine("Before he breathe's his last breath he thanks you for defeating him");
            Console.WriteLine("And warns you for the Labyrinth of Shadows");
        }

        public  void TankEnemy()
        {
            Combat c = new Combat(p);
            TankEnemy e = new TankEnemy();

            Console.WriteLine(e.OpeningsLine());

            c.Battle2(e);

        }

        public  void BlitzEnemy()
        {
            Console.WriteLine("You drop down the stairs and you see a ");
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
