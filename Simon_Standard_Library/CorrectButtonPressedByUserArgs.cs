using System;
using System.Collections.Generic;
using System.Text;

namespace Simon_Standard_Library
{
    public delegate void CorrectButtonPressedByUserHandler(object sender, EventArgs e);

    public class CorrectButtonPressedByUserArgs : System.EventArgs
    {
    }
}
