namespace Ruko
{
    public class NameViewModel : ContactItemViewModel<NameModel>
    {
        public override string Full => $"{First} {Last}";

        public string First
        {
            get => Model.first;
            set
            {
                if (Model.first != value)
                {
                    Model.first = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Initials));
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Initials));
                    OnPropertyChanged(nameof(Full));
                }
            }
        }

        public string Initials => $"{First?[0] ?? '-'}{Last?[0] ?? '-'}";

        public NameViewModel(ContactViewModel parent, NameModel model = null) : base(parent, model)
        {
            Model = Model ?? new NameModel();
        }
    }

    public class NameModel : ContactItemModel
    {
        internal string first;
        internal string last;
        public NameModel()
        {

        }
        public NameModel(string first, string last)
        {
            this.first = first;
            this.last = last;
        }
    }
}