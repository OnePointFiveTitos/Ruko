using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class PrimaryAssociationPair<TViewModel, TModel> : ObservableObject
        where TViewModel : ViewModel<TModel>
        where TModel : InformationModel
    {
        //private TViewModel primary;
        //public TViewModel Primary
        //{
        //    get => primary;
        //    set
        //    {
        //        if (primary != value)
        //        {
        //            primary = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //public T Primary => Associated.FirstOrDefault(value => value.IsPrimary);
        private TModel primary;
        public TModel Primary
        {
            get => primary ?? Associated.FirstOrDefault(value => value.isPrimary);
            set
            {
                primary = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TModel> Associated { get; } = new ObservableCollection<TModel>();
        public PrimaryAssociationPair(TModel model)
        {
            Add(model);
        }
        /// <summary>
        /// Adds a value to the associated list and checks for whether its Primary
        /// </summary>
        public void Add(TModel value)
        {
            Associated.Add(value);
            if (Primary == null)
            {
                value.isPrimary = true;
            }
        }
        /// <summary>
        /// Removes a value from the associated list and checks for whether its primary, and redefines the primary value if it is
        /// </summary>
        public void Remove(TModel value)
        {
            Associated.Remove(value);
            if (value.isPrimary)
            {
                Primary = Associated.First();
            }
        }
    }
}