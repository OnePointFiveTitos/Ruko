using ControlsAndResources;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ruko
{
    public abstract class InformationViewModel<TParentViewModel, TModel> : NodeViewModel<TParentViewModel, TModel>, IInformation, IDynamicObject
        where TModel : InformationModel
    {
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
        public abstract string Full { get; }
        public abstract Dictionary<string,string> PropertiesMapping { get; }
        public InformationViewModel(TParentViewModel parent, TModel model) : base(parent, model)
        {
        }
        public override string ToString() => Full;

        public void PopulateControl(DynamicControl control)
        {
            StackPanel panel = new StackPanel();
            foreach (var item in GetType().GetProperties().Where(property => PropertiesMapping.ContainsKey(property.Name)))
            {
                LabeledTextbox labeledTextbox = new LabeledTextbox() { Label = item.Name, };
                labeledTextbox.SetBinding(LabeledTextbox.InputProperty, new Binding(item.Name) { Source = this });
                panel.Children.Add(labeledTextbox);
            }
            control.Content = panel;
        }
    }
}