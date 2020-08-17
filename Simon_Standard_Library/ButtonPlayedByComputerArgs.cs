using System;
using System.Collections.Generic;
using System.Text;

namespace Simon_Standard_Library
{
    public delegate void ButtonPlayedByComputerHandler(object sender, ButtonPlayedByComputerArgs e);

    public class ButtonPlayedByComputerArgs : System.EventArgs
    {
        public BUTTON_ENUM Button { get; private set; }

        public ButtonPlayedByComputerArgs(BUTTON_ENUM enumButton)
        {
            Button = enumButton;
        }
    }
}
