using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Project
{
    public class UIManager : IUpdateable, IDrawable
    {
        private Camera camera;

        private List<IUI> UIList;

        private GameOver gameOver;
        private GameWin gameWin;
        private HealthBar healthBar;
        private ItemScroller itemScroller;
        private PauseMenu menu;
        private SpriteFont font;

        public UIManager(Camera camera)
        {
            this.camera = camera;
        }

        public void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("Text");
            menu = new PauseMenu(font);
            gameOver = new GameOver(font);
            gameWin = new GameWin(font);

        }

        public void Update(GameTime gameTime)
        {
            healthBar.Update(gameTime);
            // change this to a list of UI objects, maybe make an interface?
            healthBar.Position = camera.Position;
            menu.Position = camera.Position;
            gameWin.Position = camera.Position;
            gameOver.Position = camera.Position;
            itemScroller.Position = camera.Position;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Same as update, change this
            healthBar.Draw(spriteBatch);
        }
    }
}
