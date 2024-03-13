using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AdventureGame
{
    public class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args) 
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            Start();
            Encounters.FirstEncounter();
            while (mainLoop)
            {
                Encounters.randomEncounter();
            }
        }


        static void Start()
        {
            do
            {
                Console.WriteLine("Labyrinth of Shadows!");
                Console.WriteLine("What is your name: ");
                currentPlayer.name = Console.ReadLine();
                if (currentPlayer.name == "")
                    Console.Clear();
            } while (currentPlayer.name == "");
            Console.Clear();

            Console.WriteLine("In the heart of the ancient realm of Eldoria, lies the fabled Labyrinth of Shadows, " +
                "a sprawling maze rumored to hold untold treasures and dark secrets. For centuries, brave adventurers " +
                "and foolhardy souls alike have sought to plunder its depths, but few have returned to tell the tale.\n");
            
            Console.WriteLine("Legends speak of a powerful artifact hidden within its twisting passages, a relic said to " +
                "grant unimaginable power to whoever possesses it. But the labyrinth is not easily conquered. Its halls " +
                "are filled with cunning traps, fearsome monsters, and the lingering whispers of those who have met their " +
                "demise within its walls.\n");

            Console.WriteLine("As the sun sets over the horizon, casting long shadows across the land, a new adventurer steps " +
                "forth to brave the challenges that lie ahead. Will you be the one to uncover the mysteries of the Labyrinth of " +
                "Shadows, or will you become just another lost soul, swallowed by its eternal darkness? The choice is yours... " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();
        }
        public static void save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Open("saves")
        }

        public static Player load()
        {

        }
    }
}
