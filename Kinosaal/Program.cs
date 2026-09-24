using System.Reflection.Emit;

namespace Kinosaal;

// Hauptprogramm für die Konsolenanwendung zur Verwaltung eines Kinosaals.
// Führt die Initialisierung, die Hauptschleife und das Speichern/Laden des Saals aus.
internal class Program
{
    // Instanz des Kinosaals mit Standardwerten (Reihen, Spalten, Name, Film).
    public static Kinosaal saal = new Kinosaal(8, 18, "Oscar", "Der letzte Sommer"); 
    // Menüinstanz zur Eingabe durch den Benutzer.
    static Menue menue = new Menue();
    // Variable für die Auswahl im Hauptmenü.
    static char hauptAuswahl = ' ';
    // Auswahlparameter für Reihe und Spalte.
    static int ausgewaehlteReihe = 0;
    static int ausgewaehlteSpalte = 0;
    // Rückmeldungsnachricht für den Benutzer.
    static string nachricht = "";

    // Einstiegspunkt der Anwendung.
    static void Main(string[] args)
    {
        // Versucht, den Saal aus der Datei zu laden (falls vorhanden).
        saal.SaalLaden();       

        // Hauptschleife des Programms: Anzeige, Eingabe und Aktionen verarbeiten.
        do
        {
            Begruessung("========================================================================", true);
            Begruessung("Herzlich willkommen im Kinosaal - Ticketverwaltungssystem 'Kino Central'");
            Begruessung("========================================================================");
            NachrichtAusgeben();
            saal.Visualisieren();   // Saalplan darstellen
            hauptAuswahl = menue.Hauptmenue();     // Hauptmenü wird angezeigt und Auswahl gelesen
            if (hauptAuswahl == 'b' || hauptAuswahl == 'r')
            {
                // Benutzer wählt Reihe und Sitz
                ausgewaehlteReihe = menue.Eingabe("Reihennummer", saal.AnzahlReihen);
                ausgewaehlteSpalte = menue.Eingabe("Sitznummer", saal.AnzahlSpalten);
                if (hauptAuswahl == 'b')
                    nachricht = saal.Belegen(ausgewaehlteReihe, ausgewaehlteSpalte);
                else
                    nachricht = saal.Reservieren(ausgewaehlteReihe, ausgewaehlteSpalte);
            }
            else if (hauptAuswahl == 'f')
            {
                // Alle Plätze freigeben
                nachricht = saal.Freigeben();
                //Begruessung("   Alle Plätze können erneut gebucht werden  ");
            }
            //Console.WriteLine("Bitte drücken Sie eine beliebige Taste, um den Saalplan zu aktualisieren.");
            //Console.ReadKey();
        }
        while (hauptAuswahl != 'e');

        // Vor dem Beenden Saal in Datei speichern
        saal.SaalSpeichern();
        Begruessung("Vielen Dank, dass Sie unser System genutzt haben.Ich wünsche Ihnen einen schönen Tag!");
    }

    // Gibt die aktuelle Nachricht (Erfolg oder Fehler) auf der Konsole aus.
    private static void NachrichtAusgeben()
    {
        if (nachricht != "")
        {
            Console.WriteLine();
            if (nachricht.Substring(0, 3) == "!!!") Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(nachricht);
            Console.ResetColor();
        }
    }

    // Gibt eine Begrüßungs- oder Informationszeile in einer bestimmten Farbe aus.
    static void Begruessung(string gruess, bool clear = false) 
    {
        if (clear) 
            Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(gruess);
        Console.ResetColor();
    }

}
