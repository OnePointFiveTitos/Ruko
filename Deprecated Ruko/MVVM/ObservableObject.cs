using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        /// <summary>
        /// Updates all properties on an object
        /// </summary>
        /// <param name="obj">The object to get all the properties from</param>
        //public void OnPropertiesChanged(object obj) => obj.GetType().GetProperties().ToList().ForEach(prop => OnPropertyChanged(prop.Name));
        public void OnPropertiesChanged() => GetType().GetProperties().ToList().ForEach(prop => OnPropertyChanged(prop.Name));
        //public void OnPropertiesChanged([CallerMemberName] string callingProperty = null, params string[] propertyNames)
        //{
        //    OnPropertyChanged(callingProperty);

        //    for (int i = 0; i < propertyNames?.Length; i++)
        //    {
        //        OnPropertyChanged(propertyNames[i]);
        //    }
        //}
    }
}