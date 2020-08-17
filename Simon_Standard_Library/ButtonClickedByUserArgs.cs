using System;
using System.Collections.Generic;
using System.Text;

namespace Simon_Standard_Library
{
    public delegate void ButtonClickedByUserHandler(object sender, ButtonClickedByUserArgs e);

    public class ButtonClickedByUserArgs : System.EventArgs
    {
        public BUTTON_ENUM Button { get; private set; }

        public ButtonClickedByUserArgs(BUTTON_ENUM enumButton)
        {
            Button = enumButton;
        }
    }
}
