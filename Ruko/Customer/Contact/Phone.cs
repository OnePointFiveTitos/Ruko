﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Phone : ContactItem<PhoneModel>, IPhoneItem
    {
        public int Areacode
        {
            get => Model.areacode;
            set
            {
                if (Model.areacode != value)
                {
                    Model.areacode = value;
                    OnPropertyChanged();
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
                }
            }
        }
        public int? CountryCode
        {
            get => Model.countryCode;
            set
            {
                if (Model.countryCode != value)
                {
                    Model.countryCode = value;
                    OnPropertyChanged();
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
                }
            }
        }
        public Phone(Contact parent, PhoneModel model) : base(parent, model)
        {
        }
    }

    public class PhoneModel : ContactItemModel
    {
        internal int areacode;
        internal int prefix;
        internal int line;
        internal int? countryCode;
        internal int? extension;
    }
}