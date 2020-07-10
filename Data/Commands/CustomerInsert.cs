using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Data.Commands
{
    class CustomerInsert : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Prüft ob genug valide Daten vorliegen um einen neuen Nutzer zu erstellen.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true, wenn die Daten komplett sind, andernfalls false</returns>
        public bool CanExecute(object parameter)
        {
            return true; //TODO: durch echten test ersetzen
        }
        /// <summary>
        /// Fügt einen Customer der Datenbasis hinzu
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            throw new NotImplementedException(); //TODO implement
        }
    }
}
