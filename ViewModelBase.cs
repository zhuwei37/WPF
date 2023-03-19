using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public abstract  class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Command : ICommand
    {
        //private readonly Action exrcute;

        private readonly Action<object> exrcuteParame;

        private  readonly Func< object,bool> is_can_execute;

        public Command(Action Exrcute):this(Exrcute,null)
        {
        }
        public Command(Action<object> Exrcute):this(Exrcute,null)
        {
        }
        public Command(Action Exrcute, Func<object, bool> IsCanExecute)
        {
           
        }
        public Command(Action<object> ExrcuteParame, Func<object,bool> IsCanExecute)
        {
            exrcuteParame = ExrcuteParame;
            is_can_execute = IsCanExecute;
        }
        


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (is_can_execute!=null)
            {
                return is_can_execute(parameter);
            }
            return true;
        }

      
        public void Execute(object parameter)
        {
            if (exrcuteParame == null)
            {
                throw new ArgumentOutOfRangeException("command");
            }
            exrcuteParame(parameter);
        }
    }

}
