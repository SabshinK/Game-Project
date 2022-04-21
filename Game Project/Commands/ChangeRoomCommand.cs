using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ChangeRoomCommand : ICommand
    {
        public Vector2 Position;
        public Player player;
        public ChangeRoomCommand(Vector2 position, Player player)
        {
           Position = position;
           this.player = player;
        }

        public void Execute()
        {
            player.Position = Position;
        }
    }
}
