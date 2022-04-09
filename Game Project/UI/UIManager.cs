using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public class UIManager : IUpdateable, IDrawable
    {
        private Camera camera;

        private GameOver gameOver;
        private GameWin gameWin;
        private HealthBar healthBar;
        private ItemScroller itemScroller;
        private PauseMenu menu;

        public UIManager(Camera camera)
        {
            this.camera = camera;
        }

        public void Update(GameTime gameTime)
        {
            // change this to a list of UI objects, maybe make an interface?
            healthBar.Position = camera.Position;
            healthBar.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Same as update, change this
            healthBar.Draw(spriteBatch);
        }
    }
}
