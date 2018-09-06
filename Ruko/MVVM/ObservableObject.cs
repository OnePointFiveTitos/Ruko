using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool isEditable;
        public bool IsEditable
        {
            get => isEditable;
            set
            {
                if (isEditable != value)
                {
                    isEditable = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableObject()
        {
            IsEditable = false;
        }
    }//end class
}