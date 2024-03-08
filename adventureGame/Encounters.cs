using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Encounters
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
            Console.WriteLine("You turn the corner and encounter a monster.");
            Console.ReadKey();
            Combat.Battle(true, "", 0, 0);
        }
        public static void mageEncounter()
        {
            Console.WriteLine("As you find a white door that shines bright you go and open it.");
            Console.WriteLine("it is a mage but it looks like he's being controlled by a other being");
            Console.WriteLine("You almost have no time to react but het attacks.");
            Combat.Battle(false, "Possessed mage", 5, 12);
            Console.WriteLine("As you defeated the otherworldly being leaves his body.");
            Console.WriteLine("Before he breathe's his last breath he thanks you for defeating him");
            Console.WriteLine("And warns you for the Labyrinth of Shadows");
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
