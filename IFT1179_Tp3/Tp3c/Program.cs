using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp3c
{
    class Program
    {
        // 
        private static void AfficherAdversairePays(List<Pays> listePays, string pays)
        {
        }


        // Affiche les données des pays passés en paramètre
        private static void AfficherDetailPays(List<Pays> listePays, List<string> listeToDisplay)
        {
            foreach (var pays in listeToDisplay)
            {
                Pays aChercher = new Pays(' ', ' ', pays.ToUpper(), "", 0, 0);
                int pos = listePays.BinarySearch(aChercher);
                if(pos >= 0)
                {
                    Console.WriteLine(" - {0}", listePays.ElementAt(pos).ToString());
                }
                else
                {
                    Console.WriteLine(" - Le pays '{0}' n'est pas dans la liste.", pays.ToUpper());
                }
            }
        }


        // Tri la liste par pays
        private static void TrierListeParPays(List<Pays> listePays)
        {
            listePays.Sort(); // Par le nom des pays par défaut
            Console.WriteLine(" - La liste des pays est triée par le nom des pays");
        }


        // Recherche et affiche le nom du pays ayant la plus petite superficie
        private static void AfficherPaysMoinsSuperficie(List<Pays> listePays)
        {
            // On recherche la plus petite valeur
            int moinsSuperficie = listePays.Min(t => t.Superficie);
            // On récupère l'index de ce pays
            Pays.codeEquals = Pays.EnumCodeEquals.Superficie;
            Pays aChercher = new Pays(' ', ' ', "", "", moinsSuperficie, 0);
            int pos = listePays.IndexOf(aChercher);
            Console.WriteLine(" - Le pays ayant la plus petite superficie est : {0}", listePays.ElementAt(pos).Nom);
        }


        // Recherche et affiche le nom du pays ayant la plus petite population
        private static void AfficherPaysMoinsPeuple(List<Pays> listePays)
        {
            // On recherche la plus petite valeur
            int moinsPeuple = listePays.Min(t => t.Population);
            // On récupère l'index de ce pays
            Pays.codeEquals = Pays.EnumCodeEquals.Population;
            Pays aChercher = new Pays(' ', ' ', "", "", 0, moinsPeuple);
            int pos = listePays.IndexOf(aChercher);
            Console.WriteLine(" - Le pays le moins peuplé est : {0}", listePays.ElementAt(pos).Nom);
        }


        // Renvoie le nombre de pays pour ce continent
        private static int NombrePays(List<Pays> listePays, Pays.EnumContinent continent)
        {
            int nb = 0;
            foreach (var pays in listePays)
            {
                if(pays.GetContinentName().Equals(continent.ToString()))
                {
                    nb++;
                }
            }
            return nb;
        }


        // Affiche le continent ayant le moins de pays
        private static void AfficherContinentMoinsPays(List<Pays> listePays)
        {
            Pays.EnumContinent continent = Pays.EnumContinent.Afrique;
            int plusPetit = int.MaxValue;
            foreach (Pays.EnumContinent c in Enum.GetValues(typeof(Pays.EnumContinent)))
            {
                var nombre = NombrePays(listePays, c);
                if (nombre < plusPetit)
                {
                    plusPetit = nombre;
                    continent = c;
                }
            }
            Console.WriteLine(" - Le continent ayant le moins de pays participant est l'{0}", continent.ToString());
        }


        // Affiche le continent ayant le plus de pays
        private static void AfficherContinentPlusPays(List<Pays> listePays)
        {
            Pays.EnumContinent continent = Pays.EnumContinent.Afrique;
            int plusGrand = 0;
            foreach (Pays.EnumContinent c in Enum.GetValues(typeof(Pays.EnumContinent)))
            {
                var nombre = NombrePays(listePays, c);
                if (nombre > plusGrand)
                {
                    plusGrand = nombre;
                    continent = c;
                }
            }            
            Console.WriteLine(" - Le continent ayant le plus grand nombre de pays participant est l'{0}", continent.ToString());
        }


        // Ajout d'un pays à la liste
        private static void AjouterPays(List<Pays> listePays, Pays pays)
        {
            listePays.Add(pays);
            Console.WriteLine("Le pays suivant à été ajouté : {0}", pays.Nom);
        }


        // Supprime les pays passés en paramètre
        private static void SupprimerPays(List<Pays> listePays, List<string> listeToDelete)
        {
            string msg = "";
            foreach (var pays in listeToDelete)
            {
                Pays aChercher = new Pays(' ', ' ', pays, "", 0, 0);
                int pos = listePays.IndexOf(aChercher);
                // On supprime toute les instances du pays
                while( (pos = listePays.IndexOf(aChercher)) > 0)
                {
                    listePays.RemoveAt(pos);
                    msg += pays + " ";
                }
            }
            Console.WriteLine(" - Les pays suivants ont été supprimés : {0}", msg);
        }


        // Modifie la superficie du pays à la position spécifiée
        private static void ModifierSuperficiePosition(List<Pays> listePays, int position, int nouvelleSuperficie)
        {
            listePays.ElementAt(position).Superficie = nouvelleSuperficie;
            Console.WriteLine(" - La superficie du pays {0} a été modifiée, sa nouvelle valeur est : {1}", listePays.ElementAt(position).Nom, listePays.ElementAt(position).Superficie);
        }


        // Modifie le groupe du pays à la position spécifiée
        private static void ModifierGroupePosition(List<Pays> listePays, int position, char nouveauGroupe)
        {
            listePays.ElementAt(position).Groupe = nouveauGroupe;
            Console.WriteLine(" - Le groupe du pays {0} a été modifié, sa nouvelle valeur est : {1}", listePays.ElementAt(position).Nom, listePays.ElementAt(position).Groupe);
        }


        // Affiche les premiers et derniers éléments de la liste (ou toute la liste si les valeurs sont à 0)
        private static void AfficherListe(List<Pays> listePays, int premier = 0, int dernier = 0, string msg = "dans l'ordre initiale")
        {
            // Si on ne présise rien (ou qu'on passe des valeurs <= à 0), on affiche tout
            if(premier <= 0 && dernier <= 0)
            {
                Console.WriteLine("Voici la listePays des pays {0} : \n", msg);
                premier = listePays.Count;
            }
            else
            {
                Console.WriteLine("Voici les {0} premiers et les {1} derniers pays {2} : \n", premier, dernier, msg);
            }
            
            // Premiers éléments
            for (int i = 0; i < premier; i++)
            {
                Console.WriteLine(" {0,2} - {1}", i, listePays.ElementAt(i));
            }
            // Derniers éléments
            if (dernier > 0)
            {
                Console.WriteLine("      ...");
                for (int i = listePays.Count - dernier; i < listePays.Count; i++)
                {
                    Console.WriteLine(" {0,2} - {1}", i, listePays.ElementAt(i));
                }
            }
        }


        // Lit le fichier passé en paramètre, rempli le tableau avec les données lues et compte le nombre de personnes
        private static List<Pays> LireFichier(string nomFichier)
        {
            List<Pays> listePays = new List<Pays>();
            StreamReader sr = File.OpenText(nomFichier);
            string ligne = "";

            // On parcours le fichier
            while ((ligne = sr.ReadLine()) != null)
            {
                char codeGroupe = ligne.Substring(0, 1)[0];
                char codeContinent = ligne.Substring(1, 1)[0];
                string nom = ligne.Substring(2, 35).Trim();
                string capitale = ligne.Substring(37, 24).Trim();
                int superficie = int.Parse(ligne.Substring(61, 10));
                int population = int.Parse(ligne.Substring(71));
                listePays.Add(new Pays(codeGroupe, codeContinent, nom, capitale, superficie, population));
            }
            sr.Close();
            Console.WriteLine(" - Fin de la lecture du fichier {0}. Il contient {1} pays.", nomFichier, listePays.Count);
            return listePays;
        }


        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }


        // Point d'entré du programme
        static void Main(string[] args)
        {
            const string fileName = "WorldCup_2018.txt";
            List<Pays> listePays = new List<Pays>();

            // 1. Lire le fichier des données WorldCup_2018.txt et créer une  liste;
            AfficheTitre("1. Lire le fichier des données WorldCup_2018.txt et créer une liste :");
            listePays = LireFichier(fileName);
            Console.WriteLine("");


            AfficherListe(listePays, listePays.Count);

            // 2. Afficher les 6 premiers et les 4 derniers pays de la liste;
            AfficheTitre("2. Afficher les 6 premiers et les 4 derniers pays de la liste :");
            AfficherListe(listePays, 6, 4);
            Console.WriteLine("");


            // 3a. Modifier le groupe du premier  pays ‘A’ au lieu de ‘Z’
            AfficheTitre("3a. Modifier le groupe du premier  pays ‘A’ au lieu de ‘Z’ :");
            ModifierGroupePosition(listePays, 0, 'A');
            Console.WriteLine("");

            // 3b. Modifier la superficie du dernier pays : 449964 km2 au lieu de 944964 km2
            AfficheTitre("3b. Modifier la superficie du dernier pays : 449964 km2 au lieu de 944964 km2 :");
            ModifierSuperficiePosition(listePays, listePays.Count-1, 449964);
            Console.WriteLine("");


            // 4. Supprimer les deux pays qui ne sont pas qualifiés pour cette coupe : ITALIE et SUISSE
            AfficheTitre("4. Supprimer les deux pays qui ne sont pas qualifiés pour cette coupe :");
            List<string> paysToDelete = new List<string> { "ITALIE", "SUISSE" };
            SupprimerPays(listePays, paysToDelete);
            Console.WriteLine("");


            // 5. Ajouter la France à la liste : C, 5, FRANCE, PARIS, 543964, 61387038
            AfficheTitre("5. Ajouter la France à la liste :");
            Pays france = new Pays('C', '5', "FRANCE", "PARIS", 543964, 61387038);
            AjouterPays(listePays, france);
            Console.WriteLine("");


            // 6a. Déterminer et afficher le continent ayant plus de pays participants;
            AfficheTitre("6a. Déterminer et afficher le continent ayant plus de pays participants :");
            AfficherContinentPlusPays(listePays);
            Console.WriteLine("");

            // 6b. Déterminer et afficher le continent ayant le moins de pays participants;
            AfficheTitre("6b. Déterminer et afficher le continent ayant le moins de pays participants :");
            AfficherContinentMoinsPays(listePays);
            Console.WriteLine("");

            // 6c. Déterminer et afficher le pays le moins peuplé en population
            AfficheTitre("6c. Déterminer et afficher le pays le moins peuplé en population :");
            AfficherPaysMoinsPeuple(listePays);
            Console.WriteLine("");

            // 6d. Déterminer et afficher le pays le plus petit en superficie
            AfficheTitre("6d. Déterminer et afficher le pays le plus petit en superficie :");
            AfficherPaysMoinsSuperficie(listePays);
            Console.WriteLine("");


            // 7. Trier la liste selon les noms des pays en utilisant la méthode Sort;
            AfficheTitre("7. Trier la liste selon les noms des pays en utilisant la méthode Sort :");
            TrierListeParPays(listePays);
            Console.WriteLine("");


            // 8. Afficher les 6 premiers et les 4 derniers pays de la liste après le tri
            AfficheTitre("8. Afficher les 6 premiers et les 4 derniers pays de la liste après le tri :");
            AfficherListe(listePays, 6, 4, "après le tri");
            Console.WriteLine("");
            

            // 9. Faire la recherche des pays suivants dans la liste : Japon,  Canada et Italie
            AfficheTitre("9. Faire la recherche des pays suivants dans la liste : Japon,  Canada et Italie :");
            List<string> cherchePays = new List<string> {"Japon", "Canada", "Italie" };
            AfficherDetailPays(listePays, cherchePays);
            Console.WriteLine("");


            // 10. Déterminer et d’afficher les pays que le Bresil les affrontera au 1er tour (ceux du même groupe que le Brésil)
            AfficheTitre("10. Déterminer et d’afficher les pays que le Bresil les affrontera au 1er tour :");
            AfficherAdversairePays(listePays, "Bresil");
            Console.WriteLine("");

        }
    }
}
