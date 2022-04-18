using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Background : IGameObject 
    {
        private Vector2 position;
        public Vector2 Position => position;
        public Vector2 GridPosition => new Vector2(position.X / 64, position.Y / 64);

        ISprite sprite;

        public Background(UniversalParameterObject parameters)
        {
            position = new Vector2(parameters.Position.X * 64, parameters.Position.Y * 64);
            sprite = SpriteFactory.Instance.CreateSprite(parameters.AnimationName);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}
