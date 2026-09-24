

# Kundenauftrag / Mini-Projekt: Kinosaal-Ticketverwaltung „CineCentral“

**Themen:** Zweidimensionale Arrays, verschachtelte Schleifen, Konsolen-I/O & Menüführungslogik

**Auftraggeber:** Lichtspieltheater Central GmbH

**Projektphase:** Prototypentwicklung (MVP – *Minimum Viable Product*)

---

## Szenario & Ausgangslage

Das Programmkino „Kino Central“ stellt seinen Kassenservice um. Um den Einlass an der Abendkasse zu beschleunigen und dem Kassenpersonal einen schnellen Überblick zu ermöglichen, soll eine einfache Anwendung zur Sitzplatzverwaltung entwickelt werden.

Vor der Umsetzung einer komplexen Grafik-Oberfläche beauftragt uns die Geschäftsführung mit der Erstellung eines funktionsfähigen **Prototyps auf Konsolenbasis**.

---

## Fachliche Anforderungen (User Stories)

### **US-01: Visueller Saalplan**

> **Als** Kassenkraft
> **möchte ich** den aktuellen Belegungszustand des Kinosaals als übersichtliche Matrix sehen,
> **damit** ich freie, reservierte und belegte Plätze auf einen Blick erkennen und Kunden optimal beraten kann.

* **Akzeptanzkriterien:**
* Der Saal wird visuell in Reihen und Spalten auf der Konsole dargestellt.
* Freie Plätze werden mit `[F]` gekennzeichnet.
* Belegte Plätze werden mit `[B]` gekennzeichnet und in **Rot** hervorgehoben.
* Reservierte Plätze werden mit `[R]` gekennzeichnet und in **Blau** hervorgehoben.



### **US-02: Ticketbuchung & Reservierung**

> **Als** Kassenkraft
> **möchte ich** gezielt Plätze nach Reihe und Spalte (Sitz) auswählen sowie als belegt oder reserviert markieren können,
> **damit** der gewünschte Platz für Kunden blockiert wird.

* **Akzeptanzkriterien:**
* Auswahl der Aktion `(b)elegen` oder `(r)eservieren` über das Hauptmenü.
* Gezielte Abfrage der Reihe und Spalte.
* Der Status des gewählten Platzes wird im System angepasst und sofort auf dem Saalplan aktualisiert.



### **US-03: Stornierung / Freigabe**

> **Als** Kassenkraft
> **möchte ich** bestehende Reservierungen oder Verkäufe wieder stornieren können,
> **damit** frei gewordene Plätze wieder in den Verkauf gelangen.

* **Akzeptanzkriterien:**
* Auswahl der Aktion `(f)reigeben` über das Hauptmenü.
* Zurücksetzen des Platzstatus auf den Zustand `Frei [F]`.



---

## Technische Vorgaben & Hinweise

1. **Datenstruktur:** Arbeiten Sie mit einem zweidimensionalen Array (z. B. `char[,]`), um den Saal und seinen Belegungszustand abzubilden.
2. **Konsolen-Farbsteuerung:** Nutzen Sie `Console.ForegroundColor` für die farbige Darstellung der Buchstaben und setzen Sie die Farbe anschließend wieder zurück:
```csharp
Console.ForegroundColor = ConsoleColor.Red;   // Farbe auf Rot setzen
Console.Write("B");
Console.ResetColor();                         // Konsolenfarbe wieder zurücksetzen

```



---

## Beispielszenario zur Laufzeit

```text
   +---------+
   |1|2|3|4|5|
+------------+
|01|F|F|F|F|F|
+------------+
|02|F|F|R|F|F|   <- 'R' in Blau
+------------+
|03|F|F|B|B|F|   <- 'B' in Rot
+------------+
|04|F|F|F|F|F|
+------------+
|05|F|F|R|F|F|
+------------+
|06|F|B|F|F|F|
+------------+
|07|F|F|F|F|F|
+------------+
|08|F|F|F|F|F|
+------------+
|09|F|F|F|B|F|
+------------+
|10|F|F|F|F|F|
+------------+

Legende: [F] Frei | [R] Reserviert (Blau) | [B] Belegt (Rot)

Bitte wählen: (b)elegen, (r)eservieren, (f)reigeben
> b
Reihennummer eingeben: 3
Sitznummer eingeben: 2
-> Platz [03, 02] wurde erfolgreich belegt!

```

---

## Optionale Erweiterungen

* **Robustes CLI-Menü:** Vollständiges Abfangen ungültiger Eingaben mit `try-catch`-Blöcken bzw. `int.TryParse`, damit das Programm bei Fehleingaben stabil weiterläuft.
* **Statistikfunktionen:** Berechnung und Anzeige der aktuellen Saalauslastung in Prozent (Gesamtauslastung sowie reine Verkaufsauslastung).
* **Speichern & Laden:** Persistierung des aktuellen Saalzustands in einer Datei (z. B. CSV oder JSON).
* **OOP-Ansatz:** Kapselung der Logik in einer Klasse `Kinosaal` mit flexiblen Dimensionen (Reihen und Spalten über den Konstruktor festlegen) sowie Attributen für Saalname und aktueller Filmtitel & Datum.
* **Kategorien & Preisklassen:** Unterteilung des Saals in verschiedene Zonen (*Parkett*, *Loge*, *VIP*) mit individueller Preisberechnung.

---

## Abgabebedingungen

* **Frist:** Bis Freitag 8:00
* **Format:** Reichen Sie Ihre Solution als ZIP-Archiv ein.
*Namensschema:* `Nachname-Vorname-Kinosaal.zip` (z. B. `Mueller-Florian-Kinosaal.zip`)
* **Portfolio**: Sie können Ihr Projekt zusätzlich in Ihrem persönlichen GitHub-Repository veröffentlichen.