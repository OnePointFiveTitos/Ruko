using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xne_Utilities;

namespace Ruko
{
    public interface IContactItem : ISectionItem
    {
        Regex ValidationExpression { get; }
        ContactTypes ContactType { get; }
        string Input { get; set; }
        bool IsPrimary { get; set; }
        event EventHandler<Match> Validated;

        void Validate();
        void OnValidated(IEnumerable<string> values);
        void SetAsPrimary();
    }
}