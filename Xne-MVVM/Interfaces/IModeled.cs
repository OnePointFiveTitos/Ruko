using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_MVVM
{
    public interface IModeled<out TModel>
    {
        TModel Model { get; }
    }
}