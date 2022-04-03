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
        private List<IEnemy> enemyList;
        private List<IProjectile> projectileList;
        private List<IItem> itemList;
        private List<ITile> tileList;
        public IPlayer player;

        private object[] playerAttributes;
        private Vector2 location;
        private bool direction;
        private String animationName;


        public GameObjectManager()
        {
            enemyList = new List<IEnemy>();
            projectileList = new List<IProjectile>();
            itemList = new List<IItem>();
            tileList = new List<ITile>();

            playerAttributes[0] = location;
            playerAttributes[1] = direction;
            playerAttributes[2] = animationName;
            player = new Player(new UniversalParameterObject(playerAttributes)); // ?????? what should the player be set to
        }

        // right now this is just so collision detection can have access to the lists
        public List<ICollideable> GetObjectList(String listType)
        {
            if (listType.Equals("enemy")) return enemyList;
            else if (listType.Equals("projectile")) return projectileList;
            else if (listType.Equals("item")) return itemList;
            else if (listType.Equals("tile")) return tileList;

            return null; // this shouldn't ever happen but i'm not sure what to do if it does?
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch); // not sure what the "?" was for
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
            //else if (T is IPlayer) ??? how to remove dead player ?? do we not even need to do this, since the game over screen will play ?
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
