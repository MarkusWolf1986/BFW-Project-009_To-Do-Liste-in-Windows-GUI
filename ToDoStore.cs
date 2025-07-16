using System;
using System.Collections.Generic;
using System.IO; // Für Dateioperationen wie Lesen/Schreiben

namespace To_Do_Liste_in_Windows_GUI
{
    // Diese Klasse ist dafür zuständig, ToDos in einer CSV-Datei zu speichern und wieder zu laden.
    public static class ToDoStore
    {
        // Der Dateipfad, unter dem die CSV-Datei gespeichert wird.
        // Die Datei liegt im gleichen Ordner wie die .exe der Anwendung.
        private static string dateipfad = "todos.csv";

        // Diese Methode speichert eine Liste von ToDos in der CSV-Datei.
        public static void Speichern(List<ToDo> todos)
        {
            // "using" sorgt dafür, dass die Datei nach dem Schreiben automatisch wieder geschlossen wird.
            using (var writer = new StreamWriter(dateipfad))
            {
                // Wir gehen jedes ToDo einzeln durch
                foreach (var todo in todos)
                {
                    // Wir bauen eine CSV-Zeile aus den drei Eigenschaften:
                    // Text;Erstelldatum;Erledigt-Status
                    // ":o" formatiert das Datum als ISO-8601 (z. B. 2025-07-16T19:24:00)
                    string zeile = $"{todo.Text};{todo.Erstellt:o};{todo.Erledigt}";

                    // Die Zeile wird in die Datei geschrieben
                    writer.WriteLine(zeile);
                }
            }
        }

        // Diese Methode lädt die ToDos aus der CSV-Datei und gibt sie als Liste zurück.
        public static List<ToDo> Laden()
        {
            // Leere Liste vorbereiten, in die wir die geladenen ToDos einfügen
            var liste = new List<ToDo>();

            // Wenn die Datei noch nicht existiert (z. B. beim ersten Start), geben wir einfach eine leere Liste zurück
            if (!File.Exists(dateipfad))
                return liste;

            // Lies alle Zeilen der Datei auf einmal in ein String-Array
            var zeilen = File.ReadAllLines(dateipfad);

            // Wir verarbeiten jede Zeile einzeln
            foreach (var zeile in zeilen)
            {
                // Jede Zeile wird mit ";" getrennt in einzelne Teile aufgeteilt
                var teile = zeile.Split(';');

                // Sicherheitscheck: Es müssen genau 3 Teile vorhanden sein
                if (teile.Length != 3)
                    continue; // überspringe fehlerhafte Zeile

                try
                {
                    // Erzeuge ein neues ToDo und befülle es mit den Daten aus der CSV-Zeile
                    var todo = new ToDo
                    {
                        Text = teile[0],                             // Der Aufgabentext
                        Erstellt = DateTime.Parse(teile[1]),         // Das Erstelldatum
                        Erledigt = bool.Parse(teile[2])              // Der Erledigt-Status
                    };

                    // Füge das ToDo der Liste hinzu
                    liste.Add(todo);
                }
                catch
                {
                    // Wenn beim Parsen ein Fehler auftritt, wird die Zeile übersprungen.
                    // (z. B. bei beschädigten oder falsch formatierten Daten)
                    continue;
                }
            }

            // Am Ende geben wir die vollständige Liste zurück
            return liste;
        }
    }
}
