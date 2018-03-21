
/* ************************
 *      IFT1179 - TP3
 * Stéphane Barthélemy
 *        20084771
 ************************ */


namespace Tp3A
{
    internal class Pays
    {
        private char codeContinent;
        private string nom;
        private string capitale;
        private int superficie;
        private int population;

        // Contructeur
        public Pays(char codeContinent, string nom, string capitale, int superficie, int population)
        {
            this.codeContinent = codeContinent;
            this.nom = nom;
            this.capitale = capitale;
            this.superficie = superficie;
            this.population = population;
        }


    }
}