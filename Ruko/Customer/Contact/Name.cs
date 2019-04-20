using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Name : ContactItem<NameModel>, INameItem
    {
        public override Regex ValidationExpression => NameValidationExpression;

        public string First
        {
            get => Model.first;
            set
            {
                if (Model.first != value)
                {
                    Model.first = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Middle
        {
            get => Model.middle;
            set
            {
                if (Model.middle != value)
                {
                    Model.middle = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Last
        {
            get => Model.last;
            set
            {
                if (Model.last != value)
                {
                    Model.last = value;
                    OnPropertyChanged();
                }
            }
        }
        public Name(ContactProfile parent, NameModel model) : base(parent, model)
        {

        }

        public override void OnValidated(IEnumerable<string> values)
        {
            First = values.At(1);
            Middle = values.At(2);
            Last = values.At(3);
        }
    }

    public class NameModel : ContactItemModel
    {
        internal string first;
        internal string middle;
        internal string last;
    }
}