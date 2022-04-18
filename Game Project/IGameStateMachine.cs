using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public interface IGameStateMachine
    {
        public void Pause();
        public void GameWin();
        public void GameOver();

    }
}
