using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameStateMachine : IGameStateMachine
    {
        public bool paused = false;
        public bool win = false;
        public bool over = false;
        public GameStateMachine()
        {

        }

        public void Pause()
        {
            paused = !paused;
        }

        public void GameWin()
        {
            win = !win;
        }
        public void GameOver()
        {
            over = !over;
        }
    }
}
