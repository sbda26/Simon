using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using Simon_Standard_Library;

namespace Simon_Windows_WinForms
{
    public partial class frmMain : Form
    {
        private Response_Class _clsResponse = new Response_Class();
        private SoundPlayer _sp = new SoundPlayer();
        private Button_Appearance_Sound_Class[] _arr_clsButtons = null;
        
        private void Set_Window_Dimensions()
        {
            this.Width = 600;
            this.Height = 600;
        }

        private void Init_Appearance_Sound_Array()
        {
            _arr_clsButtons = new Button_Appearance_Sound_Class[]
            {
                new Button_Appearance_Sound_Class { Button = btnTop, Button_ENUM = BUTTON_ENUM.TOP, Normal_Color = Color.Yellow, Highlighted_Color = Color.LightYellow, WAV_File = "TOP.WAV"},
                new Button_Appearance_Sound_Class { Button = btnLeft, Button_ENUM = BUTTON_ENUM.LEFT, Normal_Color = Color.DarkRed, Highlighted_Color = Color.Red, WAV_File = "LEFT.WAV"},
                new Button_Appearance_Sound_Class { Button = btnRight, Button_ENUM = BUTTON_ENUM.RIGHT, Normal_Color = Color.Green, Highlighted_Color = Color.LightGreen, WAV_File = "RIGHT.WAV"},
                new Button_Appearance_Sound_Class { Button = btnBottom, Button_ENUM = BUTTON_ENUM.BOTTOM, Normal_Color = Color.Blue, Highlighted_Color = Color.LightBlue, WAV_File = "BOTTOM.WAV"}
            };
        }

        private void Set_Controls_Locations_Sizes_Master()
        {
            Set_Simon_Button_Sizes();
            Set_Simon_Button_Locations();
            Application.DoEvents();
            Set_Program_Label_Locations();
            Set_Start_Button_Properties();
            Set_Exit_Button_Properties();
        }

        private void Set_Simon_Button_Colors()
        {
            foreach(Button_Appearance_Sound_Class cls in _arr_clsButtons)
                cls.Button.BackColor = cls.Normal_Color;
        }

        private void Set_Simon_Button_Sizes()
        {
            foreach(Control ctl in this.Controls)
            {
                if (ctl is Button)
                {
                    Button btn = (Button)ctl;
                    if (btn.Tag != null && btn.Tag.ToString() == "X")
                    {
                        btn.Width = this.Width / 3;
                        btn.Height = this.Height / 3;
                    }
                }
            }
        }

        private void Set_Simon_Button_Locations()
        {
            btnTop.Top = 0;
            btnTop.Left = (this.Width / 2) - (btnTop.Width / 2);

            btnLeft.Top = (this.Height / 2) - (btnLeft.Height / 2);
            btnLeft.Left = 0;

            btnRight.Top = btnLeft.Top;
            btnRight.Left = this.Width - btnRight.Width;

            btnBottom.Top = (this.Height) - btnBottom.Height;
            btnBottom.Left = btnTop.Left;
        }

        private void Set_Program_Label_Locations()
        {
            int iLeft = btnLeft.Left + btnLeft.Width + 3;
            int iRight = btnRight.Left - 3;
            int iTop = btnTop.Top + btnTop.Height + 3;
            int iBottom = btnBottom.Top - 3;

            lblProgram.AutoSize = false;
            lblProgram.Width = iRight - iLeft;
            lblProgram.Left = iLeft;
            lblProgram.Top = iBottom - iTop;
            lblProgram.Height = iTop;
        }

        private void Set_Start_Button_Properties()
        {
            btnStart.BackColor = this.BackColor;
            btnStart.Left = 3;
            btnStart.Top = 3;
        }

        private void Set_Exit_Button_Properties()
        {
            btnExit.BackColor = this.BackColor;
            btnExit.Left = this.Width - btnExit.Width - 15;
            btnExit.Top = 3;
        }

        private void Play_Sound(string sWAV_File)
        {
            _sp.SoundLocation = sWAV_File;
            _sp.PlaySync();
        }

        private void Set_Event_Handlers()
        {
            _clsResponse.Button_Played_By_Computer_Event += _clsResponse_Button_Played_By_Computer_Event;
            _clsResponse.Correct_Button_Pressed_Event += _clsResponse_Correct_Button_Pressed_Event;
            _clsResponse.User_Finished_Sequence_Event += _clsResponse_User_Finished_Sequence_Event;
            _clsResponse.Wrong_Button_Pressed_By_User_Event += _clsResponse_Wrong_Button_Pressed_By_User_Event;
        }

        private void _clsResponse_Wrong_Button_Pressed_By_User_Event(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _clsResponse_User_Finished_Sequence_Event(object sender, EventArgs e)
        {
            _clsResponse.Add_To_Sequence();
            _clsResponse.Play_Sequence();
        }

        private void _clsResponse_Correct_Button_Pressed_Event(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _clsResponse_Button_Played_By_Computer_Event(object sender, ButtonPlayedByComputerArgs e)
        {
            string sWAV_File = _arr_clsButtons.Where(q => q.Button_ENUM == e.Button).Select(s => s.WAV_File).First();
            Play_Sound(sWAV_File);
        }



        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public frmMain()
        {
            InitializeComponent();
            Set_Window_Dimensions();
            Init_Appearance_Sound_Array();
            Set_Simon_Button_Colors();
            Application.DoEvents();
            Set_Controls_Locations_Sizes_Master();
            Set_Event_Handlers();
        }


        private void ButtonClickedByUser(object sender, EventArgs e) // executed when user clicks button
        {
            Button btn = (Button)sender;
            Button_Appearance_Sound_Class cls = _arr_clsButtons.Where(b => b.Button == btn).First();

            cls.Button.BackColor = cls.Highlighted_Color;
            Application.DoEvents();
            Play_Sound(cls.WAV_File);
            cls.Button.BackColor = cls.Normal_Color;
            Application.DoEvents();
            _clsResponse.Check(cls.Button_ENUM);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            Set_Controls_Locations_Sizes_Master();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
//          btnStart.Enabled = false;
            _clsResponse.Clear();
            _clsResponse.Add_To_Sequence();
            _clsResponse.Play_Sequence();
        }
    }
}
