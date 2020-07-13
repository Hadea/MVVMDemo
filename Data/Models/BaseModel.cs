using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Data.Models
{
    /// <summary>
    /// Basisklasse für alle "Model" aus dem MVVM pattern. Sie stellt die Funktionalität bereit das das GUI über Änderungen informiert wird.
    /// </summary>
    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // Event um änderungen an den Daten mitzuteilen

        /// <summary>
        /// Informiert gebundene GUI elemente das sich etwas verändert hat. Diese laden die Daten dann neu.
        /// </summary>
        /// <param name="pPropertyName">Name des Property welches geändert wurde</param>
        protected void OnPropertyChanged(string pPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }
    }
}
