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
        public ItemScroller itemScroller;
        private PauseMenu menu;

        private SpriteFont font;

        private GameStateMachine stateMachine;

        public UIManager(GameStateMachine stateMachine, Camera camera)
        {
            this.stateMachine = stateMachine;
            this.camera = camera;
            itemScroller = new ItemScroller();
            healthBar = new HealthBar(stateMachine);

            UIList = new List<IUI>();
        }

        public void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("Text");

            menu = new PauseMenu(font);
            gameOver = new GameOver(font);
            gameWin = new GameWin(font);

            UIList.Add(gameOver);
            UIList.Add(gameWin);
            UIList.Add(healthBar); 
            UIList.Add(itemScroller);
            UIList.Add(menu);
        }

        public void Update(GameTime gameTime)
        {
            healthBar.Update(gameTime);

            // change this to a list of UI objects, maybe make an interface?
            foreach (IUI uiItem in UIList)
            {
                uiItem.Position = camera.Position;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //subject to change
            if (stateMachine.currState == GameStateMachine.states.paused)
            {
                menu.Draw(spriteBatch);
                itemScroller.Draw(spriteBatch);
            }
            else if (stateMachine.currState == GameStateMachine.states.win)
            {
                gameWin.Draw(spriteBatch);
            }
            else if (stateMachine.currState == GameStateMachine.states.over)
            {
                gameOver.Draw(spriteBatch);
            }
            else
            {
                healthBar.Draw(spriteBatch);
            }
        }
    }
}
