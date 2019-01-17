using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Managers
{
    public class Resource : ObservableObject
    {
        public IManager Manager { get; }
        private bool useInternal;
        public bool UseInternal
        {
            get => useInternal;
            set
            {
                if (useInternal != value)
                {
                    useInternal = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}