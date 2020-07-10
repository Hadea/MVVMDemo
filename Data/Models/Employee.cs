using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Data.Models
{
    public class Employee : BaseModel
    {
        private string firstName;
        private int employeeID;
        private string title;
        private string titleOfCourtesy;
        private DateTime birthDate;
        private DateTime hireDate;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string homePhone;
        private string extension;
        private string notes;
        private string photoPath;

        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                employeeID = value;
                OnPropertyChanged("EmployeeID");
            }

        }


        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }


        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string TitleOfCourtesy
        {
            get { return titleOfCourtesy; }
            set
            {
                titleOfCourtesy = value;
                OnPropertyChanged("TitleOfCourtesy");
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
            set
            {
                hireDate = value;
                OnPropertyChanged("HireDate");
            }
        }


        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }


        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }


        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged("Region");
            }
        }


        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged("PostalCode");
            }
        }


        public string HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                OnPropertyChanged("HomePhone");
            }
        }

        public string Extension
        {
            get { return extension; }
            set
            {
                extension = value;
                OnPropertyChanged("Extension");
            }
        }

        //TODO: Photo. Überhaupt nötig?


        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged("Notes");
            }
        }


        public string PhotoPath
        {
            get { return photoPath; }
            set
            {
                photoPath = value;
                OnPropertyChanged("PhotoPath");
            }
        }
    }
}
