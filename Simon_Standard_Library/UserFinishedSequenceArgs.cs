using System;
using System.Collections.Generic;
using System.Text;

namespace Simon_Standard_Library
{
    public delegate void UserFinishedSequenceHandler(object sender, EventArgs e);

    public class UserFinishedSequenceArgs : EventArgs
    {
    }
}
