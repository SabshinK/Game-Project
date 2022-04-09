using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class PlayerBumpCommand : ICommand
    {
        private IPlayer player;
        private Rectangle collision;
        private int direction;

        public PlayerBumpCommand(IPlayer player, Rectangle collision, int direction)
        {
            this.player = player;
            this.collision = collision;
            this.direction = direction;
        }

        public void Execute()
        {
            player.Bump(collision, direction);
        }
    }
}
