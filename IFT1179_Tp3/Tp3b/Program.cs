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

        // Méthode itérative calculant la somme de 1 + 1/2 + ... + 1/n-1 + 1/n
        private static double CalculSommeIterative(int value)
        {
            double result = 0f;
            while (value > 0)
            {
                result += (double)1 / value--;
            }
            return result;
        }


        //Méthode récursive calculant la somme de 1 + 1/2 + ... + 1/n-1 + 1/n
        private static double CalculSommeRecursive(int value)
        {
            if (value == 1)
            {
                return value;
            }
            else
            {
                return (double)1 / value + CalculSommeRecursive(value - 1);
            }
        }


        // Méthode itérative calculant le produit des chiffres d'un entier > 0
        private static int CalculProduitIterative(int value)
        {
            int result = 1;
            while (value > 0)
            {
                result *= (value % 10);
                value = value / 10;
            }
            return result;
        }


        //Méthode récursive calculant le produit des chiffres d'un entier > 0
        private static int CalculProduitRecursive(int value)
        {
            if (value < 10)
            {
                return value;
            }
            else
            {
                return value % 10 * CalculProduitRecursive(value / 10);
            }
        }


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
            //    Somme = 1 + 1/2 + 1/3 + 1/4 + . . .   + 1/998 + 1/999
            AfficheTitre("2a. Écrivez une version récursive pour calculer la somme : Somme = 1 + 1/2 + 1/3 + 1/4 + . . .   + 1/998 + 1/999");
            Console.WriteLine("La somme des chiffres de 1 + 1/2 + ... + 1/n-1 + 1/n est {0:F8}", CalculSommeRecursive(999));

            AfficheTitre("2b. Écrivez une version itérative pour calculer la somme : Somme = 1 + 1/2 + 1/3 + 1/4 + . . .   + 1/998 + 1/999");
            Console.WriteLine("La somme des chiffres de 1 + 1/2 + ... + 1/n-1 + 1/n est {0:F8}", CalculSommeIterative(999));

            Console.WriteLine("");
        }
    }
}


/*

1a. Écrivez une version récursive permettant de calculer le produit des chiffres d'un entier n > 0
--------------------------------------------------------------------------------------------------

Le produit des chiffres de 65432 est 720


1b. Écrivez une version itérative permettant de calculer le produit des chiffres d'un entier n > 0
--------------------------------------------------------------------------------------------------

Le produit des chiffres de 65432 est 720


2a. Écrivez une version récursive pour calculer la somme : Somme = 1 + 1/2 + 1/3 + 1/4 + . . .   + 1/998 + 1/999
----------------------------------------------------------------------------------------------------------------

La somme des chiffres de 1 + 1/2 + ... + 1/n-1 + 1/n est 7,48447086


2b. Écrivez une version itérative pour calculer la somme : Somme = 1 + 1/2 + 1/3 + 1/4 + . . .   + 1/998 + 1/999
----------------------------------------------------------------------------------------------------------------

La somme des chiffres de 1 + 1/2 + ... + 1/n-1 + 1/n est 7,48447086

Press any key to continue . . .

 */