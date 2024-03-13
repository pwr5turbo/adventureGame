using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.enemy;

namespace AdventureGame
{
    internal class Combat
    {
        private Shop s = null;
        private Random rand = new Random();

        Player currentPlayer = null;

        public Combat(Player p )
        {
            currentPlayer = p;
            s = new Shop(currentPlayer);
        }
        private int GetStatsP()
        {
            // voor de power stat
            int upper = (2 * currentPlayer.mods + 4);
            int lower = (currentPlayer.mods + 1);
            return rand.Next(lower, upper);
        }
        private int GetStatsH()
        {
            //voor de health stat
            int upper = (2 * currentPlayer.mods + 6);
            int lower = (currentPlayer.mods + 1);
            return rand.Next(lower, upper);
        }
        private void GetCoins(string name)
        {
            int lower = 10 + (10 * currentPlayer.mods);
            int upper = 50 + (10 * currentPlayer.mods);
            int c = rand.Next(lower, upper);
            currentPlayer.coins += c;
            Console.WriteLine("When you defeated the " + name + " his body turns in to a sack of gold!");
            Console.WriteLine("you gain: " + c + " gold.");
        }
        private  void GetXP()
        {
            // creates xp variable
            int lower = (10 + (10 * currentPlayer.mods));
            int upper = (30 + (10 * currentPlayer.mods));
            int xp = rand.Next(lower, upper);

            // adds xp
            Console.WriteLine("You gain: " + xp + " XP");
            currentPlayer.levelUpXp -= xp;

            // checks for level up
            if (currentPlayer.levelUpXp <= 0)
            {
                currentPlayer.currentLevel++;
                Console.WriteLine("Level up you are now level: " + currentPlayer.currentLevel);
                currentPlayer.levelUpXp += Convert.ToInt32(100 * (Math.Pow(1.2, currentPlayer.currentLevel)));
                currentPlayer.skillpoints += 3;
                Console.WriteLine("Ammount of skill points: " + currentPlayer.skillpoints);
                Console.WriteLine("Ammount of XP for next level up: " + currentPlayer.levelUpXp + " XP");
            }
            else
                Console.WriteLine("Xp to level up: " + currentPlayer.levelUpXp + " XP");
        }
        private int playerAttack()
        {
            int armor = currentPlayer.armorValue;
            int weapon = currentPlayer.weaponValue;
            int Pdamage = currentPlayer.playerDamage;

            int attack = rand.Next(currentPlayer.weaponValue / 2, currentPlayer.weaponValue + 1) + rand.Next(currentPlayer.damage / 1, currentPlayer.damage + 2);
            if (attack == 0)
                attack = 1;
            return attack;
        }
        private int damage(int power)
        {
            int damage = power - rand.Next((currentPlayer.armorValue / 2), currentPlayer.armorValue);
            if (damage < 0)
                damage = 0;
            return damage;
        }
        public  void Battle(bool random, string name, int power, int health, int armor)
        {
           

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
                Console.WriteLine("Potions: " + currentPlayer.potion + "  Health: " + currentPlayer.health);
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("You attack!");
                    Console.WriteLine("You lose " + Damage + " health and deal " + attack + " damage");

                    currentPlayer.health -= Damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You defend!");
                    Console.WriteLine("You lose " + Damage / 2 + " health and deal " + attack / 2 + " damage");

                    currentPlayer.health -= Damage / 2;
                    h -= attack / 2;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        currentPlayer.health -= Damage;

                        Console.WriteLine("As you try to run away " + n + " strikes you!");
                        Console.WriteLine("You lose " + Damage + " healt and are unable to escape!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Succesfully escape the " + n + "!");
                        Console.ReadKey();
                        s.runShop();
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You don't have any potions");
                        Console.WriteLine(n + "attacks you while you try to find a potion.");
                        Console.WriteLine(n + "deals: " + Damage);
                        currentPlayer.health -= Damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        int potionv = 5;
                        if (currentPlayer.health + potionv > currentPlayer.maxHealth)
                        {
                            int aboveMaxHealth = currentPlayer.health + potionv - currentPlayer.maxHealth;
                            potionv -= aboveMaxHealth;
                            Console.WriteLine("Your max health is reached you gain: " + potionv + "HP");
                            currentPlayer.health = currentPlayer.maxHealth;
                            currentPlayer.potion -= 1;
                        }
                        else
                        {
                            Console.WriteLine("You Heal " + potionv + " HP");
                            currentPlayer.health += potionv;
                            currentPlayer.potion -= 1;
                            Console.ReadKey();
                        }

                        currentPlayer.health -= Damage / 2;
                        Console.WriteLine(n + " Attacks you while you are healing.");
                        Console.WriteLine("You lose " + Damage / 2 + " health.");

                        Console.ReadKey();
                    }
                }
                if (currentPlayer.health <= 0)
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
            currentPlayer.monsterSlays++;
            Console.ReadKey();

            Console.Clear();
            GetCoins(n);
            GetXP();

            Console.WriteLine("Press (S) to go to store.");
            string inputStore = Console.ReadLine().ToLower();
            if (inputStore == "s")
            {
                s.runShop();
            }
            else
                Console.Clear();
        }
        
        public void Battle2(Enemy e)
        {
            
            while (e.IsAlive() )
            {
                int Damage = damage(e.power);
                int attack = playerAttack();

                Console.Clear();
                Console.WriteLine(e.Status());
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("Potions: " + currentPlayer.potion + "  Health: " + currentPlayer.health);
                string input = Console.ReadLine();

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //attack
                    Console.WriteLine("You attack!");
                    Console.WriteLine("You lose " + Damage + " health and deal " + attack + " damage");

                    currentPlayer.health -= Damage;
                    e.DamageTaken(attack) ;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You defend!");
                    Console.WriteLine("You lose " + Damage / 2 + " health and deal " + attack / 2 + " damage");

                    currentPlayer.health -= Damage / 2;
                    e.DamageTaken( attack / 2);
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    if (rand.Next(0, 2) == 0)
                    {
                        currentPlayer.health -= Damage;

                        Console.WriteLine("As you try to run away " + e.name + " strikes you!");
                        Console.WriteLine("You lose " + Damage + " healt and are unable to escape!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Succesfully escape the " + e.name + "!");
                        Console.ReadKey();
                        s.runShop();
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //heal
                    if (currentPlayer.potion == 0)
                    {
                        Console.WriteLine("You don't have any potions");
                        Console.WriteLine(e.name + "attacks you while you try to find a potion.");
                        Console.WriteLine(e.name + "deals: " + Damage);
                        currentPlayer.health -= Damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        int potionv = 5;
                        if (currentPlayer.health + potionv > currentPlayer.maxHealth)
                        {
                            int aboveMaxHealth = currentPlayer.health + potionv - currentPlayer.maxHealth;
                            potionv -= aboveMaxHealth;
                            Console.WriteLine("Your max health is reached you gain: " + potionv + "HP");
                            currentPlayer.health = currentPlayer.maxHealth;
                            currentPlayer.potion -= 1;
                        }
                        else
                        {
                            Console.WriteLine("You Heal " + potionv + " HP");
                            currentPlayer.health += potionv;
                            currentPlayer.potion -= 1;
                            Console.ReadKey();
                        }

                        currentPlayer.health -= Damage / 2;
                        Console.WriteLine(e.name + " Attacks you while you are healing.");
                        Console.WriteLine("You lose " + Damage / 2 + " health.");

                        Console.ReadKey();
                    }
                }
                if (currentPlayer.health <= 0)
                {
                    // death code
                    Console.Clear();
                    Console.WriteLine("As the " + e.name + " hits your hearth you breathe your last breath and die.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("You defeated " + e.name);
            Console.BackgroundColor = ConsoleColor.Black;
            currentPlayer.monsterSlays++;
            Console.ReadKey();

            Console.Clear();
            GetCoins(e.name);
            GetXP();

            Console.WriteLine("Press (S) to go to store.");
            string inputStore = Console.ReadLine().ToLower();
            if (inputStore == "s")
            {
                s.runShop();
            }
            else
                Console.Clear();
        }
    }
}


