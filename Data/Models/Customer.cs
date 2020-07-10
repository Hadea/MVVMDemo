namespace Data.Models
{
    public class Customer : BaseModel
    {
        // 1:1 repräsentation der Tabellenstruktur der Datenbank
        private string customerID;
        private string companyName;
        private string contactName;
        private string contactTitle;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string phone;
        private string fax;

        public string CustomerID
        {
            get => customerID;
            set
            {
                customerID = value;
                OnPropertyChanged("CustomerID");
            }
        }
        public string CompanyName
        {
            get => companyName;
            set
            {
                companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }
        public string ContactName
        {
            get => contactName;
            set
            {
                contactName = value;
                OnPropertyChanged("ContactName");
            }
        }
        public string ContactTitle
        {
            get => contactTitle;
            set
            {
                contactTitle = value;
                OnPropertyChanged("ContactTitle");
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }
        public string Region
        {
            get => region;
            set
            {
                region = value;
                OnPropertyChanged("Region");
            }
        }
        public string PostalCode
        {
            get => postalCode;
            set
            {
                postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }
        public string Country
        {
            get => country;
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Fax
        {
            get => fax;
            set
            {
                fax = value;
                OnPropertyChanged("Fax");
            }
        }
    }
}
