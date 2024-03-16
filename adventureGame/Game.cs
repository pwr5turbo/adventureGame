using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.enemy;

namespace AdventureGame
{
    public class Game
    {
        public  Player currentPlayer = null;
        public  bool mainLoop = true;
        public void Start()
        {
            do
            {
                Console.WriteLine("Labyrinth of Shadows!");
                Console.WriteLine("What is your name: ");
                currentPlayer = new Player();   
                currentPlayer.name = Console.ReadLine();
                currentPlayer.id = 2;

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

            Encounters e = new Encounters();
            e.p = currentPlayer;
            e.FirstEncounter();
            while (mainLoop)
            {
               
                if(currentPlayer.mods == 5)
                {
                    e.TankEnemy();
                    currentPlayer.mods++;
                }
                else if(currentPlayer.mods == 10)
                {
                    e.BlitzEnemy();                    
                    currentPlayer.mods++;
                }
                if (currentPlayer.mods == 15)
                {
                    e.PolymorphEnemy();                    
                    currentPlayer.mods++;
                }
                else
                {
                    e.randomEncounter();
                }
            }
        }

        public  void save()
        {
            // BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/game-" + currentPlayer.id.ToString() + ".json";
            //FileStream file = File.Open(path, FileMode.OpenOrCreate);

            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, json);
        }

        public  static Game load(string id)
        {
            string json = File.ReadAllText("saves/game-" + id + ".json");
            Game g = JsonConvert.DeserializeObject<Game>(json);
            return g;
        }
    }
}

