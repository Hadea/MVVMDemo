using System;
using System.Windows.Input;

namespace Data.Commands
{
    public class CustomerUpdate : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Prüft alle gegebenen Felder ob valide Daten für eine Änderung vorhanden sind. Wird durch das GUI automatisch gestartet.
        /// </summary>
        /// <param name="parameter">Optionale Parameter, hier wahrscheinlich ignoriert</param>
        /// <returns>true, wenn alle Felder korrekte Daten enthalten sodass ein Update durchgeführt werden kann, ansonsten false.</returns>
        public bool CanExecute(object parameter)
        {
            return true; //TODO ersetzen mit echter Prüfung ob ein Customer abgeändert werden darf
        }
        /// <summary>
        /// Startet das aktualisieren der Daten.
        /// </summary>
        /// <param name="parameter">Optionale Parameter</param>
        public void Execute(object parameter)
        {
            throw new NotImplementedException(); //TODO implement
        }
    }
}
