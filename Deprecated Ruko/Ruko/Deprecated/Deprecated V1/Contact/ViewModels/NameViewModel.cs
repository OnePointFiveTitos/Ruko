using ControlsAndResources;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using static Utilities.Functions;

namespace Ruko
{
    public class NameViewModel : InformationViewModel<ContactViewModel, NameModel>, IDynamicObject
    {
        #region DynamicObject
        public static Dictionary<string, string> Mapping { get; }
        static NameViewModel()
        {
            NameViewModel sample = new NameViewModel(null, null);
            Mapping = new Dictionary<string, string>()
            {
                [nameof(sample.First)] = "First: ",
                [nameof(sample.Middle)] = "Middle: ",
                [nameof(sample.Last)] = "Last: ",
            };
        }
        #endregion
        public string Name
        {
            get => Model.name;
            set
            {
                if (Model.name != value)
                {
                    Model.name = value;
                    EvaluateName();
                    OnPropertiesChanged(this);
                }
            }
        }
        public string First { get; private set; }
        public string Middle { get; private set; }
        public string Last { get; private set; }
        public override string Full => Name;
        public override Dictionary<string, string> PropertiesMapping => Mapping;
        public NameViewModel(ContactViewModel parent, NameModel model) 
            : base(parent, model)
        {
        }
        void EvaluateName()
        {
            string[] parts = Name.Split(' ');
            bool hasMiddleName = parts.Length == 3;
            First = parts[0];
            Middle = hasMiddleName ? parts[1] : "n/a";
            Last = hasMiddleName ? parts[2] : parts[1];
        }
    }
}