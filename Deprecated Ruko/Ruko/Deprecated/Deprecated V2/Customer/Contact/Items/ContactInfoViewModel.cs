using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Utilities.Functions;

namespace Ruko
{
    public abstract class ContactInfoViewModel<TModel> : SubInfoViewModel<ContactViewModel, TModel>
        where TModel : ContactInfoModel
    {
        public abstract Regex Regex { get; }
        public abstract int[] Indices { get; }
        public abstract List<string> Mapping { get; }

        public string Full
        {
            get => Model.full;
            set
            {
                if (IsNotNEW(value) & Model.full != value)
                {
                    Model.full = value;
                    Evaluate();
                    OnPropertiesChanged();
                }
            }
        }
        public abstract string ConcatFull { get; }
        public bool UseConcatFull
        {
            get => Model.useConcatFull;
            set
            {
                if (Model.useConcatFull != value)
                {
                    Model.useConcatFull = value;
                    OnPropertyChanged();
                }
            }
        }

        public ContactInfoViewModel(ContactViewModel parent, TModel model) : base(parent, model)
        {
        }

        /// <summary>
        /// Evaluates an object with a regex and breaks out the data into smaller more refined bits. IE: and Address => Street, City, State, Zipcode, Extension etc
        /// </summary>
        public virtual void Evaluate()
        {
            IEnumerable<PropertyInfo> properties = GetType().GetProperties().Where(property => Mapping.Contains(property.Name));
            GroupCollection groups = Regex.Match(Full).Groups;

            int i = 0;
            foreach (PropertyInfo property in properties)
            {
                property.SetValue(this, groups[Indices[i]].Value);
                i++;
            }
        }

        public override string ToString() => UseConcatFull ? ConcatFull : Full;
    }
}