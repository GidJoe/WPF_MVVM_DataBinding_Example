using System.Windows;
using WPF_MVVM_Combo;

namespace WPF_MVVM_Combo
{

    public partial class MainWindow : Window
    {
       /* Bei MVVM ist es wichtig, dass die View (MainWindow.xaml) nur die View ist und keine Logik enthält.
        * Durch Databinding in der XAML Datei können wir die View mit der ViewModel-Ebene verbinden.
        * Die ViewModel-Ebene enthält die Logiken und die Daten.
        * 
        * Die View (MainWindow.xaml) ist also nur für die Darstellung der Daten zuständig.
        * Anders gesagt, ist die die View nur eien XAML für die darstellung des User Interfaces.
        * 
        */
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}