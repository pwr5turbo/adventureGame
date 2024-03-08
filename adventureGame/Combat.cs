using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Combat
    {
        public static void Battle(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = Names.GetName();
                p = Program.currentPlayer.GetStatsP();
                h = Program.currentPlayer.GetStatsH();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
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
                    Console.WriteLine(n + "Attacks!");

                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");

                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine(n + "Defends!");
                    int damage = (p / 4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = (rand.Next(0, Program.currentPlayer.weaponValue + rand.Next(1, 4)) / 2);

                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage");

                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("As you try to run away " + n + " strikes you!");
                        Console.WriteLine("You lose " + damage + " healt and are unable to escape!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Succesfully escape the " + n + "!");
                        Console.ReadKey();
                        // go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You don't have any potions");
                        int damage = p + Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine(n + "attacks you while you try to find a potion.");
                    }
                    else
                    {
                        int potionv = 5;
                        Console.WriteLine("You Heal " + potionv + " health");
                        Program.currentPlayer.health += potionv;
                        Program.currentPlayer.potion -= 1;

                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine(n + " Attacks you while you are healing.");
                        Console.WriteLine("You lose " + damage + " health.");
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
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("You defeated " + n);
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            int c = rand.Next(10, 50);
            Program.currentPlayer.coins += c;
            Console.WriteLine("When you defeated the " + n + " his body turns in to a sack of gold!");
            Console.WriteLine("you gain: " + c + " gold.");
            Console.ReadKey();
        }
    }
}
