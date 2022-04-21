﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PauseCommand : ICommand
    {
        public GameStateMachine stateMachine;
        public PauseCommand()
        {

        }

        public void Execute()
        {
            stateMachine.Pause();
        }
    }
}
