using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_Utilities
{
    public static class General
    {
        public static ObservableCollection<T> Conditionialize<T>(this ObservableCollection<T> values, IEnumerable<T> initializerValues) 
            => values = initializerValues == null ? new ObservableCollection<T>() : new ObservableCollection<T>(initializerValues);
    }
}