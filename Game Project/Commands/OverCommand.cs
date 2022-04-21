using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class OverCommand
    {
        public GameStateMachine stateMachine;
        public OverCommand()
        {

        }

        public void Execute()
        {
            stateMachine.GameOver();
        }
    }
}
