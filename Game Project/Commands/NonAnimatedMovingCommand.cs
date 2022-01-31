using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NonAnimatedMovingCommand : ICommand
    {
        private Game1 myGame;

        public NonAnimatedMovingCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // Three dots is nasty here, this all should be refactored
            myGame.setSprite(new NonAnimatedMoving(myGame.PlayerTexture, myGame.Location, myGame.GraphicsDevice.Viewport.Bounds, 
                myGame.rows, myGame.columns));
        }
    }
}
