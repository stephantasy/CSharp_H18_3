using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ************************
 *      IFT1179 - TP3
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace Tp3b
{
    class Program
    {

        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }


        // Entrée du programme
        static void Main(string[] args)
        {

            //2.1) Écrivez une version récursive et une version itérative permettant de calculer le produit des chiffres d’un entier n > 0.
            // Testez avec n = 65432
            AfficheTitre("1a. Écrivez une version récursive permettant de calculer le produit des chiffres d’un entier n > 0");
            Console.WriteLine("Le produit des chiffres de 65432 est {0}", CalculProduitRecursive(65432));

            AfficheTitre("1b. Écrivez une version itérative permettant de calculer le produit des chiffres d’un entier n > 0");
            Console.WriteLine("Le produit des chiffres de 65432 est {0}", CalculProduitIterative(65432));

            //2.2) Écrivez une version récursive et une version itérative pour calculer la somme :
            //    Somme = 1 + ½ + 1/3 + ¼ + . . .   + 1/998 + 1/999
            AfficheTitre("2a. Écrivez une version récursive pour calculer la somme : Somme = 1 + ½ + 1/3 + ¼ + . . .   + 1/998 + 1/999");
            Console.WriteLine("La somme des chiffres de 1 + ... + 1/n-1 + 1/n est {0}", CalculSommeRecursive(999));

            AfficheTitre("2b. Écrivez une version itérative pour calculer la somme : Somme = 1 + ½ + 1/3 + ¼ + . . .   + 1/998 + 1/999");

        }

        private static int CalculProduitIterative(int value)
        {
            int result = 1;

            // Inutile de calculer pour une valeur < 0
            if (value <= 0)
            {
                return 0;
            }

            // Calcul du produit
            while (value > 0)
            {
                result *= (value % 10);
                value = value / 10;
            }
            return result;
        }

        private static int CalculProduitRecursive(int value)
        {
            // Inutile de calculer pour une valeur < 0
            if (value <= 0)
            {
                return 0;
            }

            // Calcul du produit
            if (value < 10)
            {
                return value;
            }
            else
            {
                return value % 10 * CalculProduitRecursive(value / 10);
            }
        }
    }
}
