using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class HeatingSystem : NodeViewModel<Service, HeatingSystemModel>
    {
        public HeatingSystem(Service parent, HeatingSystemModel model) : base(parent, model)
        {
        }
    }

    public class HeatingSystemModel
    {
        internal string boilerMake;
        internal string primaryType;
        internal string secondaryType;
        internal string burnerMake;
        internal string burnerSize;
        internal string nozzleSize;
        internal string filterSize;
        internal string transformerType;
        internal string circulatorType;
    }
}