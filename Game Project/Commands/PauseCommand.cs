using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PauseCommand : ICommand
    {
        public Game1 game;
        public PauseMenu pauseMenu;
        public SpriteBatch spriteBatch;
        public PauseCommand(Game1 game)
        {
            this.game = game;  
        }

        public void Execute()
        {
            game.paused = !game.paused;
        }
    }
}
