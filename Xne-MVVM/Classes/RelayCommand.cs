using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xne_MVVM
{
    public class RelayCommand : ICommand
    {
        internal readonly Action action;
        public RelayCommand(Action action) => this.action = action;
        public virtual bool CanExecute(object parameter) => true;
        public virtual void Execute(object parameter) => action();
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand<T> : RelayCommand
    {
        readonly Predicate<T> predicate;
        readonly Action<T> actionOfT;

        public RelayCommand(Action action, Predicate<T> predicate = null) : base(action)
        {
            this.predicate = predicate;
        }

        public RelayCommand(Action<T> actionOfT, Predicate<T> predicate = null) : base(null)
        {
            this.actionOfT = actionOfT;
        }

        public override bool CanExecute(object parameter) => predicate == null ? true : predicate((T)parameter);
        public override void Execute(object parameter)
        {
            if (action != null)
            {
                action();
            }
            else
            {
                actionOfT((T)parameter);
            }
        }
    }
}