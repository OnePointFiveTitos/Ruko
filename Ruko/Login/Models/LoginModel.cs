using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class LoginModel
    {
        internal string windowTitle;
        internal string displayTitle;

        internal bool isLoginValidated = false;

        internal string username;

        internal string error = "Please enter username and password";
    }
}