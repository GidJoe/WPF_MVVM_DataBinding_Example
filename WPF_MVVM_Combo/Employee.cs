namespace WPF_MVVM_Combo
{
    /* Wir erstellen hier ein sogenanntes Model.
     * Hier setzten wir die Properties (Attribute) fest, die wir in unserer SQLite Datenbank haben.
     * Nun können wir ein Objekt vom Typ Employee erstellen und jedes Objekt hat die Properties Id, FirstName und LastName.
     * und hinter FormattedName verbirgt sich eine Methode, die uns den Namen des Employees formatiert als String zurückgibt.
     *
     * ==> siehe nun in zeile 6 im DatabaseHelper.cs
     */
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FormattedName => $"{Id} - {FirstName} {LastName}";

    }
}