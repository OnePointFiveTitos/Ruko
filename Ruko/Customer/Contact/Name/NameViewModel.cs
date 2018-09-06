using System;
using System.Runtime.CompilerServices;

namespace Ruko
{
    public class NameViewModel : ObservableObject
    {
        public bool IsPrimary
        {
            get => model.isPrimary;
            set
            {
                if (model.isPrimary != value)
                {
                    model.isPrimary = value;
                    OnPropertyChanged();
                }
            }
        }
        private Name model;
        public Name Model { get => model; }
        public Array SuffixTypes { get => App.SuffixTypes; }
        public SuffixTypes SuffixType
        {
            get => model.suffixType;
            set
            {
                if (model.suffixType != value)
                {
                    model.suffixType = value;
                    OnPropertyChanged(); //not used in the display string so dont need OnChanged();
                    //OnChanged();
                }
            }
        }
        public string First
        {
            get => model.first;
            set
            {
                if (model.first != value)
                {
                    model.first = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Middle
        {
            get => model.middle;
            set
            {
                if (model.middle != value)
                {
                    model.middle = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Last
        {
            get => model.last;
            set
            {
                if (model.last != value)
                {
                    model.last = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Full
        {
            get => string.Format($"{First} {Last}");
        }
        public NameViewModel(Name model = null)
        {
            this.model = model ?? new Name();
        }
        void OnChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Full");
        }
    }
}