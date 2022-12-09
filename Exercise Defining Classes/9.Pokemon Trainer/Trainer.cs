using PokemonTrainer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public static Dictionary<string,Trainer> trainers = new Dictionary<string, Trainer>();
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> pokemons { get; set; }
        public Trainer(string Name)
        {
            this.Name = Name;
            this.Badges = 0;
            this.pokemons = new List<Pokemon>();
        }
    }
}
