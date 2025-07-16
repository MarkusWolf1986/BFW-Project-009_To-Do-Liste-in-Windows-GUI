using System;
using System.Collections.Generic;
using System.IO;                // Für Dateioperationen
using System.Text.Json;         // Für JSON (De)Serialisierung

namespace To_Do_Liste_in_Windows_GUI
{
    // Die Klasse speichert und lädt ToDo-Listen in/aus einer Datei.
    // "static" bedeutet: Man muss kein Objekt von ToDoStore erzeugen,
    // sondern kann direkt auf die Methoden zugreifen.
    public static class ToDoStore
    {
        // Der Pfad zur Datei, in der die Aufgaben gespeichert werden.
        // In diesem Fall wird die Datei direkt im Projektordner erstellt.
        private static string dateipfad = "todos.json";

        // Speichert die übergebene Liste von ToDos dauerhaft in eine JSON-Datei.
        public static void Speichern(List<ToDo> todos)
        {
            // Wir wandeln die Liste in einen JSON-Text um.
            // WriteIndented sorgt für "schön lesbares" Format.
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            // Der JSON-Text wird in die Datei geschrieben.
            // Existiert die Datei noch nicht, wird sie automatisch erstellt.
            File.WriteAllText(dateipfad, json);
        }

        // Lädt ToDos aus der Datei – falls vorhanden – und gibt sie als Liste zurück.
        public static List<ToDo> Laden()
        {
            // Wenn die Datei nicht existiert (z. B. beim ersten Start),
            // geben wir einfach eine neue leere Liste zurück.
            if (!File.Exists(dateipfad))
                return new List<ToDo>();

            // Inhalt der Datei (also der gespeicherte JSON-Text) wird gelesen
            var json = File.ReadAllText(dateipfad);

            // Wir wandeln den JSON-Text zurück in eine Liste von ToDo-Objekten.
            // PropertyNameCaseInsensitive erlaubt z. B. "text" statt "Text" im JSON.
            return JsonSerializer.Deserialize<List<ToDo>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<ToDo>(); // Falls irgendwas schiefgeht, gib eine leere Liste zurück.
        }
    }
}
