using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ResetCommand : ICommand
    {
        public ResetCommand()
        {
        }

        public void Execute()
        {
            LevelLoader.Instance.LoadLevel();
        }
    }
}
