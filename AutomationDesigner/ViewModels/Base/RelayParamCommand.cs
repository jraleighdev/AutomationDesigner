using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomationDesigner.ViewModels.Base
{
    public class RelayParamCommand : ICommand
    {

        #region Private Members
        private readonly Action<object> _action;
        #endregion

        /// <summary>
        /// Events tahts fired when the <see cref="CanExecute(object)"/> value has changed.
        /// </summary>
        #region Public Events
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion


        #region Constructor
        public RelayParamCommand(Action<object> action)
        {
            _action = action;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A Realy command Can Always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }
        #endregion
    }
}
