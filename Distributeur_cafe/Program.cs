using System;

namespace Distributeur_cafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] Boissons = { "Expresso", "Lait", "Capuccino", "Chocolat chaud", "Café au lait", "Mokaccino", "Thé" };
            //String[] Ingredients = { "Lait en poudre", "Eau", "Cafe", "Chocolat en poudre", "The" };
            const double marge = 0.3;
            int[] prix = { 10, 5, 30, 40, 30 };
            int[,] recettes = {{0,2,1,0,0},
                                {2,1,0,0,0},
                                {2,1,1,1,0},
                                {0,3,0,2,0},
                                {1,2,1,0,0},
                                {1,2,1,2,0},
                                {0,2,0,0,1}};

            Console.WriteLine("Bienvenue au distributeur de café !");
            while (true)
            {
                Console.WriteLine("\nChoisir le numéro de la boisson : ");
                int i = 1;
                foreach (String boissons in Boissons)
                {
                    Console.WriteLine(i + " - " + boissons);
                    i++;
                }
                Console.Write("\nVotre choix : ");
                string choix = Console.ReadLine();
                try
                {
                    int index = Convert.ToInt32(choix) - 1;
                    if(index<0 || index>=Boissons.Length)
                    {
                        throw new Exception();
                    }
                    double prix_totale = 0;
                    for (int j = 0; j < prix.Length; j++)
                    {
                        prix_totale += prix[j] * recettes[index, j];
                    }
                    prix_totale *= (1 + marge);
                    prix_totale /= 100;
                    Console.WriteLine("\n========================================");
                    Console.WriteLine("Le prix de " + Boissons[index] + " est de " +prix_totale+" euros");
                    Console.WriteLine("========================================");
                    Console.Write("Ecrire 'oui' pour choisir une autre boisson : ");
                    string answer = Console.ReadLine();
                    if (!answer.ToLower().Equals("oui"))
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Choix invailde");
                }
            }

        }
    }
}
