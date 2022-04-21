using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class HealthBar : IUpdateable, IDrawable, IUI
    {
        public Vector2 Position { get; set; }

        // Not sure if I like the coupling here
        private IPlayer player;
        private int Health => player.Health;
        private bool iterating;

        // Using a list of tuples here because I only want to change the ISprite implementation if it needs to be updated,
        // If the ISprite is already a full heart it doesn't need to be set to a new one, so this has to be checked
        private List<Tuple<string, ISprite>> hearts;

        public HealthBar()
        {
            player = GameObjectManager.Instance.GetPlayer();
            hearts = new List<Tuple<string, ISprite>>();

            iterating = false;

            for (int i = 0; i < Health / 2; i++) // Each heart is two health
            {
                hearts.Add(new Tuple<string, ISprite>("fullHeart", SpriteFactory.Instance.CreateSprite("fullHeart")));
            }
        }

        public void Update(GameTime gameTime)
        {
            int currentHealth = Health;
            iterating = true;

            // check the state of the health bar sprites with the health, if the sprites need to be updated do so
            for (int i = 0; i < hearts.Count; i++)
            {
                if (currentHealth > 1)
                {
                    if (!hearts[i].Item1.Equals("fullHeart"))
                        hearts[i] = new Tuple<string, ISprite>("fullHeart", SpriteFactory.Instance.CreateSprite("fullHeart"));
                    currentHealth -= 2;
                }
                else if (currentHealth == 1)
                {
                    if (!hearts[i].Item1.Equals("halfHeart"))
                        hearts[i] = new Tuple<string, ISprite>("halfHeart", SpriteFactory.Instance.CreateSprite("halfHeart"));
                    currentHealth--;
                }
                else
                {
                    if (!hearts[i].Item1.Equals("emptyHeart"))
                        hearts[i] = new Tuple<string, ISprite>("emptyHeart", SpriteFactory.Instance.CreateSprite("emptyHeart"));
                }
            }

            iterating = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!iterating)
            {
                for (int i = 0; i < hearts.Count; i++)
                {
                    // Draw the hearts at their positions, based on the camera position, determined by which heart they are in the array
                    // times their size
                    hearts[i].Item2.Draw(spriteBatch, new Vector2(hearts[i].Item2.Size.X * i + Position.X, Position.Y));
                }
            }
        }
    }
}
