using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class WinCommand : ICommand
    {
        public GameStateMachine stateMachine;
        public WinCommand()
        {

        }

        public void Execute()
        {
            stateMachine.GameWin();
        }
    }
}
