using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osszefoglalas
{
    class Ember
    {
        public string Nev;
        public int Kor;
        public int Magassag;

        public Ember(string nev, int kor, int magassag)
        {
            Nev = nev;
            Kor = kor;
            Magassag = magassag;
        }

        public override string ToString()
        {
            return $"Név: {Nev}, kor: {Kor}, magasság: {Magassag}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Primitiv tipusok
            string szoveg = "Ez egy szoveg";
            char karakter = 'C';
            int egesz = 10;
            double tort = 10.756;
            bool logikai = false;

            // Osszetett tipusok adatszerekezetek

            int[] tomb = new int[10]; // 10 elemu tomb - statikus
            List<int> lista = new List<int>(); // Dinamikus adatszerkezet
            Dictionary<string, int> dict = new Dictionary<string, int>(); // Kulcs-érték párok tárolása (foreach)

            DateTime dt = new DateTime(1996,8,9,1,26,30);
            DateTime dt2 = new DateTime(2018, 8, 9, 1, 26, 30);

            TimeSpan ts = dt2 - dt; // Időintervallum két DateTime kozott.

            Console.WriteLine(ts.TotalSeconds);
            Console.WriteLine(ts.TotalMinutes);
            Console.WriteLine(ts.TotalHours);
            Console.WriteLine(ts.TotalDays);
            Console.WriteLine(ts.Hours);
            Console.WriteLine(ts);

            // Osztályok + LINQ
            Ember jani = new Ember("János", 20, 180);
            Ember mate = new Ember("Máté", 22, 189);
            Ember bela = new Ember("Béla", 17, 156);
            Ember peter = new Ember("Péter", 36, 178);
            Ember laci = new Ember("László", 20, 160);

            List<Ember> emberek = new List<Ember>() { jani, peter, bela, mate, laci };

            // Select()
            List<string> nevek = emberek.Select(ember => ember.Nev).ToList();
            List<int> korok = emberek.Select(ember => ember.Kor).ToList();
            List<int> magassagok = emberek.Select(ember => ember.Magassag).ToList();

            // OrderBy() - Osszetett objektumokat tartalmazó listák rendezésére
            List<Ember> rendezettEletkorSzerint = emberek.OrderBy(ember => ember.Kor).ToList();

            // Max(), Min(), Count()
            int maxMagassag = emberek.Max(ember => ember.Magassag); // Maximum keresés
            int minimumKor = emberek.Min(ember => ember.Kor); // Minimum keresés
            int parosKoruakSzama = emberek.Count(ember => ember.Kor % 2 == 0); // Feltételes megszámolás

            // Any(), Find(), FindAll()
            // Van-e 190 cm-nel magasabb ember a listaban?
            bool vanEBatár = emberek.Any(ember => ember.Magassag > 190); // Eldontés tétel

            // Keressük meg azt az Embert, akinek Péter a neve;
            Ember megtaláltPeti = emberek.Find(ember => ember.Nev == "Péter");
            int petiIndexe = emberek.IndexOf(megtaláltPeti);

            // Keressük meg azt az Embert, aki 20 évnél idősebb
            Ember idősebb = emberek.Find(ember => ember.Kor > 20); // Ha tobb elem is megfelel a feltételnek, akkor az első előfordulást adja vissza
            Console.WriteLine(idősebb);

            // Válogassuk ki a 160 cm-nél magasabbakat
            List<Ember> magasabbak = emberek.FindAll(ember => ember.Magassag > 160);

        }
    }
}
