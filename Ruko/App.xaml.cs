using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Ruko
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainView;
        public static Array AddressTypes = Enum.GetValues(typeof(AddressTypes));
        public static Array CustomerStandingTypes = Enum.GetValues(typeof(CustomerStandingTypes));
        public static Array EmailTypes = Enum.GetValues(typeof(EmailTypes));
        public static Array PhoneTypes = Enum.GetValues(typeof(PhoneTypes));
        public static Array StateAbbreviationTypes = Enum.GetValues(typeof(StateAbbreviationTypes));
        public static Array StateTypes = Enum.GetValues(typeof(StateTypes));
        public static Array SuffixTypes = Enum.GetValues(typeof(SuffixTypes));
    }
}