using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class NonAnimatedNonMovingCommand : ICommand
    {
        private Game1 myGame;

        public NonAnimatedNonMovingCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            // Three dots is nasty here, this all should be refactored
            myGame.setSprite(new NonAnimatedNonMoving(myGame.PlayerTexture, myGame.Location, myGame.GraphicsDevice.Viewport.Bounds, 
                myGame.rows, myGame.columns));
        }
    }
}
