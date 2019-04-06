using System.Windows.Controls;

namespace MVVM
{
    public interface IControl<TControl> : IControl
        where TControl : Control
    {
        new TControl Control { get; }
    }

    public interface IControl : IController
    {
        object Control { get; }
    }

    public interface IController
    {
        void InitializeControls();
    }
}