using System.Collections.Generic;
using System.Windows.Input;

namespace Xne_MVVM
{
    public interface ICommander
    {
        Dictionary<string,ICommand> Commands { get; }
        void InitializeCommands();
    }
}