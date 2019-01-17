using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVVM;

namespace Ruko
{
    public abstract class MainInfoViewModel<TModel> : NodeViewModel<CustomerViewModel, TModel>, IMainInfo
        where TModel : MainInfoModel
    {
        public ICommand ApplyCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public string InfoName
        {
            get => Model.infoName;
            set
            {
                if (Model.infoName != value)
                {
                    Model.infoName = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsEditing
        {
            get => Model.isEditing; //im not sure why the model is null here, i think it has to do with the interface
            set
            {
                if (Model.isEditing != value)
                {
                    Model.isEditing = value;
                    Parent.EvaluateEditingState();
                    OnPropertyChanged();
                }
            }
        }
        public bool IsSelected
        {
            get => Model.isSelected;
            set
            {
                if (Model.isSelected != value)
                {
                    Model.isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsOpened
        {
            get => Model.isOpened;
            set
            {
                if (Model.isOpened != value)
                {
                    Model.isOpened = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsEdited
        {
            get => Model.isEdited;
            set
            {
                if (Model.isEdited != value)
                {
                    Model.isEdited = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainInfoViewModel(CustomerViewModel parent, TModel model) : base(parent, model)
        {
            InfoName = GetType().Name.Replace("ViewModel", string.Empty);
        }

        public override void InitializeCommands()
        {
            ApplyCommand = new RelayCommand<int>(index => Edit(index));
            CancelCommand = new RelayCommand<int>(index => Edit(index, false));
            EditCommand = new RelayCommand<int>(index => Edit(index));
        }

        public virtual void Save()
        {

        }

        public virtual void Edit(int index, bool saveChanges = true)
        {
            if (!IsEditing)
            {
                Parent.SelectedInfoTabIndex = index;
                IsEditing = true;
                Parent.Open();
                Parent.SelectOpened();
            }
            else
            {
                if (saveChanges)
                {
                    Save();
                    Parent.Save(); // might change to give each info tab it's own save functionality? not sure haventy gotten there yet
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Discard any changes?", "Confirm Discard", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        //revert changes here
                    }
                }
                IsEditing = false;
            }
        }
    }
}