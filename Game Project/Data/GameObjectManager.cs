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
        public List<IEnemy> enemyList;
        public List<IProjectile> projectileList;
        public List<IItem> itemList;
        public List<ITile> tileList;
        public IPlayer player;

        public GameObjectManager()
        {
            enemyList = new List<IEnemy>();
            projectileList = new List<IProjectile>();
            itemList = new List<IItem>();
            tileList = new List<ITile>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player?.Draw(spriteBatch);
            foreach (ITile tile in tileList)
            {
                tile.Draw(spriteBatch);
            }
            foreach (IItem item in itemList)
            {
                item.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IProjectile projectile in projectileList)
            {
                projectile.Draw(spriteBatch);
            }
           
           
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (IProjectile projectile in projectileList)
            {
                projectile.Update(gameTime);
            }
        }


        //Very rough draft of this methodd
        public void RegisterObject(Object T)
        {
            if (T is IEnemy) enemyList.Add((IEnemy)T);
            else if (T is IProjectile) projectileList.Add((IProjectile)T);
            else if (T is IItem) itemList.Add((IItem)T);
            else if (T is ITile) tileList.Add((ITile)T);
            else if (T is IPlayer) player = T as IPlayer;
        }

        public void RemoveObject(IDrawable dead)
        {
            // added casts to "dead" for each of these remove calls.
            if (dead is IEnemy) enemyList.Remove((IEnemy)dead);
            else if (dead is IProjectile) projectileList.Remove((IProjectile)dead);
            else if (dead is IItem) itemList.Remove((IItem)dead);
            //else if (T is IPlayer) ???????
        }

        public void Reset()
        {
            enemyList = new List<IEnemy>();
            projectileList = new List<IProjectile>();
            itemList = new List<IItem>();
            tileList = new List<ITile>();
        }
    }
}
