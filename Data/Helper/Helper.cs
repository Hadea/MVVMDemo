using System;
using System.Data.SQLite;

namespace Data
{
    /// <summary>
    /// Klasse für kleine Hilfsprogramme
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Liesst aus einem SQLiteDataReader einen String aus einer Zelle. Sollte diese NULL sein String.Empty zurückgegeben.
        /// </summary>
        /// <param name="pReader">Der DataReader welcher die Zellen enthält</param>
        /// <param name="pCellID">Die Nummer der Zelle</param>
        /// <returns>Gibt den String zurück oder falls dieser NULL ist einen String.Empty</returns>
        public static string GetNullableString(SQLiteDataReader pReader, int pCellID)
        {
            return (pReader.IsDBNull(pCellID) ? String.Empty : pReader.GetString(pCellID));
        }

        /// <summary>
        /// Liesst aus einem SQLiteDataReader einen 32 Bit Integer. Sollte die Zelle NULL sein wird 0 zurückgegeben.
        /// </summary>
        /// <param name="pReader">Der DataReader welcher die Zellen enthält</param>
        /// <param name="pCellID">Die Nummer der Zelle</param>
        /// <returns>Gibt die Zahl zurück oder fall siese NULL ist eine 0</returns>
        public static int GetNullableInt(SQLiteDataReader pReader, int pCellID)
        {
            return (pReader.IsDBNull(pCellID) ? 0 : pReader.GetInt32(pCellID));
        }
    }
}
