using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class InformationViewModel<TParent, TModel> : NodeViewModel<TParent, TModel>, IInformationObject
        where TModel : InformationModel
    {
        public abstract Regex Regex { get; }
        public abstract int[] Indices { get; }
        public abstract List<string> Mapping { get; }
        public string Full
        {
            get => Model.full;
            set
            {
                if (Model.full != value)
                {
                    Model.full = value;
                    Evaluate();
                    OnPropertiesChanged(this);
                }
            }
        }
        public bool IsPrimary
        {
            get => Model.isPrimary;
            set
            {
                if (Model.isPrimary != value)
                {
                    Model.isPrimary = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsValid
        {
            get => Model.isValid;
            set
            {
                if (Model.isValid != value)
                {
                    Model.isValid = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRequired
        {
            get => Model.isRequired;
            set
            {
                if (Model.isRequired != value)
                {
                    Model.isRequired = value;
                    OnPropertyChanged();
                }
            }
        }
        public InformationViewModel(TParent parent, TModel model) 
            : base(parent, model)
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

        public override string ToString() => Full;
    }
}