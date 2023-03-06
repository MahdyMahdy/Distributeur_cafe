using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distributeur_cafe
{
    internal class Ingredient
    {
        public string nom { get; set; }
        public int prix { get; set; }

        public Ingredient(string nom, int prix)
        {
            this.nom = nom;
            this.prix = prix;
        }
    }
}
