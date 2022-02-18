using System;
using System.Collections.Generic;
using System.Text;
using Game_Project.Sprites;

namespace Game_Project
{
    class PlayerMoveLeftCommand : ICommand
    {
        private PlayerManager player;

        public PlayerMoveLeftCommand(PlayerManager manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.setState(new PlayerMoveLeft(player.location, player));
            
            player.sprite = SpriteFactory.Instance.CreateSprite("movingLeft");
        }
    }
}
