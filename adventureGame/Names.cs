using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Names
    {
        static Random rand = new Random();
        public static string GetName()
        {
            switch (rand.Next(0, 21))
            {
                case 0:
                    return "Skeleton";
                case 1:
                    return "Goblin";
                case 2:
                    return "Orc";
                case 3:
                    return "Vampire";
                case 4:
                    return "Werewolf";
                case 5:
                    return "Troll";
                case 6:
                    return "Wraith";
                case 7:
                    return "Dwarf";
                case 8:
                    return "Harpy";
                case 9:
                    return "Minotaur";
                case 10:
                    return "Dragon";
                case 11:
                    return "Giant Spider";
                case 12:
                    return "Banshee";
                case 13:
                    return "Specter";
                case 14:
                    return "Gargoyle";
                case 15:
                    return "Hydra";
                case 16:
                    return "Chimera";
                case 17:
                    return "Manticore";
                case 18:
                    return "Basilisk";
                case 19:
                    return "Kraken";
                case 20:
                    return "Cyclops";
                default:
                    return "Goblin";
            }
        }
    }
}
