using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinosaal
{
    //  Repräsentiert einen Kinosaal mit einer festen Anzahl Reihen und Spalten.
    // Sitzplätze werden als Zeichen im 2D-Array <see cref="saal"/> gespeichert.
     
    internal class Kinosaal
    {
        public int AnzahlReihen { get; set; } = 0; // Anzahl der Reihen im Kinosaal
        public int AnzahlSpalten { get; set; } = 0; // Anzahl der Spalten pro Reihe im 
        
        private char[,] saal;  // 2D-Array zur Darstellung des Sitzplans.
                              // Konvention für Sitzwerte (Beispiel):
                              // 'B' = Belegen, 'R' = Reserviert, 'F' = frei

        public Kinosaal(int r, int s)
        {  
            AnzahlReihen = r; 
            AnzahlSpalten = s;
            saal = new char[r, s];
        }

        
        public void Ausgeben(int r, int s)
        {
            char wert = saal[r, s];
            Console.Write(" ");
            if (wert == 'B') 
                Console.ForegroundColor = ConsoleColor.Red;   // Farbe auf Rot setzen
            else if (wert=='R')
                Console.ForegroundColor = ConsoleColor.Blue; // 
            else
                Console.ForegroundColor = ConsoleColor.Green; // 
            Console.Write(wert);
            Console.ResetColor();                         // Konsolenfarbe wieder zurücksetzen
            Console.Write(" |");
        }

        public void Freigeben() 
        {
            for (int i = 0; i < AnzahlReihen; i++)
            {
                for (int j = 0; j < AnzahlSpalten; j++)
                {
                    saal[i,j] = 'F';
                }
            }
        }

        public void Reservieren(int r, int s)
        {
            char wert = saal[r - 1, s - 1];
            ZustandZeigen(r, s, wert);
            if (wert == 'F')
            {
                saal[r - 1, s - 1] = 'R';
                Console.WriteLine($"--> Platz[{r},{s}] wurde erfolgreich reserviert!");
            }
        }

        private void ZustandZeigen(int r, int s, char wert)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (wert == 'B')
                Console.WriteLine($"!!!Platz[{r},{s}] ist belegt!");
            if (wert == 'R')
                Console.WriteLine($"!!!Platz[{r},{s}] ist reserviert!");
            Console.ResetColor();
        }

        
        public void Belegen(int r, int s)
        {
            char wert = saal[r - 1, s - 1];
            ZustandZeigen(r, s, wert);
            if (wert == 'F')
            {
                saal[r - 1, s - 1] = 'B';
                Console.WriteLine($"--> Platz[{r},{s}] wurde erfolgreich belegt!");
            }
        }

        public void Visualisieren()
        {
            Console.WriteLine("=================== Visueller Saalplan ===================");
            Console.WriteLine("==========================================================");
            TrennlinieDrucken();
            Console.Write("             |   |");
            for (int j = 1; j <= AnzahlSpalten; j++)
            { 
                if (j>=10)
                    Console.Write($" {j}|"); 
                else
                    Console.Write($" {j} |");

            }
            Console.WriteLine();
            TrennlinieDrucken();
            for (int i = 0; i < AnzahlReihen; i++)
            {
                if (i >= 9)
                    Console.Write($"             | {i + 1}|");
                else
                    Console.Write($"             | {i + 1} |");

                for (int j = 0; j < AnzahlSpalten; j++)
                    {
                        Ausgeben(i, j);
                    }
                Console.Write("\n");
                TrennlinieDrucken();
            }
        }

        private void TrennlinieDrucken()
        {
            Console.Write("             +----");
            for (int j = 0; j < AnzahlSpalten; j++) Console.Write($"----");
            Console.WriteLine();
        }
    }
}
