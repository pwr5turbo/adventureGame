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
        private void GetCoins(string name)
        {
            int lower = 10 + (25 * currentPlayer.mods);
            int upper = 50 + (25 * currentPlayer.mods);
            int c = rand.Next(lower, upper);
            currentPlayer.coins += c;
            Console.WriteLine("When you defeated the " + name + " his body turns in to a sack of gold!");
            Console.WriteLine("you gain: " + c + " gold.");
        }
        private  void GetXP()
        {
            // creates xp variable
            int lower = (10 + (25 * currentPlayer.mods));
            int upper = (30 + (25 * currentPlayer.mods));
            int xp = rand.Next(lower, upper);

            // adds xp
            Console.WriteLine("You gain: " + xp + " XP");
            currentPlayer.levelUpXp -= xp;

            // checks for level up
            if (currentPlayer.levelUpXp <= 0)
            {
                currentPlayer.currentLevel++;
                Console.WriteLine("Level up you are now level: " + currentPlayer.currentLevel);
                currentPlayer.levelUpXp += Convert.ToInt32(250 * (Math.Pow(1.2, currentPlayer.currentLevel)));
                currentPlayer.skillpoints += 3;
                Console.WriteLine("Ammount of skill points: " + currentPlayer.skillpoints);
                Console.WriteLine("Ammount of XP for next level up: " + currentPlayer.levelUpXp + " XP");
            }
            else
                Console.WriteLine("Xp to level up: " + currentPlayer.levelUpXp + " XP");
        }
        private int playerAttack()
        {
            int minWeaponValue = currentPlayer.weaponValue / 2;
            int maxWeaponValue = currentPlayer.weaponValue + 1;
            int minDamage = currentPlayer.playerDamage / 2;
            int maxDamage = currentPlayer.playerDamage + 1;

            int attack = rand.Next(minWeaponValue + minDamage, maxWeaponValue + maxDamage);
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
        
        
        public void battle(Enemy e)
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
                    Console.WriteLine(e.DamageDealt(Damage, currentPlayer, e.name));
                    Console.WriteLine("You deal " + attack + " damage");
                    
                    e.DamageTaken(attack) ;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You defend!");
                    Console.WriteLine(e.DamageDealt(Damage / 2, currentPlayer, e.name));
                    Console.WriteLine("You deal: " + attack / 2 + " damage");
                    
                    e.DamageTaken( attack / 2);
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //run
                    int random = rand.Next(0, 2);
                    if (random == 0)
                    {          
                        Console.WriteLine("As you try to run away from the "+ e.name + " strikes you!");
                        Console.WriteLine(e.DamageDealt(Damage / 2, currentPlayer, e.name));
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
                        Console.WriteLine(e.DamageDealt(Damage / 2, currentPlayer, e.name));
                        
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
                                                
                        Console.WriteLine(e.name + " Attacks you while you are healing.");
                        Console.WriteLine(e.DamageDealt(Damage / 2, currentPlayer, e.name));

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


