﻿using Microsoft.Xna.Framework;

namespace Game_Project
{
    public interface IPlayerState : IUpdateable
    {
        public void BackToIdle();
        
        public void Move();

        public void Jump();

        public void TakeDamage();

        public void Attack();

        public void UseItem(IProjectile projectile);
    }
}
