using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Data
{
    public class Helper
    {
        
        public static string GetNullableString(SQLiteDataReader pReader, int pCellID)
        {
            return (pReader.IsDBNull(pCellID) ? String.Empty : pReader.GetString(pCellID));
        }
        public static int GetNullableInt(SQLiteDataReader pReader, int pCellID)
        {
            return (pReader.IsDBNull(pCellID) ? 0 : pReader.GetInt32(pCellID));
        }
    }
}
