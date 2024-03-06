using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Encounters
    {
        // Encounter Generic
        

        // Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You open the first door you see.");
            Console.WriteLine("There you find a wooden sword.");
            Console.WriteLine("while a monster comes charging at you.");
            Console.ReadKey();
            Console.Clear();
        }

        // Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h>0)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (B)efend |");
                Console.WriteLine("| (R)un    (H)eal   |";
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " +Program.currentPlayer.potion+"  Health: " +Program.currentPlayer.health);
                string temp = Console.ReadLine();
            }
        }
    }
}
