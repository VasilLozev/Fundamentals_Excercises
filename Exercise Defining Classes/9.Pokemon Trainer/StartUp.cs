using PokemonTrainer;
using System;
using System.Data;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Tournament")
                {
                    break;
                }

                string[] input = command.Split(' ');

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (!Trainer.trainers.ContainsKey(trainerName))
                {
                    Trainer.trainers.Add(trainerName, new Trainer(trainerName));
                }
                Trainer.trainers[trainerName].pokemons.Add(pokemon);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command == "Fire")
                {
                    foreach (var trainer in Trainer.trainers)
                    {
                        if (trainer.Value.pokemons.Any(x=>x.Element == "Fire"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Value.pokemons.Count; i++)
                            {
                                trainer.Value.pokemons[i].Health -= 10;
                                if (trainer.Value.pokemons[i].Health <= 0)
                                {
                                    trainer.Value.pokemons.Remove(trainer.Value.pokemons[i]);
                                }
                            }
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in Trainer.trainers)
                    {
                        if (trainer.Value.pokemons.Any(x => x.Element == "Water"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Value.pokemons.Count; i++)
                            {
                                trainer.Value.pokemons[i].Health -= 10;
                                if (trainer.Value.pokemons[i].Health <= 0)
                                {
                                    trainer.Value.pokemons.Remove(trainer.Value.pokemons[i]);
                                }
                            }
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    foreach (var trainer in Trainer.trainers)
                    {
                        if (trainer.Value.pokemons.Any(x => x.Element == "Electricity"))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Value.pokemons.Count; i++)
                            {
                                trainer.Value.pokemons[i].Health -= 10;
                                if (trainer.Value.pokemons[i].Health <= 0)
                                {
                                    trainer.Value.pokemons.Remove(trainer.Value.pokemons[i]);
                                }
                            }
                        }
                    }
                }
            }
            Trainer.trainers = Trainer.trainers.OrderByDescending(x => x.Value.Badges).ToDictionary(x=>x.Key, x=>x.Value);
            foreach (var trainer in Trainer.trainers)
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.Badges} {trainer.Value.pokemons.Count}");
            }
        }
    }
}
