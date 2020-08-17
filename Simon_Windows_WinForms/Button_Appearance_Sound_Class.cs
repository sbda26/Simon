using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simon_Standard_Library;

namespace Simon_Windows_WinForms
{
    internal sealed class Button_Appearance_Sound_Class
    {
        public Button Button { get; set; }
        public BUTTON_ENUM Button_ENUM { get; set; }
        public Color Normal_Color { get; set; }
        public Color Highlighted_Color { get; set; }
        public string WAV_File { get; set; }
    }
}
