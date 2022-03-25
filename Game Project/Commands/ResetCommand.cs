using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ResetCommand : ICommand
    {
        private Game1 game;

        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }
    }
}
