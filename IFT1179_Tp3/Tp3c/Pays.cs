using System;
using System.Collections.Generic;


/* ************************
 *      IFT1179 - TP3
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace Tp3c
{
    internal class Pays : IComparable
    {
        // Code permettant de tester l'égalité
        public static EnumCodeEquals codeEquals = EnumCodeEquals.Nom;
        public enum EnumCodeEquals
        {
            Nom,
            Population,
            Superficie
        };

        private char codeGroupe;
        private char codeContinent;
        private string nom;
        private string capitale;
        private int superficie;
        private int population;

        // Propriétés
        public char Groupe { get => codeGroupe; set => codeGroupe = value; }
        public char Continent { get => codeContinent; set => codeContinent = value; }
        public string Nom { get => nom; set => nom = value.ToUpper(); }
        public string Capitale { get => capitale; set => capitale = value.ToUpper(); }
        public int Population { get => population; set => population = value; }
        public int Superficie { get => superficie; set => superficie = value; }

        public enum EnumContinent
        {
            Afrique = 1,
            Amérique = 2,
            Asie = 3,
            Océanie = 4,
            Europe = 5
        };

        // Contructeur
        public Pays(char codeGroupe, char codeContinent, string nom, string capitale, int superficie, int population)
        {
            this.codeGroupe = codeGroupe;
            this.codeContinent = codeContinent;
            this.nom = nom;
            this.capitale = capitale;
            this.superficie = superficie;
            this.population = population;
        }

        // Renvoie le nom du continent en fonction de son code
        public static string GetContinentNameByCode(char code)
        {
            return Enum.GetName(typeof(EnumContinent), int.Parse(code.ToString()));
        }


        // Renvoie le nom du continent
        public string GetContinentName()
        {
            return Enum.GetName(typeof(EnumContinent), int.Parse(codeContinent.ToString()));
        }

        // Redéfinition ToString
        public override string ToString()
        {
            return string.Format("Groupe : {0,2} - Continent : {1,-10} - Pays : {2,-24} - Capitale : {3,-14} - Superfie (km²) : {4,-8} - Population : {5}",
                codeGroupe, GetContinentName(), nom, capitale, superficie, population);
        }

        // Redéfinition Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Pays)) return false;

            var autre = (Pays)obj;

            switch (codeEquals)
            {
                // Égalité de population
                case EnumCodeEquals.Population:
                    return population.Equals(autre.population);

                // Égalité de superficie
                case EnumCodeEquals.Superficie:
                    return superficie.Equals(autre.superficie);

                //Égalité de nom
                default:
                    return nom.ToUpper().Trim().Equals(autre.nom.ToUpper().Trim());
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        // Comparaison
        public int CompareTo(object obj)
        {
            Pays autre = (Pays)obj;
            return nom.ToUpper().Trim().CompareTo(autre.nom.ToUpper().Trim());
            
        }
    }
}