using System;
using System.Windows.Input;

namespace Data.Commands
{

    /// <summary>
    /// Ein Kommando welches die im Konstruktor übergebenen Methoden aus dem ViewModel aufruft ohne selbst Logik zu enthalten.
    /// </summary>
    public class Relay : ICommand
    {
        readonly Func<bool> canExecuteAction; //Func<bool> bedeutet das hier eine Methode abgelegt werden kann die einen Bool als rückgabewert hat und keine Parameter entgegennimmt.
        readonly Action executeAction; // Eine Action ist eine Methode die weder Parameter noch Rückgabewerte hat.
        /// <summary>
        /// Konstruktor für das Kommando.
        /// </summary>
        /// <param name="pCanExecute">Methode welche prüft ob eine Ausführung möglich ist.</param>
        /// <param name="pExecute">Methode welche die Ausführung macht.</param>
        public Relay(Func<bool> pCanExecute, Action pExecute)
        {
            canExecuteAction = pCanExecute;
            executeAction = pExecute;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return canExecuteAction();
        }

        public void Execute(object parameter)
        {
            executeAction();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            CanExecuteChanged?.Invoke(sender, e);
        }
    }
}
