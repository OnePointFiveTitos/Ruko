using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    //public delegate MulticastDelegate SelectionEventHandler<T>(SelectionEventArgs<T> args);
    public class SelectionEventArgs<T> : EventArgs
    {
        public T UnselectedItem { get; }
        public T SelectedItem { get; }
        public SelectionEventArgs(T unselectedItem, T selectedItem)
        {
            UnselectedItem = unselectedItem;
            SelectedItem = selectedItem;
        }
    }
}