using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPF_MVVM_Combo
{
    public class ViewModel
    {
        public ObservableCollection<Employee> EmployeeCollection { get; set; } = new ObservableCollection<Employee>();


        /* Wir können die ObservableCollection auf 2 unterschiedliche Arten befüllen:
         * Wenn unsere SQLite Methode eine Liste zurückgibt, dann können wir diese Liste in eine ObservableCollection umwandeln
         * indem wir die Liste<Employee> in die ObservableCollection mit einer foreach Schleife einfügen.
         * siehe : PopulateEmployees()
         * 
         * 
         * Alternativ können wir auch die Methode GetAllEmployeesCollection() verwenden, die uns bereits eine ObservableCollection<Employee> zurückgibt.
         * siehe: PopulateEmployeesCollection()
         * 
         * Wenn wir nun ein UI-Element wie die ComboBox an die ObservableCollection<Employee> binden, dann wird die Combo-Box automatisch aktualisiert,
         * denn sobald die ObservableCollection in irgendeiner Form verändert wird, wird die Änderung automatisch an die UI-Elemente weitergegeben.
         * Wird also an irgendeiner Stelle die ObservableCollection<Employee> angesprochen (löschen, hinzufügen, ändern), dann 
         * wird die Änderung automatisch an die UI-Elemente weitergegeben und das UI-Element aktualisiert sich in Echtzeit.
         * 
         * Dies ist der große Vorteil der ObservableCollection gegenüber einer normalen Liste.
         * Der Speicherverbauch einer ObeservableCollection ist jedoch höher als der einer normalen Liste, weil die ObservableCollection
         * Ereignisse auslöst, wenn sich die Liste verändert. Zudem ist die ObservableCollection langsamer als eine normale Liste.
         * ________________________________________________________________
         * 
         * 
         * 
         * Wenn aus ViewModelLocator ein Objekt der ViewModel Klasse instanziiert wird, dann wird die PopulateEmployees() Methode aufgerufen.
         * Damit wird die EmployeeCollection mit Daten befüllt und die ComboBox kann sich nun an die EmployeeCollection binden.
         * Die Collection sorgt automatisch dafür, dass die ComboBox sich aktualisiert, wenn sich die Collection verändert.
         * Das passiert natürlich nur, wenn die Collection an die ComboBox gebunden ist.
         * 
         * Zitat:
         * <ComboBox ... ItemsSource="{Binding EmployeeCollection}" />
         *
         *  *ENDE*
         */


        public ViewModel()
        {
            //PopulateEmployees();

            PopulateEmployeesCollection();
        }

        public void PopulateEmployees()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            var employees = databaseHelper.GetAllEmployees();

            foreach (Employee employee in employees)
            {
                EmployeeCollection.Add(employee);
            }
        }

        public void PopulateEmployeesCollection()
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            EmployeeCollection = databaseHelper.GetAllEmployeesCollection();
        }

    }
}
