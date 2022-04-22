using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class OverCommand
    {
        public GameStateMachine stateMachine;
        public OverCommand(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public void Execute()
        {
            stateMachine.GameOver();
        }
    }
}
