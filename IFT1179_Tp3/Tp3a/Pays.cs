
using System;

/* ************************
 *      IFT1179 - TP3
 * Stéphane Barthélemy
 *        20084771
 ************************ */

namespace Tp3A
{
    internal class Pays : IComparable
    {
        private char codeContinent;
        private string nom;
        private string capitale;
        private int superficie;
        private int population;

        // Propriétés
        public char Continent { get => codeContinent; set => codeContinent = value; }
        public string Capitale { get => capitale; set => capitale = value.ToUpper(); }
        public int Population { get => population; set => population = value; }

        public enum EnumContinent {
            Afrique=1,
            Amérique=2,
            Asie=3,
            Océanie=4,
            Europe=5
        };

        // Contructeur
        public Pays(char codeContinent, string nom, string capitale, int superficie, int population)
        {
            this.codeContinent = codeContinent;
            this.nom = nom;
            this.capitale = capitale;
            this.superficie = superficie;
            this.population = population;
        }

        // Renvoie le nom du continent en fonction de son code
        private object GetContinentName(char code)
        {
            return Enum.GetName(typeof(EnumContinent), int.Parse(code.ToString()));
        }

        // Redéfinition ToString
        public override string ToString()
        {
            return string.Format("Continent : {0,-10} - Pays : {1,-12} - Capitale : {2,-10} - Superfie (km²) : {3,-8} - Population : {4}",
                GetContinentName(codeContinent), nom, capitale, superficie, population);
        }

        // Redéfinition Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is Pays)) return false;

            var autre = (Pays)obj;
            return nom.ToUpper().Trim().Equals(autre.nom.ToUpper().Trim());
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