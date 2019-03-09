using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class PrimaryAssociatedPair<T> : ObservableObject
        where T : class, IInformationObject
    {
        private T primary;
        public T Primary
        {
            get => primary ?? Associated.FirstOrDefault(value => value.IsPrimary);
            set
            {
                primary = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<T> Associated { get; } = new ObservableCollection<T>();
        public PrimaryAssociatedPair(T initial)
        {
            Add(initial);
        }

        public void Add(T value)
        {
            if (Primary == null)
            {
                OnPropertyChanged(nameof(Primary));
                value.IsPrimary = true;
            }
            Associated.Add(value);
        }

        public void Remove(T value)
        {
            if (value.IsPrimary)
            {
                OnPropertyChanged(nameof(Primary));
            }
            Associated.Remove(value);
        }
    }
}