namespace Ruko
{
    public class PhoneViewModel : ContactItemViewModel<PhoneModel>, IContactMethod, IAssociated
    {
        public NameViewModel AssociatedName
        {
            get => Model.associatedName;
            set
            {
                if (Model.associatedName != value)
                {
                    Model.associatedName = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsPreferred
        {
            get => Model.isPreferred;
            set
            {
                if (Model.isPreferred != value)
                {
                    Model.isPreferred = value;
                    OnPropertyChanged();
                }
            }
        }
        public ContactTypes ContactType
        {
            get => Model.contactType;
            set
            {
                if (Model.contactType != value)
                {
                    Model.contactType = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string Full => $"{Areacode}-{Prefix}-{Line}";

        public int Areacode
        {
            get => Model.areacode;
            set
            {
                if (Model.areacode != value)
                {
                    Model.areacode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public int Prefix
        {
            get => Model.prefix;
            set
            {
                if (Model.prefix != value)
                {
                    Model.prefix = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public int Line
        {
            get => Model.line;
            set
            {
                if (Model.line != value)
                {
                    Model.line = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public int? Country
        {
            get => Model.country;
            set
            {
                if (Model.country != value)
                {
                    Model.country = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public int? Extension
        {
            get => Model.extension;
            set
            {
                if (Model.extension != value)
                {
                    Model.extension = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }

        public PhoneViewModel(ContactViewModel parent, PhoneModel model = null, NameViewModel associatedName = null, bool isPreferred = true, ContactTypes contactType = ContactTypes.Personal) : base(parent, model)
        {
            Model = Model ?? new PhoneModel();
            AssociatedName = associatedName;
            IsPreferred = IsPreferred;
            ContactType = contactType;
        }
    }
    public class PhoneModel : ContactItemModel
    {
        internal NameViewModel associatedName;
        internal bool isPreferred;
        internal ContactTypes contactType;

        internal int areacode = 631;
        internal int prefix;
        internal int line;
        internal int? country;
        internal int? extension;
        public PhoneModel()
        {

        }
        public PhoneModel(int areacode, int prefix, int line, int? country, int? extension)
        {
            this.areacode = areacode;
            this.prefix = prefix;
            this.line = line;
            this.country = country;
            this.extension = extension;
        }
    }
}