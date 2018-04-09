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

        private static void AfficherAdversairePays(List<Pays> liste, string pays)
        {
            throw new NotImplementedException();
        }

        private static void AfficherDetailPays(List<Pays> liste, List<string> listePays)
        {
            throw new NotImplementedException();
        }

        private static void TrierListeParPays(List<Pays> liste)
        {
            throw new NotImplementedException();
        }

        private static void AfficherPaysMoinsSuperficie(List<Pays> liste)
        {
            throw new NotImplementedException();
        }

        private static void AfficherPaysMoinsPeuple(List<Pays> liste)
        {
            throw new NotImplementedException();
        }

        private static void AfficherContinentMoinsPays(List<Pays> liste)
        {
            throw new NotImplementedException();
        }

        private static void AfficherContinentPlusPays(List<Pays> liste)
        {
            throw new NotImplementedException();
        }

        // Ajout d'un pays à la liste
        private static void AjouterPays(List<Pays> liste, Pays pays)
        {
            liste.Add(pays);
            Console.WriteLine("Le pays suivant à été ajouté : {0}", pays.Nom);
        }

        private static void SupprimerPays(List<Pays> liste, List<string> listeToDelete)
        {
            throw new NotImplementedException();
        }

        private static void ModifierSuperficiePosition(List<Pays> liste, int count, int v)
        {
            throw new NotImplementedException();
        }

        private static void ModifierGroupePosition(List<Pays> liste, int v1, char v2)
        {
            throw new NotImplementedException();
        }

        private static void AfficherListe(List<Pays> liste, int premier, int dernier, string msg = "dans l'ordre initiale")
        {
            throw new NotImplementedException();
        }

        // Lit le fichier passé en paramètre, rempli le tableau avec les données lues et compte le nombre de personnes
        private static List<Pays> LireFichier(string nomFichier)
        {
            List<Pays> liste = new List<Pays>();
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
                liste.Add(new Pays(codeGroupe, codeContinent, nom, capitale, superficie, population));
            }
            sr.Close();
            Console.WriteLine(" - Fin de la lecture du fichier {0}. Il contient {1} pays.", nomFichier, liste.Count);
            return liste;
        }

        // Permet d'afficher l'énnoncé de ce qui est attendu
        private static void AfficheTitre(string msg)
        {
            string tabs = new String('-', msg.Length);
            Console.WriteLine("\n\n{0}", msg);
            Console.WriteLine("{0}\n", tabs);
        }

        static void Main(string[] args)
        {
            const string fileName = "WorldCup_2018.txt";
            List<Pays> listPays = new List<Pays>();

            // 1. Lire le fichier des données WorldCup_2018.txt et créer une  liste;
            AfficheTitre("1. Lire le fichier des données WorldCup_2018.txt et créer une  liste :");
            listPays = LireFichier(fileName);
            Console.WriteLine("");

            // 2. Afficher les 6 premiers et les 4 derniers pays de la liste;
            AfficheTitre("2. Afficher les 6 premiers et les 4 derniers pays de la liste :");
            AfficherListe(listPays, 6, 4);
            Console.WriteLine("");


            // 3a. Modifier le groupe du premier  pays ‘A’ au lieu de ‘Z’
            AfficheTitre("3a. Modifier le groupe du premier  pays ‘A’ au lieu de ‘Z’ :");
            ModifierGroupePosition(listPays, 1, 'A');
            Console.WriteLine("");

            // 3b. Modifier la superficie du dernier pays : 449964 km2 au lieu de 944964 km2
            AfficheTitre("3b. Modifier la superficie du dernier pays : 449964 km2 au lieu de 944964 km2 :");
            ModifierSuperficiePosition(listPays, listPays.Count, 449964);
            Console.WriteLine("");


            // 4. Supprimer les deux pays qui ne sont pas qualifiés pour cette coupe : ITALIE et SUISSE
            AfficheTitre("4. Supprimer les deux pays qui ne sont pas qualifiés pour cette coupe :");
            List<string> paysToDelete = new List<string> { "ITALIE", "SUISSE" };
            SupprimerPays(listPays, paysToDelete);
            Console.WriteLine("");


            // 5. Ajouter la France à la liste : C, 5, FRANCE, PARIS, 543964, 61387038
            AfficheTitre("5. Ajouter la France à la liste :");
            Pays france = new Pays('C', '5', "FRANCE", "PARIS", 543964, 61387038);
            AjouterPays(listPays, france);
            Console.WriteLine("");


            // 6a. Déterminer et afficher le continent ayant plus de pays participants;
            AfficheTitre("6a. Déterminer et afficher le continent ayant plus de pays participants :");
            AfficherContinentPlusPays(listPays);
            Console.WriteLine("");

            // 6b. Déterminer et afficher le continent ayant le moins de pays participants;
            AfficheTitre("6b. Déterminer et afficher le continent ayant le moins de pays participants :");
            AfficherContinentMoinsPays(listPays);
            Console.WriteLine("");

            // 6c. Déterminer et afficher le pays le moins peuplé en population
            AfficheTitre("6c. Déterminer et afficher le pays le moins peuplé en population :");
            AfficherPaysMoinsPeuple(listPays);
            Console.WriteLine("");

            // 6d. Déterminer et afficher le pays le plus petit en superficie
            AfficheTitre("6d. Déterminer et afficher le pays le plus petit en superficie :");
            AfficherPaysMoinsSuperficie(listPays);
            Console.WriteLine("");


            // 7. Trier la liste selon les noms des pays en utilisant la méthode Sort;
            AfficheTitre("7. Trier la liste selon les noms des pays en utilisant la méthode Sort :");
            TrierListeParPays(listPays);
            Console.WriteLine("");


            // 8. Afficher les 6 premiers et les 4 derniers pays de la liste après le tri
            AfficheTitre("8. Afficher les 6 premiers et les 4 derniers pays de la liste après le tri :");
            AfficherListe(listPays, 6, 4, "après le tri");
            Console.WriteLine("");


            // 9. Faire la recherche des pays suivants dans la liste : Japon,  Canada et Italie
            AfficheTitre("9. Faire la recherche des pays suivants dans la liste : Japon,  Canada et Italie :");
            List<string> cherchePays = new List<string> {"Japon", "Canada", "Italie" };
            AfficherDetailPays(listPays, cherchePays);
            Console.WriteLine("");


            // 10. Déterminer et d’afficher les pays que le Bresil les affrontera au 1er tour (ceux du même groupe que le Brésil)
            AfficheTitre("10. Déterminer et d’afficher les pays que le Bresil les affrontera au 1er tour :");
            AfficherAdversairePays(listPays, "Bresil");
            Console.WriteLine("");

        }
    }
}
