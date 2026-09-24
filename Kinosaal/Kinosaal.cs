using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinosaal;

//  Repräsentiert einen Kinosaal mit einer festen Anzahl Reihen und Spalten.
// Sitzplätze werden als Zeichen im 2D-Array <see cref="saal"/> gespeichert.
 
internal class Kinosaal
{
    // Anzahl der Reihen im Kinosaal
    public int AnzahlReihen { get; set; } = 0; // Anzahl der Reihen im Kinosaal
    // Anzahl der Spalten pro Reihe im Kinosaal
    public int AnzahlSpalten { get; set; } = 0; // Anzahl der Spalten pro Reihe im Kinosaal

    // 2D-Array zur internen Darstellung des Sitzplans.
    // Konvention für Sitzwerte: 'B' = Belegt, 'R' = Reserviert, 'F' = Frei
    private char[,] saal;  // 2D-Array zur Darstellung des Sitzplans.

    // Name des Saals (Anzeigezweck)
    private string Saalname { get; set; }

    // Aktueller Filmtitel im Saal (Anzeigezweck)
    private string Filmtitel { get; set; }

    // Konstruktor: Initialisiert die Anzahl Reihen/Spalten, das interne Array
    // und setzt den Saalnamen sowie den Filmtitel.
    public Kinosaal(int r, int s, string saalname, string filmtitel)
    {  
        AnzahlReihen = r; 
        AnzahlSpalten = s;
        saal = new char[r, s];
        Saalname = saalname;
        Filmtitel = filmtitel;
    }

    
    // Gibt den Wert eines bestimmten Sitzes in der Konsole aus.
    // Parameter: r = Zeilenindex, s = Spaltenindex (nullbasiert für interne Darstellung).
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

    // Setzt alle Plätze im Saal auf 'F' (frei) und gibt eine Bestätigungsnachricht zurück.
    public string Freigeben() 
    {
        for (int i = 0; i < AnzahlReihen; i++)
        {
            for (int j = 0; j < AnzahlSpalten; j++)
            {
                saal[i,j] = 'F';
            }
        }
        return "   Alle Plätze können erneut gebucht werden  ";
    }

    // Versucht, einen Platz zu reservieren (1-basierte Eingabe für r und s).
    // Prüft vorher den Zustand und gibt eine Ergebnisnachricht zurück.
    public string Reservieren(int r, int s)
    {
        char wert = saal[r - 1, s - 1];
        string nachricht = "";
        ZustandZeigen(r, s, wert, ref nachricht);
        if (wert == 'F')
        {
            saal[r - 1, s - 1] = 'R';
            nachricht=$"--> Platz[{r},{s}] wurde erfolgreich reserviert!";
        }
        return nachricht; 
    }

    // Prüft den Zustand eines Platzes und setzt eine Fehlernachricht,
    // falls der Platz bereits belegt oder reserviert ist.
    // Wird intern von Belegen/Reservieren verwendet.
    private void ZustandZeigen(int r, int s, char wert, ref string nachricht)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (wert == 'B')
            nachricht=$"!!!Platz[{r},{s}] ist belegt! Die Aktion wurde abgelehnt";
        if (wert == 'R')
            nachricht = $"!!!Platz[{r},{s}] ist reserviert! Die Aktion wurde abgelehnt";
        Console.ResetColor();
    }

    
    // Belegt einen Platz (1-basierte Indizes). Prüft zuvor den Zustand
    // und gibt eine Erfolg- oder Fehlermeldung zurück.
    public string Belegen(int r, int s)
    {
        char wert = saal[r - 1, s - 1];
        string nachricht = "";
        ZustandZeigen(r, s, wert, ref nachricht);
        if (wert == 'F')
        {
            saal[r - 1, s - 1] = 'B';
            nachricht = $"--> Platz[{r},{s}] wurde erfolgreich belegt!";
        }
        return nachricht;
    }

    // Visualisiert den Saalplan in der Konsole inklusive Kopfzeile und Statistik.
    // Zeichnet die Sitznummern, Reihen und ruft für jeden Platz die Ausgabe-Methode auf.
    public void Visualisieren()
    {
        Console.WriteLine($"Saal: {Saalname} | Film: {Filmtitel}");
        StatistikAnzeigen();

        Console.WriteLine(); 
        Console.WriteLine("          Visueller Saalplan");
        Console.WriteLine();

        TrennlinieDrucken();
        Console.Write(" |   |");
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
                Console.Write($" | {i + 1}|");
            else
                Console.Write($" | {i + 1} |");

            for (int j = 0; j < AnzahlSpalten; j++)
                {
                    Ausgeben(i, j);
                }
            Console.Write("\n");
            TrennlinieDrucken();
        }
    }

    // Druckt eine Trennlinie für die visuelle Darstellung des Saalplans.
    // Diese Methode wird intern von Visualisieren verwendet.
    private void TrennlinieDrucken()
    {
        Console.Write(" +----");
        for (int j = 0; j < AnzahlSpalten; j++) Console.Write($"----");
        Console.WriteLine();
    }

    // Ermittelt und zeigt Statistiken zum Saal an:
    // Anzahl freier, reservierter und verkaufter Plätze sowie Auslastungen.
    public void StatistikAnzeigen()
    {
        int frei = 0;
        int reserviert = 0;
        int verkauft = 0;

        int rows = saal.GetLength(0);
        int seats = saal.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < seats; j++)
            {
                switch (saal[i, j])
                {
                    case 'F':
                        frei++;
                        break;

                    case 'R':
                        reserviert++;
                        break;

                    case 'B':
                        verkauft++;
                        break;
                }
            }
        }

        int gesamt = rows * seats;

        double gesamtauslastung = (double)(reserviert + verkauft) / gesamt * 100;
        double verkaufsauslastung = (double)verkauft / gesamt * 100;

        Console.WriteLine();
        Console.WriteLine(
            $"{DateTime.Now:dd.MM.yyyy HH:mm} | " +
            $"Plätze: {gesamt} | Frei: {frei} | Reserviert: {reserviert} | Verkauft: {verkauft}");

        Console.WriteLine(
            $"Auslastung: {gesamtauslastung:F1} % | " +
            $"Verkaufsauslastung: {verkaufsauslastung:F1} %");
    }




    // Speichert den aktuellen Sitzplan in die Datei "Saal.csv" (CSV-Format).
    public void SaalSpeichern()
    {
        using (StreamWriter writer = new StreamWriter("Saal.csv"))
        {
            for (int i = 0; i < saal.GetLength(0); i++)
            {
                for (int j = 0; j < saal.GetLength(1); j++)
                {
                    writer.Write(saal[i, j]);

                    if (j < saal.GetLength(1) - 1)
                    {
                        writer.Write(",");
                    }
                }

                writer.WriteLine();
            }
        }
    }

    // Lädt den Sitzplan aus der Datei "Saal.csv" falls vorhanden.
    // Falls die Datei nicht existiert, werden alle Plätze freigegeben.
    public void SaalLaden()
    {
        if (!File.Exists("Saal.csv"))
        {
            Freigeben();
            return;
        }
        string[] zeilen = File.ReadAllLines("Saal.csv");

        int rows = zeilen.Length;
        int seats = zeilen[0].Split(',').Length;

        saal = new char[rows, seats];

        for (int i = 0; i < rows; i++)
        {
            string[] werte = zeilen[i].Split(',');

            for (int j = 0; j < seats; j++)
            {
                saal[i, j] = werte[j][0];
            }
        }
    }
}
