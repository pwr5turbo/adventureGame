using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            runShop(p);
        }

        public static void runShop(Player p)
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + (10 * p.mods);
                armorP = 100 * (p.armorValue + 1);
                weaponP = 100 * p.weaponValue;
                difP = 300 + (100 * p.mods);


                Console.Clear();
                Console.WriteLine("        Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("|  (W)eapon:     $" + weaponP);
                Console.WriteLine("|  (A)rmor:      $" + armorP);
                Console.WriteLine("|  (P)otion:     $" + potionP);
                Console.WriteLine("|  (F)loor up:   $" + difP);
                Console.WriteLine("|  (E)xit");
                Console.WriteLine("=======================");
                Console.WriteLine("Coins       : " + p.coins);
                Console.WriteLine("Skill points: " + p.skillpoints + "\n");

                Console.WriteLine("        Stats        ");
                Console.WriteLine("=======================");
                Console.WriteLine("|  current Health: " + p.health);
                Console.WriteLine("|  (H)Max Health : " + p.maxHealth);
                Console.WriteLine("|  (D)amage value: " + p.playerDamage);
                Console.WriteLine("|  Weapon   value: " + p.weaponValue);
                Console.WriteLine("|  Armor    value: " + p.armorValue);
                Console.WriteLine("|  Potion   value: " + p.potion);
                Console.WriteLine("|  Current  floor: " + p.mods);
                Console.WriteLine("|  Monster  kills: " + p.monsterSlays);
                Console.WriteLine("=======================");
                
                //wait for input
                string input = Console.ReadLine().ToLower();

                if (input == "w" || input == "weapon")
                {
                    tryBuy("weapon", weaponP, p);
                    Console.WriteLine("You bought a new weapon current coins: " + p.coins);
                }
                else if (input == "a" || input == "armor")
                {
                    tryBuy("armor", armorP, p);
                    Console.WriteLine("You bought new armor current coins: " + p.coins);
                }
                else if (input == "p" || input == "potion")
                {
                    tryBuy("potion", potionP, p);
                    Console.WriteLine("You bought a potion current coins: " + p.coins);
                }
                else if (input == "f" || input == "floor up")
                {
                    tryBuy("dif", difP, p);
                    Console.WriteLine("You bought a key to the next floor current coins: " + p.coins);
                }
                else if (input == "h" || input == "health")
                {
                    tryUpgrade("health", 1, p);
                    Console.WriteLine("You bought a new weapon current coins: " + p.coins);
                }
                else if (input == "d" || input == "damage")
                {
                    tryUpgrade("damage", 1, p);
                    Console.WriteLine("You bought a new weapon current coins: " + p.coins);
                }
                else if (input == "e" || input == "exit")
                    break;

                static void tryBuy(string item, int cost, Player p)
                {
                    if (p.coins >= cost)
                    {
                        if (item == "potion")
                            p.potion++;
                        else if (item == "weapon")
                            p.weaponValue++;
                        else if (item == "armor")
                            p.armorValue++;
                        else if (item == "dif")
                            p.mods++;

                        p.coins -= cost;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough coins to buy this.");
                        Console.ReadKey();
                    }
                }
                static void tryUpgrade(string skill, int skillcost, Player p)
                {
                    if (p.skillpoints >= 1)
                    {
                        if (skill == "health")
                        {
                            p.maxHealth++;
                            p.health++;
                        }                            
                        else if (skill == "damage")
                            p.playerDamage++;

                        p.skillpoints -= 1;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough skillpoints to upgrade this.");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}

