using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinosaal;


internal class Menue
{
    // Klasse für die Benutzereingabe und Anzeige des Hauptmenüs.

    // Zeigt das Hauptmenü an und gibt die Auswahl des Benutzers zurück.
      public char Hauptmenue() 
    {
        Console.WriteLine("===============================================================================");
        // Erwartete Eingaben: b, r, f, e
        return Eingabe("Bitte wählen: (b)elegen, (r)eservieren, (f)reigeben oder b(e)enden", "b r f e"); ;           
    }

    // Liest eine numerische Eingabe vom Benutzer (z. B. Reihennummer oder Sitznummer)
    // und validiert den Bereich (1..max).
    public int Eingabe(string was, int max)
    {
        int wert=0;
        bool check;
        do
        {
            Console.Write($"Bitte geben Sie {was} (1-{max}) ein: ");
            check = int.TryParse((Console.ReadLine()), out wert);

            if (!check || wert < 1 || wert > max)
            {
                Console.WriteLine();
                Console.WriteLine($"Bitte geben Sie nur Ziffern (1-{max}) ein!!! (und keine negative Zahl sein) ");
                check = false;
            }
            Console.WriteLine();
        }
        while (!check);
        return wert;
    }

    // Liest eine einzelne Zeichen-Eingabe und prüft, ob sie im erlaubten Bereich liegt.
    public char Eingabe(string was, string bereich)
    {
        char wert = ' ';

        bool check;
        do
        {
            Console.Write($"Bitte geben Sie {was} ein: ");
            check = char.TryParse((Console.ReadLine().ToLower()), out wert);

            if (!check || !bereich.Contains(wert))
            {
                Console.WriteLine();
                Console.WriteLine($"Bitte geben Sie nur ({bereich}) ein!!! (und keine negative Zahl sein) ");
                check = false;
            }
            Console.WriteLine();
        }
        while (!check);
        return wert;
    }

    
}
