using System.Windows.Controls;

namespace Xne_MVVM
{
    public interface IControl<out TControl>
    {
        TControl Control { get; }
    }
}