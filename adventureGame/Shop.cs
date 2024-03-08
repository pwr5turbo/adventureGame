using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Shop
    {
        static int armorMod;
        static int weaponMod;
        static int difMod;

        public static void loadShop(Player p)
        {
            armorMod = p.armorValue;
            weaponMod = p.weaponValue;
            difMod = p.mods;
        }
    }
}
