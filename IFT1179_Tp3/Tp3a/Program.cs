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
        // Crée un fichier contenant les pays du continent spécifié
        private static void CreerFichier(Pays[] pays, int nbPays, char codeContinent)
        {
            string fileName = Pays.GetContinentName(codeContinent) + ".txt";
            FileInfo fichier = new FileInfo(fileName);
            StreamWriter sw = fichier.CreateText();
            for (int i = 0; i < nbPays; i++)
            {
                if (pays[i].Continent == codeContinent)
                {
                    sw.WriteLine("{0}{1,-35}{2,-26}{3,8}{4,15}", pays[i].Continent, pays[i].Nom, pays[i].Capitale, pays[i].Superficie, pays[i].Population);
                }
            }
            sw.Close();
            Console.WriteLine("Le fichier '{0}' a été créé.", fileName);
        }

        // Cherche la liste des pays demandés et affiche leur informations
        private static void ChercheAffichePays(Pays[] pays, string[] listPays)
        {
            foreach (var p in listPays)
            {
                Pays aChercher = new Pays(' ', p, "", 0, 0);
                int pos = Array.BinarySearch(pays, aChercher);
                if (pos > 0)
                {
                    Console.WriteLine(pays[pos]);
                }
                else
                {
                    Console.WriteLine("Le pays {0} n'existe pas dans le tableau", p);
                }
            }
        }

        // Affiche le nom du pays avec la capitale ayant le plus de lettres
        private static void AfficherPaysCapitalePluslettres(Pays[] pays, char v)
        {
            int maxLettre = 0;
            int index = 0;
            string capitale = "";
            for (int i = 0; i < pays.Length; i++)
            {
                if (pays[i] != null)
                {
                    if (pays[i].Capitale.Length > maxLettre)
                    {
                        maxLettre = pays[i].Capitale.Length;
                        capitale = pays[i].Capitale;
                        index = i;
                    }
                }
            }
            Console.WriteLine(" - Le pays avec la capitale ayant le plus de lettres est : {0}\n - Sa capitale est : {1}", pays[index].Nom, capitale);
        }

        // Affiche les pays commeçant par une voyelle
        private static void AfficherPaysCommenceVoyelle(Pays[] pays)
        {
            char[] voyelles = new char[] { 'A', 'E', 'I', 'O', 'U', 'Y' };
            foreach (var p in pays)
            {
                if (p != null && p.Nom[0].ToString().ToUpper().IndexOfAny(voyelles) >= 0)
                {
                    Console.WriteLine(p);
                }
            }
        }

        // Affiche le pays le plus peuplé du continent spécifié
        private static void AfficherPlusPeuple(Pays[] pays, char codeContinent)
        {
            int index = 0;
            int plusPeuple = int.MinValue;
            for (int i = 0; i < pays.Length; i++)
            {
                if (pays[i] != null && pays[i].Continent == codeContinent)
                {
                    if (plusPeuple < pays[i].Population)
                    {
                        plusPeuple = pays[i].Population;
                        index = i;
                    }
                }
            }
            Console.WriteLine(" - Le pays le plus peuplé d'{0} est : {1}", Pays.GetContinentName(codeContinent), pays[index].Nom);
        }

        // Affiche le nom dy pays ayant la plus petite densité sur le continent spécifié
        private static void AfficherPlusPetiteDensite(Pays[] pays, char codeContinent)
        {
            int index = 0;
            float densite = float.MaxValue;
            for (int i = 0; i < pays.Length; i++)
            {
                if (pays[i] != null && pays[i].Continent == codeContinent)
                {
                    var temp = (float)pays[i].Population / pays[i].Superficie;
                    if (temp < densite)
                    {
                        densite = temp;
                        index = i;
                    }
                }
            }
            Console.WriteLine(" - Le pays d'{0} ayant la plus petite densité est : {1}", Pays.GetContinentName(codeContinent), pays[index].Nom);
        }

        // Affiche la liste des pays dont le nom est identique au nom de la capitale
        private static void AffichichePaysEgalCapitale(Pays[] pays)
        {
            Console.WriteLine(" - Les pays dont le nom est identique au nom de la capitale sont : ");
            foreach (var p in pays)
            {
                if (p != null && p.Nom.Equals(p.Capitale))
                {
                    Console.WriteLine("      - {0}", p.Nom);
                }
            }
        }

        // Modifie toutes les occurances "population" du pays demandé en le multipliant par "produit"
        private static void ModifierPopulationMultiplier(Pays[] pays, string nomPays, int produit)
        {
            Pays aChercher = new Pays(' ', nomPays, "", 0, 0);
            int pos;
            if ((pos = Array.IndexOf(pays, aChercher)) >= 0)
            {
                pays[pos].Population *= produit;
                Console.WriteLine(" - La population du pays '{0}' a été multiplée par {1}. Nouvelle valeur = {2}", nomPays, produit, pays[pos].Population);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau", nomPays);
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
                Console.WriteLine(" - La capitale du pays '{0}' a été modifié avec la valeur '{1}'", nomPays, newCapitale);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau", nomPays);
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
                Console.WriteLine(" - Le continent du pays '{0}' a été modifiée avec la valeur '{1}'", nomPays, newContinent);
            }
            else
            {
                Console.WriteLine(" - Le pays {0} n'a pas été trouvé dans le tableau", nomPays);
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
            Console.WriteLine(" - Fin de la lecture du fichier {0}. Il contient {1} pays.", nomFichier, nb);
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
            AffichichePaysEgalCapitale(pays);
            Console.WriteLine("");


            //5. Déterminer puis afficher :
            //	- le pays d’Europe dont la densité est la plus petite.
            //	- le pays d’Océanie dont la densité est la plus petite. (densité : nombre d’habitants par km2)
            AfficheTitre("5a. Déterminer puis afficher le pays d’Europe dont la densité est la plus petite :");
            AfficherPlusPetiteDensite(pays, '5');
            AfficheTitre("5b. Déterminer puis afficher le pays d’Océanie dont la densité est la plus petite :");
            AfficherPlusPetiteDensite(pays, '4');
            Console.WriteLine("");


            //6. Déterminer puis afficher le pays le plus peuplé
            //	- du continent Amérique ;
            //	- du continent Europe
            AfficheTitre("6a. Déterminer puis afficher le pays le plus peuplé du continent Amérique :");
            AfficherPlusPeuple(pays, '2');
            AfficheTitre("6b. Déterminer puis afficher le pays le plus peuplé du continent Europe :");
            AfficherPlusPeuple(pays, '5');
            Console.WriteLine("");


            //7. Déterminer et d’afficher les informations :
            //	a) des pays dont le nom commence par une voyelle
            //	b) du pays d’Amérique dont  la capitale contient le plus de lettres alphabétiques 
            AfficheTitre("7a. Déterminer et afficher les informations des pays dont le nom commence par une voyelle :");
            AfficherPaysCommenceVoyelle(pays);
            AfficheTitre("7b. Déterminer et afficher les informations du pays d’Amérique dont la capitale contient le plus de lettres :");
            AfficherPaysCapitalePluslettres(pays, '2');
            Console.WriteLine("");


            //8. Trier (avec Array.Sort) selon les noms des pays et d’afficher les 10 premiers pays après le tri
            AfficheTitre("8. Trier (avec Array.Sort) selon les noms des pays et d’afficher les 10 premiers pays après le tri : ");
            Array.Sort(pays, 0, nbPays);
            AfficheTableau(pays, 10);
            Console.WriteLine("");


            //9. Chercher (en utilisant la recherche avec Array.BinarySearch) puis afficher les pays suivants :
            //                - Chili, France, Chine,  Mexique
            AfficheTitre("9. Chercher (en utilisant la recherche avec Array.BinarySearch) puis afficher les pays Chili, France, Chine,  Mexique :");
            string[] listPays = { "Chili", "France", "Chine",  "Mexique" };
            ChercheAffichePays(pays, listPays);
            Console.WriteLine("");


            //10a. Créer le fichier texte du nom Europe.txt qui contient seulement les pays d’Europe;
            AfficheTitre("10a. Créer le fichier texte du nom Europe.txt qui contient seulement les pays d’Europe :");
            CreerFichier(pays, nbPays, '5');

            //10b. Créer le fichier texte du nom Asie.txt qui contient seulement les pays d’Asie.
            AfficheTitre("10b. Créer le fichier texte du nom Asie.txt qui contient seulement les pays d’Asie :");
            CreerFichier(pays, nbPays, '3');
            Console.WriteLine("");        
        }
    }
}

/*
 
1. lire le fichier, remplir un tableau de pays, compter puis transmettre le nombre effectif de pays lus :
---------------------------------------------------------------------------------------------------------

 - Fin de la lecture du fichier Nations.txt. Il contient 197 pays.



2. Afficher seulement les 15 premiers pays lus :
------------------------------------------------

 - Continent : Amérique   - Pays : ETATS-UNIS                       - Capitale : WASHINGTON          - Superfie (km²) : 9629047  - Population : 291289535
 - Continent : Asie       - Pays : CHINE                            - Capitale : SHANGHAI            - Superfie (km²) : 9596960  - Population : 1273111290
 - Continent : Amérique   - Pays : RUSSIE                           - Capitale : MOSCOU              - Superfie (km²) : 17075400 - Population : 143954573
 - Continent : Océanie    - Pays : AUSTRALIE                        - Capitale : CANBERRA            - Superfie (km²) : 7686850  - Population : 19834248
 - Continent : Asie       - Pays : JAPON                            - Capitale : TOKYO               - Superfie (km²) : 377835   - Population : 12761000
 - Continent : Europe     - Pays : ALLEMAGNE                        - Capitale : BERLIN              - Superfie (km²) : 357027   - Population : 8253700
 - Continent : Europe     - Pays : FRANCE                           - Capitale : MARSEILLE           - Superfie (km²) : 543964   - Population : 61387038
 - Continent : Europe     - Pays : ITALIE                           - Capitale : ROME                - Superfie (km²) : 301230   - Population : 57715620
 - Continent : Asie       - Pays : COREE DU SUD                     - Capitale : SEOUL               - Superfie (km²) : 99274    - Population : 48324000
 - Continent : Europe     - Pays : ROYAUME-UNI                      - Capitale : LONDRES             - Superfie (km²) : 244101   - Population : 58789194
 - Continent : Amérique   - Pays : CUBA                             - Capitale : LA HAVANE           - Superfie (km²) : 100860   - Population : 11184023
 - Continent : Europe     - Pays : UKRAINE                          - Capitale : KIEV                - Superfie (km²) : 603700   - Population : 48396470
 - Continent : Europe     - Pays : HONGRIE                          - Capitale : BUDAPEST            - Superfie (km²) : 93030    - Population : 10106017
 - Continent : Europe     - Pays : ROUMANIE                         - Capitale : BUCAREST            - Superfie (km²) : 238390   - Population : 22272000
 - Continent : Europe     - Pays : GRECE                            - Capitale : ATHENES             - Superfie (km²) : 131940   - Population : 10623835



3a. Faire la recherche séquentielle et modifier le continent de la Russie :
---------------------------------------------------------------------------

 - Le continent du pays 'Russie' a été modifiée avec la valeur '5'


3b. Faire la recherche séquentielle et modifier la capitale de la Chine :
-------------------------------------------------------------------------

 - La capitale du pays 'Chine' a été modifié avec la valeur 'Pekin'


3c. Faire la recherche séquentielle et modifier la population de l'Allemagne :
------------------------------------------------------------------------------

 - La population du pays 'Allemagne' a été multiplée par 10. Nouvelle valeur = 82537000


3d. Afficher seulement les 15 premiers pays lus :
-------------------------------------------------

 - Continent : Amérique   - Pays : ETATS-UNIS                       - Capitale : WASHINGTON          - Superfie (km²) : 9629047  - Population : 291289535
 - Continent : Asie       - Pays : CHINE                            - Capitale : PEKIN               - Superfie (km²) : 9596960  - Population : 1273111290
 - Continent : Europe     - Pays : RUSSIE                           - Capitale : MOSCOU              - Superfie (km²) : 17075400 - Population : 143954573
 - Continent : Océanie    - Pays : AUSTRALIE                        - Capitale : CANBERRA            - Superfie (km²) : 7686850  - Population : 19834248
 - Continent : Asie       - Pays : JAPON                            - Capitale : TOKYO               - Superfie (km²) : 377835   - Population : 12761000
 - Continent : Europe     - Pays : ALLEMAGNE                        - Capitale : BERLIN              - Superfie (km²) : 357027   - Population : 82537000
 - Continent : Europe     - Pays : FRANCE                           - Capitale : MARSEILLE           - Superfie (km²) : 543964   - Population : 61387038
 - Continent : Europe     - Pays : ITALIE                           - Capitale : ROME                - Superfie (km²) : 301230   - Population : 57715620
 - Continent : Asie       - Pays : COREE DU SUD                     - Capitale : SEOUL               - Superfie (km²) : 99274    - Population : 48324000
 - Continent : Europe     - Pays : ROYAUME-UNI                      - Capitale : LONDRES             - Superfie (km²) : 244101   - Population : 58789194
 - Continent : Amérique   - Pays : CUBA                             - Capitale : LA HAVANE           - Superfie (km²) : 100860   - Population : 11184023
 - Continent : Europe     - Pays : UKRAINE                          - Capitale : KIEV                - Superfie (km²) : 603700   - Population : 48396470
 - Continent : Europe     - Pays : HONGRIE                          - Capitale : BUDAPEST            - Superfie (km²) : 93030    - Population : 10106017
 - Continent : Europe     - Pays : ROUMANIE                         - Capitale : BUCAREST            - Superfie (km²) : 238390   - Population : 22272000
 - Continent : Europe     - Pays : GRECE                            - Capitale : ATHENES             - Superfie (km²) : 131940   - Population : 10623835



4. Afficher les pays dont le nom est identique au nom de la capitale :
----------------------------------------------------------------------

 - Les pays dont le nom est identique au nom de la capitale sont :
      - DJIBOUTI
      - KOWEIT
      - LUXEMBOURG
      - MONACO
      - PANAMA
      - SAINT MARIN
      - SAO TOME



5a. Déterminer puis afficher le pays d'Europe dont la densité est la plus petite :
----------------------------------------------------------------------------------

 - Le pays d'Europe ayant la plus petite densité est : ISLANDE


5b. Déterminer puis afficher le pays d'Océanie dont la densité est la plus petite :
-----------------------------------------------------------------------------------

 - Le pays d'Océanie ayant la plus petite densité est : AUSTRALIE



6a. Déterminer puis afficher le pays le plus peuplé du continent Amérique :
---------------------------------------------------------------------------

 - Le pays le plus peuplé d'Amérique est : ETATS-UNIS


6b. Déterminer puis afficher le pays le plus peuplé du continent Europe :
-------------------------------------------------------------------------

 - Le pays le plus peuplé d'Europe est : RUSSIE



7a. Déterminer et afficher les informations des pays dont le nom commence par une voyelle :
-------------------------------------------------------------------------------------------

Continent : Amérique   - Pays : ETATS-UNIS                       - Capitale : WASHINGTON          - Superfie (km²) : 9629047  - Population : 291289535
Continent : Océanie    - Pays : AUSTRALIE                        - Capitale : CANBERRA            - Superfie (km²) : 7686850  - Population : 19834248
Continent : Europe     - Pays : ALLEMAGNE                        - Capitale : BERLIN              - Superfie (km²) : 357027   - Population : 82537000
Continent : Europe     - Pays : ITALIE                           - Capitale : ROME                - Superfie (km²) : 301230   - Population : 57715620
Continent : Europe     - Pays : UKRAINE                          - Capitale : KIEV                - Superfie (km²) : 603700   - Population : 48396470
Continent : Europe     - Pays : ESPAGNE                          - Capitale : MADRID              - Superfie (km²) : 504782   - Population : 40037995
Continent : Europe     - Pays : AUTRICHE                         - Capitale : VIENNE              - Superfie (km²) : 83858    - Population : 8150835
Continent : Afrique    - Pays : ETHIOPIE                         - Capitale : ADDIS-ABEBA         - Superfie (km²) : 1127127  - Population : 67673031
Continent : Asie       - Pays : IRAN                             - Capitale : TEHERAN             - Superfie (km²) : 1648000  - Population : 76000000
Continent : Asie       - Pays : OUZBEKISTAN                      - Capitale : TACHKENT            - Superfie (km²) : 447400   - Population : 25563441
Continent : Amérique   - Pays : ARGENTINE                        - Capitale : BUENOS AIRES        - Superfie (km²) : 2766890  - Population : 37812817
Continent : Afrique    - Pays : AFRIQUE DU SUD                   - Capitale : PRETORIA            - Superfie (km²) : 1219912  - Population : 42718530
Continent : Afrique    - Pays : EGYPTE                           - Capitale : LE CAIRE            - Superfie (km²) : 995450   - Population : 74718797
Continent : Asie       - Pays : INDONESIE                        - Capitale : DJAKARTA            - Superfie (km²) : 1919440  - Population : 228437870
Continent : Asie       - Pays : AZERBAIDJAN                      - Capitale : BAKU                - Superfie (km²) : 86100    - Population : 7830764
Continent : Europe     - Pays : ISRAEL                           - Capitale : JERUSALEM           - Superfie (km²) : 20770    - Population : 6116533
Continent : Asie       - Pays : EMIRATS ARABES UNIS              - Capitale : ABOU DHABI          - Superfie (km²) : 82880    - Population : 2407460
Continent : Europe     - Pays : ESTONIE                          - Capitale : TALINN              - Superfie (km²) : 45226    - Population : 1401945
Continent : Asie       - Pays : INDE                             - Capitale : NEW DELHI           - Superfie (km²) : 3287590  - Population : 1029991145
Continent : Afrique    - Pays : ERYTHREE                         - Capitale : ASMARA              - Superfie (km²) : 121320   - Population : 4465651
Continent : Asie       - Pays : AFGHANISTAN                      - Capitale : KABOUL              - Superfie (km²) : 652225   - Population : 29547078
Continent : Europe     - Pays : ALBANIE                          - Capitale : TIRANA              - Superfie (km²) : 28748    - Population : 3510484
Continent : Afrique    - Pays : ALGERIE                          - Capitale : ALGER               - Superfie (km²) : 2381740  - Population : 31763053
Continent : Europe     - Pays : ANDORRE                          - Capitale : ANDORRA LA VELLA    - Superfie (km²) : 468      - Population : 67627
Continent : Afrique    - Pays : ANGOLA                           - Capitale : LUANDA              - Superfie (km²) : 1246700  - Population : 10766471
Continent : Amérique   - Pays : ANTIGUA-ET-BARBUDA               - Capitale : SAINT-JOHNS         - Superfie (km²) : 442      - Population : 67448
Continent : Amérique   - Pays : ANTILLES NEERLANDAISES           - Capitale : WILLEMSTAD          - Superfie (km²) : 800      - Population : 210000
Continent : Asie       - Pays : ARABIE SAOUDITE                  - Capitale : RIYAD               - Superfie (km²) : 1960582  - Population : 23513330
Continent : Asie       - Pays : ARMENIE                          - Capitale : EREVAN              - Superfie (km²) : 29800    - Population : 3326448
Continent : Amérique   - Pays : ARUBA                            - Capitale : ORANJESTAD          - Superfie (km²) : 193      - Population : 69000
Continent : Amérique   - Pays : EL SALVADOR                      - Capitale : SAN SALVADOR        - Superfie (km²) : 21041    - Population : 6122075
Continent : Amérique   - Pays : EQUATEUR                         - Capitale : QUITO               - Superfie (km²) : 283560   - Population : 13183978
Continent : Amérique   - Pays : ILES CAIMANS                     - Capitale : GEORGE TOWN         - Superfie (km²) : 262      - Population : 39000
Continent : Océanie    - Pays : ILES SALOMON                     - Capitale : HONIARA             - Superfie (km²) : 28450    - Population : 480442
Continent : Amérique   - Pays : ILES VIERGES BRITANNIQUES        - Capitale : ROAD TOWN           - Superfie (km²) : 153      - Population : 19000
Continent : Asie       - Pays : IRAK                             - Capitale : BAGDAD              - Superfie (km²) : 437072   - Population : 23331985
Continent : Europe     - Pays : IRLANDE                          - Capitale : DUBLIN              - Superfie (km²) : 70273    - Population : 3917336
Continent : Europe     - Pays : ISLANDE                          - Capitale : REYKJAVIC           - Superfie (km²) : 103125   - Population : 288201
Continent : Asie       - Pays : OMAN                             - Capitale : MASCATE             - Superfie (km²) : 212460   - Population : 2622198
Continent : Afrique    - Pays : OUGANDA                          - Capitale : KAMPALA             - Superfie (km²) : 236040   - Population : 24699073
Continent : Amérique   - Pays : URUGUAY                          - Capitale : MONTEVIDEO          - Superfie (km²) : 176220   - Population : 3360105
Continent : Asie       - Pays : YEMEN                            - Capitale : SANAA               - Superfie (km²) : 527970   - Population : 19349881


7b. Déterminer et afficher les informations du pays d'Amérique dont la capitale contient le plus de lettres :
-------------------------------------------------------------------------------------------------------------

 - Le pays avec la capitale ayant le plus de lettres est : BRUNEI
 - Sa capitale est : BANDAR SERI BEGAWAN



8. Trier (avec Array.Sort) selon les noms des pays et d'afficher les 10 premiers pays après le tri :
-----------------------------------------------------------------------------------------------------

 - Continent : Asie       - Pays : AFGHANISTAN                      - Capitale : KABOUL              - Superfie (km²) : 652225   - Population : 29547078
 - Continent : Afrique    - Pays : AFRIQUE DU SUD                   - Capitale : PRETORIA            - Superfie (km²) : 1219912  - Population : 42718530
 - Continent : Europe     - Pays : ALBANIE                          - Capitale : TIRANA              - Superfie (km²) : 28748    - Population : 3510484
 - Continent : Afrique    - Pays : ALGERIE                          - Capitale : ALGER               - Superfie (km²) : 2381740  - Population : 31763053
 - Continent : Europe     - Pays : ALLEMAGNE                        - Capitale : BERLIN              - Superfie (km²) : 357027   - Population : 82537000
 - Continent : Europe     - Pays : ANDORRE                          - Capitale : ANDORRA LA VELLA    - Superfie (km²) : 468      - Population : 67627
 - Continent : Afrique    - Pays : ANGOLA                           - Capitale : LUANDA              - Superfie (km²) : 1246700  - Population : 10766471
 - Continent : Amérique   - Pays : ANTIGUA-ET-BARBUDA               - Capitale : SAINT-JOHNS         - Superfie (km²) : 442      - Population : 67448
 - Continent : Amérique   - Pays : ANTILLES NEERLANDAISES           - Capitale : WILLEMSTAD          - Superfie (km²) : 800      - Population : 210000
 - Continent : Asie       - Pays : ARABIE SAOUDITE                  - Capitale : RIYAD               - Superfie (km²) : 1960582  - Population : 23513330



9. Chercher (en utilisant la recherche avec Array.BinarySearch) puis afficher les pays Chili, France, Chine,  Mexique :
-----------------------------------------------------------------------------------------------------------------------

Continent : Amérique   - Pays : CHILI                            - Capitale : SANTIAGO            - Superfie (km²) : 756950   - Population : 15328467
Continent : Europe     - Pays : FRANCE                           - Capitale : MARSEILLE           - Superfie (km²) : 543964   - Population : 61387038
Continent : Asie       - Pays : CHINE                            - Capitale : PEKIN               - Superfie (km²) : 9596960  - Population : 1273111290
Continent : Amérique   - Pays : MEXIQUE                          - Capitale : MEXICO              - Superfie (km²) : 1972550  - Population : 103400165



10a. Créer le fichier texte du nom Europe.txt qui contient seulement les pays d'Europe :
----------------------------------------------------------------------------------------

Le fichier 'Europe.txt' a été créé.


10b. Créer le fichier texte du nom Asie.txt qui contient seulement les pays d'Asie :
------------------------------------------------------------------------------------

Le fichier 'Asie.txt' a été créé.


 */
