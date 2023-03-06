using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_cafe
{
    internal class Boisson
    {
        public string nom { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public Dictionary<string,int> doses { get; set; }

        public Boisson(string nom)
        {
            this.nom = nom;
            this.ingredients = new List<Ingredient>();
            this.doses = new Dictionary<string, int>();
        }

        public bool addIngredient(Ingredient new_ingredient,int dose)
        {
            foreach(Ingredient ingredient in this.ingredients)
            {
                if(ingredient.nom.ToLower().Equals(new_ingredient.nom.ToLower()))
                {
                    return false;
                }
            }
            this.ingredients.Add(new_ingredient);
            this.doses.Add(new_ingredient.nom, dose);
            return true;
        }

        public bool removeIngredient(string nom)
        {
            foreach (Ingredient ingredient in this.ingredients)
            {
                if (ingredient.nom.ToLower().Equals(nom))
                {
                    this.ingredients.Remove(ingredient);
                    return true;
                }
            }
            return false;
        }

        public int getOriginalPrix()
        {
            int prix = 0;
            foreach (Ingredient ingredient in this.ingredients)
            {
                int dose = 0;
                this.doses.TryGetValue(ingredient.nom, out dose);
                prix += ingredient.prix * dose;
            }
            return prix;
        }
    }
}
