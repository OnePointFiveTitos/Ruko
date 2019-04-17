using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_Utilities
{
    public interface IInitializer
    {

        bool IsPreInitialized { get; set; }
        bool IsInitialized { get; set; }
        bool IsPostInitialized { get; set; }

        event EventHandler PreInitialized;
        event EventHandler Initialized;
        event EventHandler PostInitialized;

        void PreInitialize();
        void Initialize();
        void PostInitialize();
    }
}