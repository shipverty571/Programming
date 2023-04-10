using System.Windows;
using Contacts.ViewModel;

namespace Contacts
{
    /// <summary>
    ///  Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainVM();
            DataContext = vm;
        }
    }
}