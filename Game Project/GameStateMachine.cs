using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameStateMachine : IGameStateMachine
    {
        public bool paused = false;
        public GameStateMachine()
        {

        }

        public void Pause()
        {
            paused = !paused;
        }

        public void GameWin()
        {

        }
        public void GameOver()
        {

        }
    }
}
