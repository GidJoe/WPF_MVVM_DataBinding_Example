using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;

/* In der ersten Using-Dirketive wird der SQLite Connection ein ConnectionString übergeben.
 * dann öffnen wir die Verbindung zur Datenbank mit connection.Open();
 * 
 * in der zweiten Using-Direktive wird ein SQLiteCommand Objekt instanziiert und der SQL-String übergeben.
 * Der SQL-String ist ein SQL-Statement, das wir an die Datenbank senden
 *  
 * In der dritten Using-Direktive wird ein SQLiteDataReader Objekt instanziiert.
 * der Reader bekommt das SQLiteCommand Objekt übergeben und führt das SQL-Statement aus.
 * 
 * Die Antwort des SQLite Query (Select * from Employees) wird in den Reader geschrieben.
 * Jedes Tuple (jede Zeile) wird als SQLiteDataReader Objekt in den Reader geschrieben.
 * und solange der Reader noch Daten hat, wird die Schleife durchlaufen.
 * Für jede Zeile wird ein neues Employee Objekt erstellt und die Properties werden mit den Daten aus dem Reader befüllt.
 * 
 * Durch reader.GetInt32(0) wird der Wert aus der ersten Spalte (Id) ausgelesen und in die Property Id des Employee Objekts geschrieben.
 * Durch reader.GetString(1) wird der Wert aus der zweiten Spalte (FirstName) ausgelesen und in die Property FirstName des Employee Objekts geschrieben.
 * Durch reader.GetString(2) wird der Wert aus der dritten Spalte (LastName) ausgelesen und in die Property LastName des Employee Objekts geschrieben.
 * 
 * zum Schluss geben wir die Liste(Oder ObservableCollection) mit allen Employee Objekten (nun gefüllt mit Daten aus der Datenbank) zurück.
 * 
 */





namespace WPF_MVVM_Combo
{
    public class DatabaseHelper
    {
        // Bitte Pfad anpassen zur Datenbank anpassen
        private const string ConnectionString = "Data Source=C:\\Users\\marc1\\Desktop\\WPF_MVVM_Combo\\WPF_MVVM_Combo\\employee.db;Version=3;";

        public List<Employee> GetAllEmployees()
        {

            List<Employee> employees = new List<Employee>();


            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Employees", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                            });
                        }

                    }

                }

                
            }
            return employees;
        }


        public ObservableCollection<Employee> GetAllEmployeesCollection()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Employees", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2)
                            });
                        }
                    }
                }
            }

            return employees;
        }

    }
}