using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Apartment : IComparer<Apartment>
    {
        double cena;
        private double metraz;
        private double lokalizacja;
        private double wyposazenie;
        private double ilosc_pokoi;
        private double cena_mediow;
        private double komunikacja;
        public double score;
        private String rodzaj_ogrzewania;
        private String roznorodnosc_mediow;

        public Apartment(double cena, double metraz, double lokalizacja, double wyposazenie, double iloscPokoi, double cenaMediow, double komunikacja, string rodzajOgrzewania, string roznorodnoscMediow)
        {
            this.cena = cena;
            this.metraz = metraz;
            this.lokalizacja = lokalizacja;
            this.wyposazenie = wyposazenie;
            ilosc_pokoi = iloscPokoi;
            cena_mediow = cenaMediow;
            this.komunikacja = komunikacja;
            rodzaj_ogrzewania = rodzajOgrzewania;
            roznorodnosc_mediow = roznorodnoscMediow;
        }

        public string[] ToArrayStrings()
        {
            var s = new string[]
            {
                score.ToString(), cena.ToString(), metraz.ToString(), lokalizacja.ToString(), wyposazenie.ToString(),
                    ilosc_pokoi.ToString(), cena_mediow.ToString(), komunikacja.ToString(), rodzaj_ogrzewania, 
                    roznorodnosc_mediow
            };
            return s;
        }

        public int Compare(Apartment x, Apartment y)
        {
            if (x.score > y.score) return -1;
            else return 1;
        }
    }
}
