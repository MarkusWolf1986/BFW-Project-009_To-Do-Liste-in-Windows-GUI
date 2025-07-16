using System;

namespace To_Do_Liste_in_Windows_GUI
{
    // Die ToDo-Klasse ist der "Bauplan" für alle ToDo-Objekte
    public class ToDo
    {
        // EIGENSCHAFTEN (Properties) - Das sind die "Daten" die jedes ToDo-Objekt hat

        // Der Text der Aufgabe (z.B. "Einkaufen gehen")
        public string Text { get; set; }

        // Wann wurde diese Aufgabe erstellt? (Datum + Uhrzeit)
        public DateTime Erstellt { get; set; }

        // Ist die Aufgabe schon erledigt? (true = ja, false = nein)
        public bool Erledigt { get; set; }

        // KONSTRUKTOR - Wird automatisch aufgerufen, wenn ein neues ToDo erstellt wird
        public ToDo()
        {
            // Setze das Erstelldatum auf "jetzt"
            Erstellt = DateTime.Now;

            // Neue Aufgaben sind erstmal nicht erledigt
            Erledigt = false;

            // Text wird später gesetzt (von der TextBox)
        }

        // METHODEN - Das sind "Aktionen" die mit einem ToDo-Objekt gemacht werden können

        // Markiert die Aufgabe als erledigt
        public void Done()
        {
            Erledigt = true;
        }

        // Markiert die Aufgabe wieder als offen
        public void NotDone()
        {
            Erledigt = false;
        }

        // Bestimmt, wie das ToDo in der ListBox angezeigt wird
        public override string ToString()
        {
            // Zeige [✓] für erledigte, [ ] für offene Aufgaben
            string status = Erledigt ? "[✓]" : "[ ]";
            return $"{status} {Text}";
        }
    }
}