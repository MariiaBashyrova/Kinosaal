using System.Reflection.Emit;

namespace Kinosaal;

internal class Program
{
    public static Kinosaal saal = new Kinosaal(8, 18, "Oscar", "Der letzte Sommer"); 
    static Menue menue = new Menue();
    static char hauptAuswahl = ' ';
    static int ausgewaehlteReihe = 0;
    static int ausgewaehlteSpalte = 0;
    static string nachricht = "";
    static void Main(string[] args)
    {
        saal.SaalLaden();       

        do
        {
            Begruessung("========================================================================", true);
            Begruessung("Herzlich willkommen im Kinosaal - Ticketverwaltungssystem 'Kino Central'");
            Begruessung("========================================================================");
            NachrichtAusgeben();
            saal.Visualisieren();   // Darstellen 
            hauptAuswahl = menue.Hauptmenue();     // Hauptmenü wird angezeigt 
            if (hauptAuswahl == 'b' || hauptAuswahl == 'r')
            {
                ausgewaehlteReihe = menue.Eingabe("Reihennummer", saal.AnzahlReihen);
                ausgewaehlteSpalte = menue.Eingabe("Sitznummer", saal.AnzahlSpalten);
                if (hauptAuswahl == 'b')
                    nachricht = saal.Belegen(ausgewaehlteReihe, ausgewaehlteSpalte);
                else
                    nachricht = saal.Reservieren(ausgewaehlteReihe, ausgewaehlteSpalte);
            }
            else if (hauptAuswahl == 'f')
            {
                nachricht = saal.Freigeben();
                //Begruessung("   Alle Plätze können erneut gebucht werden  ");
            }
            //Console.WriteLine("Bitte drücken Sie eine beliebige Taste, um den Saalplan zu aktualisieren.");
            //Console.ReadKey();
        }
        while (hauptAuswahl != 'e');
        saal.SaalSpeichern();
        Begruessung("Vielen Dank, dass Sie unser System genutzt haben.Ich wünsche Ihnen einen schönen Tag!");
    }

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

    static void Begruessung(string gruess, bool clear = false) 
    {
        if (clear) 
            Console.Clear();
        
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(gruess);
        Console.ResetColor();
    }

}
