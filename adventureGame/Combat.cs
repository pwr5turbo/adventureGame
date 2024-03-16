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

        private void FightInfo(Enemy e)
        {
            Console.ReadKey();            
            Console.WriteLine(e.Status());
            Console.WriteLine("Potions: " + currentPlayer.potion + "  Health: " + currentPlayer.health);
            Console.ReadKey();
        }

        private void DeathCheckPlayer(string name)
        {            
            if (currentPlayer.health <= 0)
            {
                // death code
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("As the " + name + " hits your hearth you breathe your last breath and die.");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
        }    
                
        public void battle(Enemy e)
        {            
            while (e.IsAlive() )
            {
                int Damage = damage(e.power);
                int speed = 1;
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
                    if(currentPlayer.playerSpeed >= speed)
                    {
                        // Player attacks first
                        Console.Clear();
                        Console.WriteLine("You strike first!");
                        e.DamageTaken(attack);
                        Console.WriteLine("You deal: " + attack + " damage");                        
                        FightInfo(e);
                        if (!e.IsAlive())
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine(e.DamageDealt(Damage, currentPlayer, e.name));
                        DeathCheckPlayer(e.name);
                    }
                    else
                    {
                        //monster attacks first
                        Console.Clear();
                        Console.WriteLine(e.DamageDealt(Damage, currentPlayer, e.name));
                        DeathCheckPlayer(e.name);

                        FightInfo(e);

                        Console.WriteLine("You strike at last!");
                        e.DamageTaken(attack);
                        Console.WriteLine("You deal: " + attack + " damage");                        
                    }                                       
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //defend
                    Console.WriteLine("You defend!");
                    Console.WriteLine(e.DamageDealt(Damage / 2, currentPlayer, e.name));
                    DeathCheckPlayer(e.name);
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
                        Console.WriteLine("You lose: " + Damage + " healt and are unable to escape!");
                        DeathCheckPlayer(e.name);
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
                        DeathCheckPlayer(e.name);

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
                        DeathCheckPlayer(e.name);
                        Console.ReadKey();
                    }
                }                
            }
            Console.Clear();
            e.DefeatLine(e.name);
            currentPlayer.monsterSlays++;
            Console.ReadKey();
            Console.Clear();
            e.GetCoins(e.name, currentPlayer);
            e.GetXP(currentPlayer);

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


