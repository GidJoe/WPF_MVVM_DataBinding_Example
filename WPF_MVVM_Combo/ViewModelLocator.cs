using System;

namespace WPF_MVVM_Combo
{


    /* Durch den ViewModelLocator können wir die ViewModel Instanz in der MainWindow.xaml.cs verwenden.
     * 
     * Zitiert aus der MainWindow.xaml.cs:
     * DataContext="{Binding ViewModel, Source={StaticResource Locator}}"
     *
     * Wir binden also die ViewModel Property des ViewModelLocator an das DataContext Property des MainWindow.
     * Zuerst binden wir die ViewModel Property an eine Resource (siehe App.xaml) mit dem Key "Locator".
     * Durch das Instsanzieren des ViewModelLocator wird die ViewModel Property des ViewModelLocator automatisch aufgerufen.
     * Hier unter der 'ViewModel Property' verbirgt sich die Instanzierung des 'ViewModels'.
     * 
     * Das ViewModel wird also automatisch instanziiert, sobald wir die ViewModel Property des ViewModelLocator ansprechen.
     * 
     * ==> siehe nun Zeile 11 in der ViewModel.cs
     * 
     */


    public class ViewModelLocator
    {
        private static ViewModel _mainViewModelInstance;

        public static ViewModel ViewModel
        {
            get
            {
                if (_mainViewModelInstance == null)
                {
                    _mainViewModelInstance = new ViewModel();
                }
                return _mainViewModelInstance;
            }
        }
    }
}
