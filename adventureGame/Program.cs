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
            //wil  je een nieuw spel.
            if (1 == 1)
            {
                g = new Game();
                // of een bestaand spel inladen
            }
            else
            {
                g = Game.load(Console.ReadLine());
            }
            g.Start();
            // Start();


        }
    }
}
