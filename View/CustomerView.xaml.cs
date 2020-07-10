using Data.ViewModels;
using System.Windows.Controls;

namespace View
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    {
        public CustomerView()
        {
            InitializeComponent();

            DataContext = new CustomerViewModel();

        }
    }
}
