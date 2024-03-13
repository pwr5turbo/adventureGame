using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventureGame
{
    internal class Combat
    {
        static Random rand = new Random();
        public static void Battle(bool random, string name, int power, int health, int armor)
        {
            static int GetStatsP()
            {
                // voor de power stat
                int upper = (2 * Program.currentPlayer.mods + 4);
                int lower = (Program.currentPlayer.mods + 1);
                return rand.Next(lower, upper);
            }
            static int GetStatsH()
            {
                //voor de health stat
                int upper = (2 * Program.currentPlayer.mods + 6);
                int lower = (Program.currentPlayer.mods + 1);
                return rand.Next(lower, upper);
            }
            static void GetCoins(string name)
            {
                int lower = 10 + (10 * Program.currentPlayer.mods);
                int upper = 50 + (10 * Program.currentPlayer.mods);
                int c = rand.Next(lower, upper);
                Program.currentPlayer.coins += c;
                Console.WriteLine("When you defeated the " + name + " his body turns in to a sack of gold!");
                Console.WriteLine("you gain: " + c + " gold.");
            }
            static void GetXP()
            {
                // creates xp variable
                int lower = (10 + (10 * Program.currentPlayer.mods));
                int upper = (30 + (10 * Program.currentPlayer.mods));
                int xp = rand.Next(lower, upper);

                // adds xp
                Console.WriteLine("You gain: " + xp + " XP");
                Program.currentPlayer.levelUpXp -= xp;
                
                // checks for level up
                if (Program.currentPlayer.levelUpXp <= 0)
                {
                    Program.currentPlayer.currentLevel++;
                    Console.WriteLine("Level up you are now level: " + Program.currentPlayer.currentLevel);
                    Program.currentPlayer.levelUpXp += Convert.ToInt32(100 * (Math.Pow(1.2, Program.currentPlayer.currentLevel)));
                    Program.currentPlayer.skillpoints += 3;
                    Console.WriteLine("Ammount of skill points: " + Program.currentPlayer.skillpoints);
                    Console.WriteLine("Ammount of XP for next level up: " + Program.currentPlayer.levelUpXp + " XP");
                }
                else
                    Console.WriteLine("Xp to level up: " + Program.currentPlayer.levelUpXp + " XP");
            }

            static int playerAttack()
            {
                int armor = Program.currentPlayer.armorValue;
                int weapon = Program.currentPlayer.weaponValue;
                int Pdamage = Program.currentPlayer.playerDamage;
                                
                int attack = rand.Next(Program.currentPlayer.weaponValue / 2, Program.currentPlayer.weaponValue + 1) + rand.Next(Program.currentPlayer.damage / 1,Program.currentPlayer.damage + 2);
                if (attack == 0)
                    attack = 1;
                return attack;  
            }

            static int damage(int power)
            {
                int damage = power - rand.Next((Program.currentPlayer.armorValue/2), Program.currentPlayer.armorValue);
                if (damage < 0)
                    damage = 0;
                return damage;
            }

            string n = "";
            int p = 0;
            int h = 0;
            int a = 0;
            if (random)
            {
                n = Names.GetName();
                p = GetStatsP();
                h = GetStatsH();
                a = 0;
            }
            else
            {
                n = name;
                p = power;
                h = health;
                a = armor;
            }
            while (h > 0)
            {
                int Damage = damage(p);
                int attack = playerAttack();

                Console.Clear();
                Console.WriteLine(n + " health: " + h + " Power: " + p);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + "  Health: " + Program.currentPlayer.health);
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("You attack!");
                    Console.WriteLine("You lose " + Damage + " health and deal " + attack + " damage");

                    Program.currentPlayer.health -= Damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You defend!");
                    Console.WriteLine("You lose " + Damage / 2 + " health and deal " + attack / 2 + " damage");

                    Program.currentPlayer.health -= Damage / 2;
                    h -= attack / 2;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        Program.currentPlayer.health -= Damage;

                        Console.WriteLine("As you try to run away " + n + " strikes you!");
                        Console.WriteLine("You lose " + Damage + " healt and are unable to escape!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Succesfully escape the " + n + "!");
                        Console.ReadKey();
                        Shop.loadShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You don't have any potions");
                        Console.WriteLine(n + "attacks you while you try to find a potion.");
                        Console.WriteLine(n + "deals: " + Damage);
                        Program.currentPlayer.health -= Damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        int potionv = 5;
                        if (Program.currentPlayer.health + potionv > Program.currentPlayer.maxHealth)
                        {
                            int aboveMaxHealth = Program.currentPlayer.health + potionv - Program.currentPlayer.maxHealth;
                            potionv -= aboveMaxHealth;
                            Console.WriteLine("Your max health is reached you gain: " + potionv + "HP");
                            Program.currentPlayer.health = Program.currentPlayer.maxHealth;
                            Program.currentPlayer.potion -= 1;
                        }
                        else
                        {
                            Console.WriteLine("You Heal " + potionv + " HP");
                            Program.currentPlayer.health += potionv;
                            Program.currentPlayer.potion -= 1;
                            Console.ReadKey();
                        }

                        Program.currentPlayer.health -= Damage / 2;
                        Console.WriteLine(n + " Attacks you while you are healing.");
                        Console.WriteLine("You lose " + Damage / 2 + " health.");

                        Console.ReadKey();
                    }
                }
                if (Program.currentPlayer.health <= 0)
                {
                    // death code
                    Console.Clear();
                    Console.WriteLine("As the " + n + " hits your hearth you breathe your last breath and die.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("You defeated " + n);
            Console.BackgroundColor = ConsoleColor.Black;
            Program.currentPlayer.monsterSlays++;
            Console.ReadKey();

            Console.Clear();
            GetCoins(n);
            GetXP();

            Console.WriteLine("Press (S) to go to store.");
            string inputStore = Console.ReadLine().ToLower();
            if (inputStore == "s")
                Shop.loadShop(Program.currentPlayer);
            else
                Console.Clear();
        }
    }
}
