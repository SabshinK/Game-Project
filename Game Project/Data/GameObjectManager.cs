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

        private List<IEnemy> enemyList;
        private List<IProjectile> projectileList;
        private List<IItem> itemList;
        private List<ITile> tileList;
        public IPlayer player;

        private object[] listArray;

        private object[] playerAttributes;
        private Vector2 location;
        private bool direction;
        private String animationName;


        public GameObjectManager()
        {
            listArray = new object[4];
            enemyList = new List<IEnemy>();
            projectileList = new List<IProjectile>();
            itemList = new List<IItem>();
            tileList = new List<ITile>();

            location = new Vector2();
            playerAttributes = new object[3];

            playerAttributes[0] = location;
            playerAttributes[1] = direction;
            playerAttributes[2] = animationName;
            player = new Player(new UniversalParameterObject(playerAttributes));
        }

        // collision detection needs the lists
        public object[] GetObjectLists()
        {
            listArray[0] = enemyList;
            listArray[1] = projectileList;
            listArray[2] = itemList;
            listArray[3] = tileList;

            return listArray;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
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
