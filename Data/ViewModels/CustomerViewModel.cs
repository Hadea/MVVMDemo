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

        private Customer selectedCutomer = Customer.Empty();

        public Customer SelectedCustomer
        {
            get { return selectedCutomer; }
            set
            {
                if (selectedCutomer == value) return;

                selectedCutomer = value;
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
                SelectedCustomer = CustomerList[value];
                OnPropertyChanged("SelectedCustomerNumber");
            }
        }

        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>();
            loadData();
        }

        #region Bereich für Kommandos welche vom GUI gestartet werden

        private ICommand updateCommand;
        private ICommand dropCommand;
        private ICommand insertCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null) updateCommand = new Relay(CanUpdateCustomer, UpdateCustomer);
                return updateCommand;
            }
            set { updateCommand = value; }
        }
        public ICommand DropCommand
        {
            get
            {
                if (dropCommand == null) dropCommand = new Relay(CanDeleteCustomer, DeleteCustomer);
                return dropCommand;
            }
            set { dropCommand = value; }
        }
        public ICommand InsertCommand
        {
            get
            {
                if (insertCommand == null) insertCommand = new Relay(CanInsertCustomer, InsertCustomer);
                return insertCommand;
            }
            set { insertCommand = value; }
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
            //TODO implement insert customer
        }

        private void UpdateCustomer()
        {
            //TODO implement update customer
        }

        private void DeleteCustomer()
        {
            //TODO implement Delete customer
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
            return true;//TODO implement Test
        }
    }
}
