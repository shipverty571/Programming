using System.Windows;
using System.Windows.Controls;
using Contacts.ViewModel;

namespace Contacts.Controls
{
    public partial class ContactControl : UserControl
    {
        public ContactVM SelectedContact
        {
            get => (ContactVM)GetValue(SelectedContactProperty);
            set => SetValue(SelectedContactProperty, value);
        }

        public static readonly DependencyProperty SelectedContactProperty =
            DependencyProperty.Register("SelectedContact", typeof(ContactVM),
                typeof(ContactControl), new UIPropertyMetadata(null));
            
        public ContactControl()
        {
            InitializeComponent();
        }
    }
}