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
        private Player currentPlayer = null;
        public Shop (Player p)
        {
            currentPlayer = p;
        }   
        public void runShop()
        {
            int potionP;
            int armorP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + (10 * currentPlayer.mods);
                armorP = 100 * (currentPlayer.armorValue);
                weaponP = 100 * currentPlayer.weaponValue;
                difP = 300 + (100 * currentPlayer.mods);

                Console.Clear();
                Console.WriteLine("        Shop         ");
                Console.WriteLine("=======================");
                Console.WriteLine("|  (W)eapon:     $" + weaponP);
                Console.WriteLine("|  (A)rmor:      $" + armorP);
                Console.WriteLine("|  (P)otion:     $" + potionP);
                Console.WriteLine("|  (F)loor up:   $" + difP);
                Console.WriteLine("|  (E)xit");
                Console.WriteLine("=======================");
                Console.WriteLine("Coins       : " + currentPlayer.coins);
                Console.WriteLine("Skill points: " + currentPlayer.skillpoints + "\n");

                Console.WriteLine("        Stats        ");
                Console.WriteLine("=======================");
                Console.WriteLine("|  current Health: " + currentPlayer.health);
                Console.WriteLine("|  (H)Max Health : " + currentPlayer.maxHealth);
                Console.WriteLine("|  (D)amage value: " + currentPlayer.playerDamage);
                Console.WriteLine("|  (S)peed  value: " + currentPlayer.playerSpeed);
                Console.WriteLine("|  Weapon   value: " + currentPlayer.weaponValue);
                Console.WriteLine("|  Armor    value: " + currentPlayer.armorValue);
                Console.WriteLine("|  Potion   value: " + currentPlayer.potion);
                Console.WriteLine("|  Current  floor: " + currentPlayer.mods);
                Console.WriteLine("|  Monster  kills: " + currentPlayer.monsterSlays);
                Console.WriteLine("=======================");
                
                //wait for input
                string input = Console.ReadLine().ToLower();

                if (input == "w" || input == "weapon")
                {
                    tryBuy("weapon", weaponP);
                    Console.WriteLine("You bought a new weapon current coins: " + currentPlayer.coins);
                    Console.ReadKey();
                }
                else if (input == "a" || input == "armor")
                {
                    tryBuy("armor", armorP);
                    Console.WriteLine("You bought new armor current coins: " + currentPlayer.coins);
                    Console.ReadKey();
                }
                else if (input == "p" || input == "potion")
                {
                    tryBuy("potion", potionP);
                    Console.WriteLine("You bought a potion current coins: " + currentPlayer.coins);
                    Console.ReadKey();
                }
                else if (input == "f" || input == "floor up")
                {
                    if(currentPlayer.mods == 4)
                    {
                        Console.WriteLine("do you want to upgrade floor up after this will come a boss battle.");                        
                        confirmFloor();
                        if (currentPlayer.mods == 5)
                            break;
                    }
                    else if (currentPlayer.mods == 9) 
                    {
                        Console.WriteLine("do you want to upgrade floor up after this will come a boss battle.");
                        confirmFloor();
                        if (currentPlayer.mods == 10)
                            break;
                    }
                    else if (currentPlayer.mods == 14)
                    {
                        Console.WriteLine("do you want to upgrade floor up after this will come a boss battle.");
                        confirmFloor();
                        if (currentPlayer.mods == 15)
                            break;
                    }
                    else
                    {
                        tryBuy("dif", difP);
                        Console.WriteLine("You bought a key to the next floor current coins: " + currentPlayer.coins);
                        Console.ReadKey();
                    }                    
                }
                else if (input == "h" || input == "health")
                {
                    tryUpgrade("health", 1);
                    Console.WriteLine("You upgraded a skill: " + currentPlayer.skillpoints);
                    Console.ReadKey();
                }
                else if (input == "d" || input == "damage")
                {
                    tryUpgrade("damage", 1);
                    Console.WriteLine("You upgraded a skill: " + currentPlayer.skillpoints);
                    Console.ReadKey();
                }
                else if (input == "s" || input == "speed")
                {
                    tryUpgrade("speed", 1);
                    Console.WriteLine("You upgraded a skill: " + currentPlayer.skillpoints);
                    Console.ReadKey();
                }
                else if (input == "e" || input == "exit")
                    break;

                
            }


        }
        private void tryBuy(string item, int cost)
        {
            if (currentPlayer.coins >= cost)
            {
                if (item == "potion")
                    currentPlayer.potion++;
                else if (item == "weapon")
                    currentPlayer.weaponValue++;
                else if (item == "armor")
                    currentPlayer.armorValue++;
                else if (item == "dif")
                    currentPlayer.mods++;

                currentPlayer.coins -= cost;
            }
            else
            {
                Console.WriteLine("You don't have enough coins to buy this.");
                Console.ReadKey();
            }
        }
        private void tryUpgrade(string skill, int skillcost)
        {
            if (currentPlayer.skillpoints >= 1)
            {
                if (skill == "health")
                {
                    currentPlayer.maxHealth++;
                    currentPlayer.health++;
                }
                else if (skill == "damage")
                    currentPlayer.playerDamage++;
                else if (skill == "speed")
                    currentPlayer.playerSpeed++;

                currentPlayer.skillpoints -= 1;
            }
            else
            {
                Console.WriteLine("You don't have enough skillpoints to upgrade this.");
                Console.ReadKey();
            }
        }
        private void confirmFloor()
        {
            int difP = 300 + (100 * currentPlayer.mods);

            Console.WriteLine("Press F to floor up");
            string confirm = Console.ReadLine();
            if (confirm == "f")
            {
                tryBuy("dif", difP);
                Console.WriteLine("You bought a key to the next floor current coins: " + currentPlayer.coins);
                Console.ReadKey();
            }
        }
    }
}

