using System;
using Xne_MVVM;
using Xne_Utilities;

namespace Ruko
{
    public abstract class SectionItemBase<TParent, TModel> : RukoObject<TParent, TModel> where TModel : SectionItemBaseModel
    {
        public SectionItemBase(TParent parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class SectionItemBaseModel : RukoObjectModel
    {
    }
}