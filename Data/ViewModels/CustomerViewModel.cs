using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows.Input;
using Data.Commands;
using Data.Models;

namespace Data.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> CustomerList { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer == value) return;

                selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        private int selectedCustomerNumber;
        public int SelectedCustomerNumber
        {
            get => selectedCustomerNumber;
            set
            {
                if (selectedCustomerNumber == value) return; // nichts besonderes tun wenn der alte wert dem neuen entspricht.
                selectedCustomerNumber = value;
                if (selectedCustomerNumber == -1) // wenn nichts ausgewählt wurde (durch löschen oder deselectieren)
                {
                    SelectedCustomer = null;
                }
                else
                {
                    SelectedCustomer = CustomerList[value];
                }
                OnPropertyChanged("SelectedCustomerNumber");
                dropCommand.RaiseCanExecuteChanged();
            }
        }

        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>();
            loadData();
        }

        #region Bereich für Kommandos welche vom GUI gestartet werden

        private Relay dropCommand;

        public Relay DropCommand
        {
            get
            {
                if (dropCommand == null) dropCommand = new Relay(CanDeleteCustomer, DeleteCustomer);
                return dropCommand;
            }
            set { dropCommand = value; }
        }

        #endregion

        private void loadData()
        {
#pragma warning disable IDE0063 //deaktiviert die angebotene optimierung des using statements
            using (SQLiteConnection sqlConnection = new SQLiteConnection(@"Data Source=.\Database\northwindEF.db; Version=3;"))
            {
                SQLiteCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "select * from customers;";
                sqlConnection.Open();

                using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                {
                    CustomerList.Clear();
                    while (reader.Read())
                    {
                        Customer newCustomer = new Customer
                        {
                            CustomerID = Helper.GetNullableString(reader, 0),
                            CompanyName = Helper.GetNullableString(reader, 1),
                            ContactName = Helper.GetNullableString(reader, 2),
                            ContactTitle = Helper.GetNullableString(reader, 3),
                            Address = Helper.GetNullableString(reader, 4),
                            City = Helper.GetNullableString(reader, 5),
                            Region = Helper.GetNullableString(reader, 6),
                            PostalCode = Helper.GetNullableString(reader, 7),
                            Country = Helper.GetNullableString(reader, 8),
                            Phone = Helper.GetNullableString(reader, 9),
                            Fax = Helper.GetNullableString(reader, 10)
                        };
                        CustomerList.Add(newCustomer);


                    }
                }
            }
#pragma warning restore IDE0063
        }

        private void InsertCustomer()
        {
            SelectedCustomer = Customer.Empty();
        }

        private void UpdateCustomer()
        {
            //TODO implement update customer
        }

        private void DeleteCustomer()
        {
            CustomerList.Remove(selectedCustomer);
            selectedCustomer = null;
            //TODO notify database
        }

        private bool CanInsertCustomer()
        {
            return true;//TODO implement Test
        }

        private bool CanUpdateCustomer()
        {
            return true;//TODO implement Test
        }

        private bool CanDeleteCustomer()
        {
            return selectedCustomer != null; // testet ob ein Customer ausgewählt wurde. Das ergebnis ist dann auch direkt die Antwort der Methode.
        }
    }
}
