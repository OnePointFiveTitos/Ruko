using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class MainInfoModel
    {
        internal string infoName;
        internal bool isEditing = false;
        internal bool isSelected = false;
        internal bool isOpened = false;
        internal bool isEdited = false;
    }
}