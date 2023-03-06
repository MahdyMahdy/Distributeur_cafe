using System;

namespace Distributeur_cafe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Ingredient lait_en_poudre = new Ingredient("Lait en poudre", 10);
            Ingredient eau = new Ingredient("Eau", 5);
            Ingredient cafe = new Ingredient("Café", 30);
            Ingredient chocolat_en_poudre = new Ingredient("Chocolat en poudre", 40);
            Ingredient the = new Ingredient("Thé", 30);
            Boisson expresso = new Boisson("Expresso");
            expresso.addIngredient(eau, 2);
            expresso.addIngredient(cafe, 1);
            Boisson lait = new Boisson("Lait");
            lait.addIngredient(lait_en_poudre, 2);
            lait.addIngredient(eau, 1);
            Boisson capuccino = new Boisson("Capuccino");
            capuccino.addIngredient(lait_en_poudre, 2);
            capuccino.addIngredient(eau, 1);
            capuccino.addIngredient(cafe, 1);
            capuccino.addIngredient(chocolat_en_poudre, 1);
            Boisson chocolat_chaud = new Boisson("Chocolat chaud");
            chocolat_chaud.addIngredient(eau, 3);
            chocolat_chaud.addIngredient(chocolat_en_poudre, 2);
            Boisson cafe_au_lait = new Boisson("Café au lait");
            cafe_au_lait.addIngredient(lait_en_poudre, 1);
            cafe_au_lait.addIngredient(eau, 2);
            cafe_au_lait.addIngredient(cafe, 1);
            Boisson mokaccino = new Boisson("Mokaccino");
            mokaccino.addIngredient(lait_en_poudre, 1);
            mokaccino.addIngredient(eau, 2);
            mokaccino.addIngredient(cafe, 1);
            mokaccino.addIngredient(chocolat_en_poudre, 2);
            Boisson the_boisson = new Boisson("The");
            the_boisson.addIngredient(eau, 2);
            the_boisson.addIngredient(the, 1);

            Boisson[] boissons = { expresso, lait, capuccino, chocolat_chaud, cafe_au_lait, mokaccino, the_boisson };
            const double marge = 0.3;

            Console.WriteLine("Bienvenue au distributeur de café !");
            while (true)
            {
                Console.WriteLine("\nChoisir le numéro de la boisson : ");
                int i = 1;
                foreach (Boisson boisson in boissons)
                {
                    Console.WriteLine(i + " - " + boisson.nom);
                    i++;
                }
                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(choix) - 1;
                    if(index<0 || index>=boissons.Length)
                    {
                        throw new Exception();
                    }
                    double prix_totale = boissons[index].getOriginalPrix();
                    prix_totale *= (1 + marge);
                    prix_totale /= 100;
                    Console.WriteLine("\n========================================");
                    Console.WriteLine("Le prix de " + boissons[index].nom + " est de " +prix_totale+" euros");
                    Console.WriteLine("========================================");
                    Console.Write("Ecrire 'info' pour connaitre les ingredients et 'autre' pour choisir une autre boisson : ");
                    Console.Write("\nVotre choix : ");
                    string answer = Console.ReadLine();
                    if (answer.ToLower().Equals("info"))
                    {
                        foreach (Ingredient ingredient in boissons[index].ingredients)
                        {
                            Console.Write(ingredient.nom+ " ");
                        }
                        Console.Write("\nEcrire 'autre' pour choisir une autre boisson : ");
                        Console.Write("\nVotre choix : ");
                        answer = Console.ReadLine();
                        if (answer.ToLower().Equals("autre"))
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (answer.ToLower().Equals("autre"))
                    {
                        continue;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Choix invailde");
                    break;
                }
            }

        }
    }
}
