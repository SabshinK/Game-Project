using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameStateMachine : IGameStateMachine
    {
        public enum states { playing, paused, win, over};
        public states currState = states.playing;
        public GameStateMachine()
        {

        }

        public void Pause()
        {
            if(currState == states.paused)
            {
                currState = states.playing;
            }
            else
            {
                currState = states.paused;
            }
        }

        public void GameWin()
        {
            currState = states.win;
        }
        public void GameOver()
        {
            currState = states.over;
        }
    }
}
