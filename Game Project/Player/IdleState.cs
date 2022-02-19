using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class IdleState : IPlayerState
    {
        private Player player;
        public bool FaceRight { get; set; }

        public IdleState(Player manager, bool faceright)
        {
            player = manager;
            FaceRight = faceright;
            if (FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleRight");
            } else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("idleLeft");
            }
        }

        public void BackToIdle()
        {
            // Already in the idle state
        }

        public void TakeDamage()
        {
            player.setState(new DamageState(player, FaceRight));
        }

        public void Attack()
        {
            player.setState(new PlayerAttackState(player, FaceRight));
        }

        public void UseItem(IProjectile projectile)
        {
            player.setState(new PlayerItemState(player, FaceRight, projectile));
        }
        
        public void Update(GameTime gameTime)
        {
            //Nothing to see here! Have a good day!
        }
    }
}
