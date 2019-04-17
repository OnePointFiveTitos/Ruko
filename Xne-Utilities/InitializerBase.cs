using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_Utilities
{
    public abstract class InitializerBase : IInitializer
    {
        public virtual bool IsPreInitialized { get; set; }
        public virtual bool IsInitialized { get; set; }
        public virtual bool IsPostInitialized { get; set; }

        public event EventHandler PreInitialized;
        public event EventHandler Initialized;
        public event EventHandler PostInitialized;

        public InitializerBase()
        {
            PreInitialize();
        }

        public virtual void PreInitialize()
        {
            PreInitialized += (sender, e) => Initialize();
            Initialized += (sender, e) => PostInitialize();

            IsPreInitialized = true;
            PreInitialized?.Invoke(this, null);
        }

        public virtual void Initialize()
        {
            IsInitialized = true;
            Initialized?.Invoke(this, null);
        }

        public virtual void PostInitialize()
        {
            IsPostInitialized = true;
            PostInitialized?.Invoke(this, null);
        }
    }
}