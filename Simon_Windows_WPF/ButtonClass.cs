using System.IO;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Simon_Windows
{
    internal class ButtonClass
    {
        public Button Button { get; set; }
        public Button_ENUM ButtonEnum { get; set; }
        public SolidColorBrush RegularColor { get; set; }
        public SolidColorBrush HighlightColor { get; set; }
        public MemoryStream Buffer { get; set; }
    }
}
