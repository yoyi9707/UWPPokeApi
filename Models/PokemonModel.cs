using System.Collections.Generic;

namespace Ejercicio.Models
{
    public class PokemonModel: PropertyChangedNotification
    {
        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }
        public int BaseExperience
        {
            get { return GetValue(() => BaseExperience); }
            set { SetValue(() => BaseExperience, value); }
        }
        public int Height
        {
            get { return GetValue(() => Height); }
            set { SetValue(() => Height, value); }
        }
        public int Weight
        {
            get { return GetValue(() => Weight); }
            set { SetValue(() => Weight, value); }
        }
        public int Attack
        {
            get { return GetValue(() => Attack); }
            set { SetValue(() => Attack, value); }
        }
        public int Defense
        {
            get { return GetValue(() => Defense); }
            set { SetValue(() => Defense, value); }
        }
        public int SpecialAttack
        {
            get { return GetValue(() => SpecialAttack); }
            set { SetValue(() => SpecialAttack, value); }
        }
        public int SpecialDefense
        {
            get { return GetValue(() => SpecialDefense); }
            set { SetValue(() => SpecialDefense, value); }
        }
        public int Speed
        {
            get { return GetValue(() => Speed); }
            set { SetValue(() => Speed, value); }
        }
        public int HP
        {
            get { return GetValue(() => HP); }
            set { SetValue(() => HP, value); }
        }

        public List<Move> ListMoves
        {
            get { return GetValue(() => ListMoves); }
            set { SetValue(() => ListMoves, value); }
        }
        public List<PokemonModel> ListPokemons 
        {
            get { return GetValue(() => ListPokemons);} 
            set { SetValue(() => ListPokemons, value); }
        }
        public int ActualPage
        {
            get { return GetValue(() => ActualPage); }
            set { SetValue(() => ActualPage, value); }
        }
        public int TotalPages
        {
            get { return GetValue(() => TotalPages); }
            set { SetValue(() => TotalPages, value); }
        }

        private static PokemonModel selectedPokemon;

        public PokemonModel SelectedPokemon
        {
            get { return selectedPokemon; }
            set { selectedPokemon = value;}
        }
    }
}
