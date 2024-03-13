using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Encounters
    {
        static Random rand = new Random();
        // Encounter Generic
        

        // Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You open the first door you see a monster.");
            Console.WriteLine("While you pick up the wooden sword you just found the monster comes charging at you.");
            Console.ReadKey();
            Console.Clear();
            Combat.Battle(false, "Goblin", 2, 4);
        }
        public static void basicEncounter()
        {
            int randomEnc = rand.Next(1,12);
            if (randomEnc < 1)
            {
                Console.WriteLine("You turn the corner and encounter a monster.");
                Console.ReadKey();
                Combat.Battle(true, "", 0, 0);
            }
            else
            {
                int randMonster = rand.Next(1,4);
                switch (randMonster)
                {
                    case 1:
                        mageEncounter();
                    case 2:

                }
            }
        }
        //custom encounters
        public static void mageEncounter()
        {
            Console.WriteLine("As you find a white door that shines bright you go and open it.");
            Console.WriteLine("it is a mage but it looks like he's being controlled by a other being");
            Console.WriteLine("You almost have no time to react but het attacks.");
            Combat.Battle(false, "Possessed mage", 5, 8);
            Console.WriteLine("As you defeated the otherworldly being leaves his body.");
            Console.WriteLine("Before he breathe's his last breath he thanks you for defeating him");
            Console.WriteLine("And warns you for the Labyrinth of Shadows");
        }

        public static void TankEnemy()
        {
            Console.WriteLine("As you strumble to the labrint you take a look around the corner.");
            Console.WriteLine("You find an armored beast.");
            Console.WriteLine("This enemy has armor and you need to take his armor out before you can damage him.");
            Combat.Battle(false, "Armored beast", 12, 1, 2);
        }

        public static void BlitzEnemy()
        {
            Console.WriteLine("You drop down the stairs and you see a ");
        }





        // Encounter Tools
        public static void randomEncounter()
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
