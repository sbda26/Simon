using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Windows.Threading;
using System.IO;
using System.Threading;

namespace Simon_Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum Mode_ENUM
        {
            GAME_OVER,
            SIMON_PLAYING_ROUND,
            USER_PLAYING_ROUND,
            USER_FINISHED_ROUND,
            SIMON_REPLAYING_LAST_ROUND
        }

        private Mode_ENUM _currentMode = Mode_ENUM.GAME_OVER;

        private int _currentRound = 0;

        private readonly MemoryStream _msBuzzer;
        private SoundPlayer _sp = new SoundPlayer();
        private DispatcherTimer _timer = new DispatcherTimer();
        private Properties.Settings _ps = new Properties.Settings();

        private List<Button_ENUM> _ButtonsToClick = new List<Button_ENUM>();
        private readonly ButtonClass[] _Buttons;
        
        private Button _btnClicked; // = new Button();

        public MainWindow()
        {
            InitializeComponent();
            _msBuzzer = LoadFile("BUZZER.wav");
            _Buttons = InitButtonClassArray();
            InitButtonsPropertiesEvents();
            InitTimer();
        }



        // ========================================================================================================================================================================================================================================================================================

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _currentMode = Mode_ENUM.SIMON_PLAYING_ROUND;
            btnStart.Visibility = Visibility.Hidden;
            SetSimonButtons(true, true);
            DoEvents();
            Thread.Sleep(1000);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            ButtonClass clsButtonToPlay = _Buttons.Where(b => b.Button == btnClicked).First();

            Play(clsButtonToPlay);
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
                                                  new Action(delegate { }));
        }


        private ButtonClass[] InitButtonClassArray()
        {
            return new ButtonClass[]
            {
                new ButtonClass { Button = btnTop, ButtonEnum = Button_ENUM.TOP, RegularColor = Brushes.Yellow, HighlightColor = Brushes.White, Buffer = LoadFile("TOP.WAV")  },
                new ButtonClass { Button = btnLeft, ButtonEnum = Button_ENUM.LEFT, RegularColor = Brushes.Red, HighlightColor = Brushes.LightPink, Buffer = LoadFile("LEFT.WAV") },
                new ButtonClass { Button = btnRight, ButtonEnum = Button_ENUM.RIGHT, RegularColor = Brushes.Green, HighlightColor = Brushes.LightGreen, Buffer = LoadFile("RIGHT.WAV") },
                new ButtonClass { Button = btnBottom, ButtonEnum = Button_ENUM.BOTTOM, RegularColor = Brushes.Blue, HighlightColor = Brushes.LightBlue, Buffer = LoadFile("BOTTOM.WAV") }
            };
        }
        private void InitButtonsPropertiesEvents()
        {
            foreach (ButtonClass simonButton in _Buttons)
            {
                simonButton.Button.IsEnabled = false;
                simonButton.Button.Opacity = _ps.GameOverOpacity;
                simonButton.Button.Background = simonButton.RegularColor;
                simonButton.Button.Click += Button_Click;
            }
        }

        private void InitTimer()
        {
            _timer.Interval = TimeSpan.FromSeconds(_ps.GameOnDuration);
            _timer.Tick += Timer_Tick;
        }

        private MemoryStream LoadFile(string sFile) => new MemoryStream(File.ReadAllBytes(sFile));

        private void Play(ButtonClass clsButtonToPlay)
        {
            clsButtonToPlay.Button.Background = clsButtonToPlay.HighlightColor;
            _btnClicked = clsButtonToPlay.Button;
            _btnClicked.Tag = clsButtonToPlay.RegularColor;
            SetSimonButtons(false, false);
            _sp.Stream = clsButtonToPlay.Buffer;
            _sp.Stream.Position = 0;
            _timer.Start();
            _sp.Play();
        }

        private void SetSimonButtons(bool bOn, bool bSetOpacity)
        {
            foreach (ButtonClass btn in _Buttons)
                btn.Button.IsEnabled = bOn;

            if (bSetOpacity == true)
            {
                double dOpacity = (bOn == true) ? _ps.GameOnOpacity : _ps.GameOverOpacity;
                foreach (ButtonClass btn in _Buttons)
                    btn.Button.Opacity = dOpacity;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _btnClicked.Background = (SolidColorBrush)_btnClicked.Tag;
            SetSimonButtons(true, true);
            _sp.Stream = null;
            DoEvents();
        }

    }
}
