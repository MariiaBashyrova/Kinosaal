using System.Reflection.Emit;

namespace Kinosaal;

internal class Program
{
    public static Kinosaal saal = new Kinosaal(10, 24); 
    static Menue menue = new Menue();
    static char hauptAuswahl = 'A';
    static int ausgewaehlteReihe = 0;
    static int ausgewaehlteSpalte = 0;
    static void Main(string[] args)
    {
        saal.Freigeben();       // erste Initialisierung 

        do
        {
            Begruessung("========================================================================",true);
            Begruessung("Herzlich willkommen im Kinosaal - Ticketverwaltungssystem 'Kino Central'");
            saal.Visualisieren();   // Darstellen 
            hauptAuswahl = menue.Hauptmenue();     // Hauptmenü wird angezeigt 
            if (hauptAuswahl == 'b' || hauptAuswahl == 'r')
            {
                ausgewaehlteReihe = menue.Eingabe("Reihennummer", saal.AnzahlReihen);
                ausgewaehlteSpalte = menue.Eingabe("Sitznummer", saal.AnzahlSpalten);
                if (hauptAuswahl == 'b')
                    saal.Belegen(ausgewaehlteReihe, ausgewaehlteSpalte);
                else
                    saal.Reservieren(ausgewaehlteReihe, ausgewaehlteSpalte);
            }
            else if (hauptAuswahl == 'f')
            { 
                saal.Freigeben();
                Begruessung("   Alle Plätze können erneut gebucht werden  ");
            }
            Console.WriteLine("Bitte drücken Sie eine beliebige Taste, um den Saalplan zu aktualisieren.");
            Console.ReadKey();
        }
        while (hauptAuswahl != 'e');
        Begruessung("Vielen Dank, dass Sie unser System genutzt haben.Ich wünsche Ihnen einen schönen Tag!");
    }

    static void Begruessung(string gruess, bool clear = false) 
    { 
        if (clear) Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(gruess);
        Console.ResetColor();
    }

}
