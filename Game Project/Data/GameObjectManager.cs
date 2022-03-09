using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class GameObjectManager
    {

        //declared as a singleton
        private static GameObjectManager instance = new GameObjectManager();
        public static GameObjectManager Instance => instance;

        //I don't know if separating these is worth it, we don't quite have enough classes to make it worth it to hold a list of lists
        List<IEnemy> enemyList = new List<IEnemy>();
        List<IProjectile> projectileList = new List<IProjectile>();

        List<IUpdateable> updateableList = new List<IUpdateable>();
        List<IDrawable> drawList = new List<IDrawable>();

        List<IList> masterList = new List<IList>();

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IDrawable drawable in drawList)
            {
                drawable.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(IUpdateable updateable in updateableList)
            {
                updateable.Update(gameTime);
            }
        }


        //Very rough draft of this methodd
        public void RegisterObject(Object T)
        {
            if (T is IEnemy) enemyList.Add((IEnemy)T);
            else if (T is IProjectile) projectileList.Add((IProjectile)T);
        }
    }
}
