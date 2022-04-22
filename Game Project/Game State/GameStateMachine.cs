using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class GameStateMachine : IGameStateMachine
    {
        public enum states { playing, paused, win, over};
        public states currState = states.playing;
        public UIManager uIManager;
        
        public GameStateMachine(Camera camera)
        {
            uIManager = new UIManager(this, camera);
        }

        public void LoadContent(ContentManager content)
        {
            uIManager.LoadContent(content);
        }

        public void Pause()
        {
            if(currState == states.paused)
            {
                currState = states.playing;
            }
            else
            {
                currState = states.paused;
            }
        }

        public void GameWin()
        {
            currState = states.win;
        }
        public void GameOver()
        {
            currState = states.over;
        }

        public void Update(GameTime gameTime)
        {
            uIManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            uIManager.Draw(spriteBatch);
        }
    }
}
