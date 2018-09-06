using System;
using System.Runtime.CompilerServices;

namespace Ruko
{
    public class EmailViewModel : InformationViewModel
    {
        private Email model;
        public Email Model { get => model; }
        public Array EmailTypes { get => App.EmailTypes; }
        public EmailTypes EmailType
        {
            get => model.emailType;
            set
            {
                if (model.emailType!=value)
                {
                    model.emailType = value;
                    OnPropertyChanged();
                    //OnChanged();
                }
            }
        }
        public string Handle
        {
            get => model.handle;
            set
            {
                if (model.handle != value)
                {
                    model.handle = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Domain
        {
            get => model.domain;
            set
            {
                if (model.domain != value)
                {
                    model.domain = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Register
        {
            get => model.register;
            set
            {
                if (model.register != value)
                {
                    model.register = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Email
        {
            get => string.Format($"{Handle}@{Domain}.{Register}");
        }
        public EmailViewModel(Email model = null)
        {
            this.model = model ?? new Email();
        }
        void OnChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Email");
        }
    }
}