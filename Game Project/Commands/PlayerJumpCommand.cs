﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerJumpCommand : ICommand
    {
        private Player player;
        private bool falling;

        public PlayerJumpCommand(Player manager, bool Falling)
        {
            player = manager;
            falling = Falling;
        }

        public void Execute()
        {
            player.Jump(falling);
        }
    }
}
