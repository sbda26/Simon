using System;
using System.Collections.Generic;
using System.Text;

namespace Simon_Standard_Library
{
    public delegate void WrongButtonPressedByUserHandler(object sender, EventArgs e);

    public class WrongButtonPressedByUserArgs : System.EventArgs
    {
    }
}
