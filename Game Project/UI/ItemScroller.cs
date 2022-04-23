using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class ItemScroller : IUI
    {
        private ISprite Sprite => SpriteFactory.Instance.CreateSprite(ItemHandler.Instance.equipedItem);
        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite?.Draw(spriteBatch, new Vector2(Position.X + 550, Position.Y + 100));
        }
    }
}
