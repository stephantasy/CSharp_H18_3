using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ************************
 *      IFT1179 - TP3
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace Tp3A
{
    class Program
    {


        // Modifie toutes les occurances "population" du pays demandé en le multipliant par "produit"
        private static void ModifierPopulationMultiplier(Pays[] pays, string nomPays, int produit)
        {
            Pays aChercher = new Pays(' ', nomPays, "", 0, 0);
            int pos;
            if ((pos = Array.IndexOf(pays, aChercher)) >= 0)
            {
                pays[pos].Population *= produit;
                Console.WriteLine(" - La population du pays '{0}' a été multiplée par {1}. Nouvelle valeur = {2}\n", nomPays, produit, pays[pos].Population);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau\n", nomPays);
            }
        }

        // Remplace toutes les occurances "capitale" du pays demandé par "newCapitale"
        private static void ModifierCapitale(Pays[] pays, string nomPays, string newCapitale)
        {
            Pays aChercher = new Pays(' ', nomPays, "", 0, 0);
            int pos;
            if ((pos = Array.IndexOf(pays, aChercher)) >= 0)
            {
                pays[pos].Capitale = newCapitale;
                Console.WriteLine(" - La capitale du pays '{0}' a été modifié avec la valeur '{1}'\n", nomPays, newCapitale);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau\n", nomPays);
            }
        }

        // Remplace toutes les occurance "continent" du pays demandé par "newContinent"
        private static void ModifierContinent(Pays[] pays, string nomPays, char newContinent)
        {
            Pays aChercher = new Pays(' ', nomPays, "", 0, 0);
            int pos;
            if ((pos = Array.IndexOf(pays, aChercher)) >= 0)
            {
                pays[pos].Continent = newContinent;
                Console.WriteLine(" - Le continent du pays '{0}' a été modifiée avec la valeur '{1}'\n", nomPays, newContinent);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau\n", nomPays);
            }
        }

        // Affiche le contenu du tableau dans la limite du nombre passé en paramètre
        private static void AfficheTableau(Pays[] pays, int nb)
        {
            for (int i = 0; i < nb; i++)
            {
                Console.WriteLine(" - " + pays[i].ToString());
            }
        }

        // Lit le fichier passé en paramètre, rempli le tableau avec les données lues et compte le nombre de personnes
        private static void LireFichier(string nomFichier, Pays[] tab, out int nb)
        {
            nb = 0;
            StreamReader sr = File.OpenText(nomFichier);
            string ligne = "";

            // On parcours le fichier
            while ((ligne = sr.ReadLine()) != null)
            {
                char codeContinent = ligne.Substring(0, 1)[0];
                string nom = ligne.Substring(1, 35).Trim();
                string capitale = ligne.Substring(36, 25).Trim();
                int superficie = int.Parse(ligne.Substring(61, 10));
                int population = int.Parse(ligne.Substring(71));
                tab[nb++] = new Pays(codeContinent, nom, capitale, superficie, population);
            }
            sr.Close();
            Console.WriteLine("Fin de la lecture du fichier {0}. Il contient {1} pays.", nomFichier, nb);
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
            const string fileName = "Nations.txt";
            const int maxPays = 250;
            Pays[] pays = new Pays[maxPays];


            //1. lire le fichier, remplir un tableau de pays, compter puis transmettre le nombre effectif de pays lus;
            AfficheTitre("1. lire le fichier, remplir un tableau de pays, compter puis transmettre le nombre effectif de pays lus :");
            LireFichier(fileName, pays, out int nbPays);
            Console.WriteLine("");

            //2. Afficher seulement 15 premiers pays lus (en utilisant, entre autres, la redéfinition de ToString) après la lecture;
            AfficheTitre("2. Afficher seulement les 15 premiers pays lus :");
            AfficheTableau(pays, 15);
            Console.WriteLine("");


            //3. Faire la recherche séquentielle (avec Array.IndexOf …)  puis de :
            //	- modifier le continent de la Russie, c’est un pays d’Europe;
            //	- de modifier la capitale de la Chine, c’est Pekin;
            //	- de changer la population de l’Allemagne : c’est 10 fois la population lue
            //
            //	On réaffiche 15 premiers pays du tableau après ces modifications;
            AfficheTitre("3a. Faire la recherche séquentielle et modifier le continent de la Russie :");            
            ModifierContinent(pays, "Russie", '5');

            AfficheTitre("3b. Faire la recherche séquentielle et modifier la capitale de la Chine :");
            ModifierCapitale(pays, "Chine", "Pekin");

            AfficheTitre("3c. Faire la recherche séquentielle et modifier la population de l’Allemagne :");
            ModifierPopulationMultiplier(pays, "Allemagne", 10);

            AfficheTitre("3d. Afficher seulement les 15 premiers pays lus :");
            AfficheTableau(pays, 15);
            Console.WriteLine("");

            //4. Afficher les pays dont le nom est identique au nom de la capitale (exemples Luxembourg, Panama, etc)
            AfficheTitre("4. Afficher les pays dont le nom est identique au nom de la capitale :");
            Console.WriteLine("");



            //5. Déterminer puis afficher :
            //	- le pays d’Europe dont la densité est la plus petite.
            //	- le pays d’Océanie dont la densité est la plus petite. (densité : nombre d’habitants par km2)
            AfficheTitre("");
            Console.WriteLine("");


            //6. Déterminer puis afficher le pays le plus peuplé
            //	- du continent Amérique ;
            //	- du continent Europe
            AfficheTitre("");
            Console.WriteLine("");


            //7. Déterminer et d’afficher les informations :
            //	a) des pays dont le nom commence par une voyelle
            //	b) du pays d’Amérique dont  la capitale contient le plus de lettres alphabétiques 

            //8. Trier (avec Array.Sort) selon les noms des pays et d’afficher les 10 premiers pays après le tri
            AfficheTitre("");
            Console.WriteLine("");


            //9. Chercher (en utilisant la recherche avec Array.BinarySearch) puis afficher les pays suivants :
            //                - Chili, France, Chine,  Mexique
            AfficheTitre("");
            Console.WriteLine("");


            //10a. Créer le fichier texte du nom Europe.txt qui contient seulement les pays d’Europe;
            AfficheTitre("");
            Console.WriteLine("");


            //10b. Créer le fichier texte du nom Asie.txt qui contient seulement les pays d’Asie.
            AfficheTitre("");
            Console.WriteLine("");


        }
    }
}
