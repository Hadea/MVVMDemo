using System.Windows;
using System.Windows.Controls;
using Data.ViewModels;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // so wenig Code wie möglich in die Code behind Datei.
            DataContext = new CustomerViewModel();
        }

        private void btnCustomerNew_Click(object sender, RoutedEventArgs e)
        {
            Page page = new CustomerAddView
            {
                DataContext = this.DataContext
            };
            frmContent.NavigationService.Navigate(page);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            Page page = new CustomerView
            {
                DataContext = this.DataContext
            };
            frmContent.NavigationService.Navigate(page);
        }
    }
}
