using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
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

    //public class RelayCommand<T> : ICommand
    //{
    //    readonly Action<T> action;
    //    readonly Action voidAction;
    //    readonly Predicate<T> predicate;



    //    public RelayCommand(Action voidAction) : this(voidAction, null) { }

    //    public RelayCommand(Action voidAction, Predicate<T> predicate)
    //    {
    //        this.voidAction = voidAction;
    //        this.predicate = predicate;
    //    }

    //    public RelayCommand(Action<T> action) : this(action, null) { }

    //    public RelayCommand(Action<T> action, Predicate<T> predicate)
    //    {
    //        this.action = action;
    //        this.predicate = predicate;
    //    }

    //    public bool CanExecute(object parameter) => predicate == null ? true : predicate((T)parameter);
    //    public void Execute(object parameter)
    //    {
    //        if (action != null)
    //        {
    //            action((T)parameter);
    //        }
    //        else
    //        {
    //            voidAction();
    //        }
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add => CommandManager.RequerySuggested += value;
    //        remove => CommandManager.RequerySuggested -= value;
    //    }
    //}
}