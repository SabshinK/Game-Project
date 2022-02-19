﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class DamageState : IPlayerState
    {
        private Player player;
        public bool FaceRight { get; set; }

        public DamageState(Player manager, bool faceRight)
        {
            player = manager;
            FaceRight = faceRight;
        }

        public void TakeDamage()
        {
            // Already in the Damage state
        }

        public void BackToIdle()
        {
            // Can't go to idle in the damaged state until the animation is finished
        }

        public void Attack()
        {
            // Can't attack in the damaged state
        }

        public void UseItem(IProjectile projectile)
        {
            // Can't use item in the damaged state
        }

        public void Update(GameTime gameTime)
        {
            
        }
        
    }
}