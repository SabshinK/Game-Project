using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project.Interfaces
{
    interface IEnemy
    {

        public void Create(SpriteBatch spriteBatch, Vector2 vector);
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

        public void Draw();
    }
}
