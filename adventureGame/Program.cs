using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace AdventureGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("saves"))
                Directory.CreateDirectory("saves");

            Game g = null;
            Console.WriteLine("(N) Do you want a new game.");
            Console.WriteLine("(S) Do you want to continue a saved game;");
            string cont = Console.ReadLine().ToLower();
            if (cont == "n")
            {
                g = new Game();                
            }
            else if (cont == "s")
            {
                // of een bestaand spel inladen
                Console.WriteLine("give te name of the player.");
                Console.WriteLine("!Warning this is not capital sensitive.");
                g = Game.load(Console.ReadLine().ToLower());
            }
            g.Start(cont);
            // Start();
        }
    }
}