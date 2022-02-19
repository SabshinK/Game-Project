﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class PlayerItemState : IPlayerState
    {
        private Player player;
        private float timeElapsed;
        public bool FaceRight { get; set; }
        private IProjectile projectile;

        public PlayerItemState(Player player, bool faceRight, IProjectile projectile)
        {
            this.player = player;
            FaceRight = faceRight;
            if (FaceRight)
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("useItemRight");
            } else
            {
                player.sprite = SpriteFactory.Instance.CreateSprite("useItemLeft");
            }
            this.projectile = projectile;
        }

        public void BackToIdle()
        {
            player.setState(new IdleState(player, FaceRight));
        }

        public void Attack()
        {
            // Can't attack while using an item
        }

        public void UseItem(IProjectile projectile)
        {
            // Already using an item
        }

        public void TakeDamage()
        {
            player.setState(new DamageState(player, FaceRight));
        }

        public void Update(GameTime gameTime)
        {
            if (timeElapsed < 0.5)
            {
                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                player.setState(new IdleState(player, FaceRight));
            }
        }
    }
}
