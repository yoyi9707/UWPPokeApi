using System.Collections.Generic;

namespace Ejercicio.Models
{
    public class PokemonResponse
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Base_experience { get; set; }
        public List<Stats> Stats { get; set; }
        public List<Moves> Moves { get; set; }

    }

    public class Stats
    {
        public int Base_stat { get; set; }
        public Stat Stat { get; set; }
    }

    public class Stat
    {
        public string Name { get; set; }
    }

    public class Moves
    {
        public Move Move { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
    }

}
