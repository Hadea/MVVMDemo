using System;
using System.Windows.Input;

namespace Data.Commands
{
    public class CustomerDrop : ICommand
    {
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Testet ob genug valide Daten zur Verfügung stehen um einen Customer zu löschen.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true, wenn der Customer gelöscht werden kann, andernfalls false</returns>
        public bool CanExecute(object parameter)
        {
            return true;//TODO durch richtigen Test ersetzen
        }
        /// <summary>
        /// Löscht einen Customer.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
