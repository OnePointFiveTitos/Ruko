using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_Utilities
{
    public class Initializer : InitializerBase
    {
        public Action Pre { get; }
        public Action Pro { get; }
        public Action Post { get; }
        public Initializer(Action pre, Action pro, Action post)
        {
            Pre = pre;
            Pro = pro;
            Post = post;
        }

        public override void PreInitialize()
        {
            Pre?.Invoke();
            base.PreInitialize();
        }

        public override void Initialize()
        {
            Pro?.Invoke();
            base.Initialize();
        }

        public override void PostInitialize()
        {
            Post?.Invoke();
            base.PostInitialize();
        }
    }
}