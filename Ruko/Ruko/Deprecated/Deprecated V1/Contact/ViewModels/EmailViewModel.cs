using ControlsAndResources;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using static Utilities.Functions;
using static Utilities.Regexes;

namespace Ruko
{
    public class EmailViewModel : AssociationViewModel<ContactViewModel, EmailModel>, IDynamicObject
    {
        #region DynamicObject
        public static Dictionary<string, string> Mapping { get; }
        static EmailViewModel()
        {
            EmailViewModel sample = new EmailViewModel(null, null);
            Mapping = new Dictionary<string, string>()
            {
                [nameof(sample.Handle)] = "Handle: ",
                [nameof(sample.Domain)] = "Domain: ",
                [nameof(sample.Register)] = "Register: ",
            };
        }
        #endregion
        public string Email
        {
            get => Model.email;
            set
            {
                if (Model.email != value)
                {
                    Model.email = value;
                    EvaluateEmail();
                    OnPropertiesChanged(this);
                }
            }
        }

        public string Handle { get; private set; }
        public string Domain { get; private set; }
        public string Register { get; private set; }

        public override string Full => Email;
        public override Dictionary<string, string> PropertiesMapping => Mapping;
        public EmailViewModel(ContactViewModel parent, EmailModel model) 
            : base(parent, model)
        {
        }

        void EvaluateEmail()
        {
            GroupCollection groups = EmailEx.Match(Email).Groups;
            Handle = groups[1].Value;
            Domain = groups[2].Value;
            Register = groups[3].Value;
        }
    }
}