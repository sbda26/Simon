using System;
using System.Collections.Generic;

namespace Simon_Standard_Library
{
    public class Response_Class
    {
        public event ButtonPlayedByComputerHandler Button_Played_By_Computer_Event;
        public event CorrectButtonPressedByUserHandler Correct_Button_Pressed_Event;
        public event UserFinishedSequenceHandler User_Finished_Sequence_Event;
        public event WrongButtonPressedByUserHandler Wrong_Button_Pressed_By_User_Event;

        private List<BUTTON_ENUM> _lstSequence = new List<BUTTON_ENUM>();
        private Random _clsRandom = new Random();
        private int _iCheck_Index = 0;

        public void Clear()
        {
            _lstSequence.Clear();
            _iCheck_Index = 0;
        }

        public void Add_To_Sequence()
        {
            BUTTON_ENUM enumNext = Next_Button();
            _lstSequence.Add(enumNext);
        }

        public void Check(BUTTON_ENUM enumButton)
        {
            BUTTON_ENUM enumCorrect_Button = _lstSequence[_iCheck_Index];

            if (enumButton == enumCorrect_Button)
            {
                if(_iCheck_Index == _lstSequence.Count - 1)
                {
                    _iCheck_Index = 0;
                    User_Finished_Sequence_Sub(new UserFinishedSequenceArgs());
                }
                else
                {
                    _iCheck_Index++;
                    Correct_Button_Pressed_By_User_Sub(new CorrectButtonPressedByUserArgs());
                }
            }
            else
                Wrong_Button_Pressed_By_User_Sub(new WrongButtonPressedByUserArgs());
        }

        public void Play_Sequence()
        {
            foreach (BUTTON_ENUM enumButton in _lstSequence)
                Button_Played_By_Computer_Sub(new ButtonPlayedByComputerArgs(enumButton));

            _iCheck_Index = 0;
        }
        
// ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private BUTTON_ENUM Next_Button()
        {
            int iNext = _clsRandom.Next(1, 4);
            BUTTON_ENUM enumNext = Convert_To_Enum(iNext);

            return enumNext;    
        }

        private BUTTON_ENUM Convert_To_Enum(int iNext)
        {
            switch(iNext)
            {
                case 1: return BUTTON_ENUM.TOP;
                case 2: return BUTTON_ENUM.LEFT;
                case 3: return BUTTON_ENUM.RIGHT;
                case 4: return BUTTON_ENUM.BOTTOM;
                default: throw new InvalidOperationException("Value must be between 1-4");
            }
        }

        private void Button_Played_By_Computer_Sub(ButtonPlayedByComputerArgs e)
        {
            Button_Played_By_Computer_Event(this, e);
        }

        private void Correct_Button_Pressed_By_User_Sub(CorrectButtonPressedByUserArgs e)
        {
            Correct_Button_Pressed_Event(this, e);
        }

        private void User_Finished_Sequence_Sub(UserFinishedSequenceArgs e)
        {
            User_Finished_Sequence_Event(this, e);
        }

        private void Wrong_Button_Pressed_By_User_Sub(WrongButtonPressedByUserArgs e)
        {
            Wrong_Button_Pressed_By_User_Event(this, e);
        }

    }
}
