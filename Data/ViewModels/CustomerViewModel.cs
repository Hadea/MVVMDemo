using Data.Commands;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> CustomerList { get; set; }

        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>();
            LoadData();
        }

        #region Bereich für Kommandos welche vom GUI gestartet werden
        private ICommand updateCommand;
        private ICommand dropCommand;
        private ICommand insertCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null) updateCommand = new EmployeeUpdate();
                return updateCommand;
            }
            set { updateCommand = value; }
        }
        public ICommand DropCommand
        {
            get
            {
                if (dropCommand == null) dropCommand = new EmployeeDrop();
                return dropCommand;
            }
            set { dropCommand = value; }
        }
        public ICommand InserCommand
        {
            get
            {
                if (insertCommand == null) insertCommand = new EmployeeInsert();
                return insertCommand;
            }
            set { insertCommand = value; }
        }

        #endregion

        private void LoadData()
        {
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
                        Customer newCustomer = new Customer();

                        newCustomer.CustomerID = Helper.GetNullableString(reader, 0);
                        newCustomer.CompanyName = Helper.GetNullableString(reader, 1);
                        newCustomer.ContactName = Helper.GetNullableString(reader, 2);
                        newCustomer.ContactTitle = Helper.GetNullableString(reader, 3);
                        newCustomer.Address = Helper.GetNullableString(reader, 4);
                        newCustomer.City = Helper.GetNullableString(reader, 5);
                        newCustomer.Region = Helper.GetNullableString(reader, 6);
                        newCustomer.PostalCode = Helper.GetNullableString(reader, 7);
                        newCustomer.Country = Helper.GetNullableString(reader, 8);
                        newCustomer.Phone = Helper.GetNullableString(reader, 9);
                        newCustomer.Fax = Helper.GetNullableString(reader, 10);
                        CustomerList.Add(newCustomer);


                    }
                }
            }
        }
    }
}
