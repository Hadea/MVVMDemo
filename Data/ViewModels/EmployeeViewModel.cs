using Data.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Data.ViewModels
{
    public class EmployeeViewModel
    {
        #region Bereich für Kommandos welche vom GUI gestartet werden
        private ICommand updateCommand;
        private ICommand dropCommand;
        private ICommand insertCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null) updateCommand = new EmployeeUpdate();
                return updateCommand;
            }
            set { updateCommand = value; }
        }
        public ICommand DropCommand
        {
            get
            {
                if (dropCommand == null) dropCommand = new EmployeeDrop();
                return dropCommand;
            }
            set { dropCommand = value; }
        }
        public ICommand InserCommand
        {
            get
            {
                if (insertCommand == null) insertCommand = new EmployeeInsert();
                return insertCommand;
            }
            set { insertCommand = value; }
        }

        #endregion
    }
}
