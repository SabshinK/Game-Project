using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerMoveRightCommand : ICommand
    {
        private PlayerManager player;

        public PlayerMoveRightCommand(PlayerManager manager)
        {
            player = manager;
        }

        public void Execute()
        {
            player.setState(new PlayerMoveRight(player.location, player));
            
            player.sprite = SpriteFactory.Instance.CreateSprite("movingRight");
        }
    }
}
