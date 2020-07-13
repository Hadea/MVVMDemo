using Data.Commands;
using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Data.ViewModels
{
    /// <summary>
    /// Basisklasse für alle ViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged, IDisposable, IAsyncDisposable
    {

        public event PropertyChangedEventHandler PropertyChanged; //Event welches ausgelöst wird wenn sich ein Element ändert und das UI informiert werden soll.

        protected void OnPropertyChanged(string pPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
        }

        #region Bereich zum Verwerfen des Objektes
        private bool disposedValue; // Verhindert mehrfaches verwerfen des Objektes, was andernfalls Fehler erzeugen könnte
        /// <summary>
        /// Verwirft das Objekt und die Ressourcen welche dieses Objekt genutzt hat.
        /// </summary>
        /// <param name="disposing">true verwirft auch verwaltete Objekte</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) // Nur starten wenn das Objekt noch nicht verworfen wurde
            {
                if (disposing) // prüfen ob auch verwaltete Objekte verworfen werden sollen
                {
                    // TODO: verwaltete Objekte verwerfen
                }

                // TODO: nicht verwaltete objekte verwerfen und finalizer überschreiben
                // TODO: grosse Felder auf null setzen
                disposedValue = true; // Speichern das dieses Objekt bereits bereinigt wurde sodann ein erneuter Aufruf nicht zu einem Fehler führt
            }
        }

        // // TODO: wenn nicht verwaltete ressource freigegeben werden diesen finalizercode unverändert nutzen
        // ~BaseViewModel()
        // {
        //     Dispose(disposing: false); //Dispose aufrufen, aber diesmal nur für nicht verwaltete ressourcen
        // }

        /// <summary>
        /// Standardmethode zum verwerfen des Objektes. Ruft intern die Dispose(true) auf um sämtliche Ressourcen freizugeben.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Asyncrone variante des Ressourcenverwerfens. Intern werden verwaltete Ressourcen asyncron verworden und danach alle nicht verwalteten syncron.
        /// </summary>
        /// <returns>Ein ValueTask welcher das verwerfen der Ressourcen übernimmt.</returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore(); // asyncron ressourcen freigeben
            Dispose(false); // verwaltete ressourcen freigeben
            GC.SuppressFinalize(this); // Finalize für diese Klasse unterdrücken
        }

        /// <summary>
        /// Verwirft verwaltete Ressourcen asyncron. Wird durch DisposeAsync() aufgerufen und sollte von ableitenden Klassen überschrieben werden.
        /// </summary>
        /// <returns></returns>
        /// 

#pragma warning disable CS1998  //deaktiviert die await-Warnung
        protected virtual async ValueTask DisposeAsyncCore()
        {
            //TODO: add code for disposing async. Excample:
            //if (ressource != null)
            //{
            //    await ressource.DisposeAsync();
            //    ressource = null;
            //}
        }
#pragma warning restore
        #endregion
    }
}
