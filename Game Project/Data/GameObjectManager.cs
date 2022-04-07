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

        // List of lists containing the game objects, there should be two lists, one for moving objects and one for non moving
        public List<List<IGameObject>> GameObjects { get; private set; }

        public GameObjectManager()
        {
            Reset();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (List<IGameObject> objectList in GameObjects)
            {
                foreach (IDrawable gameObject in objectList)
                {

                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IUpdateable gameObject in GameObjects[0])
            {
                gameObject.Update(gameTime);
            }
        }

        public void RegisterObject(IGameObject newObject)
        {
            //if (T is IEnemy) enemyList.Add((IEnemy)T);
            //else if (T is IProjectile) projectileList.Add((IProjectile)T);
            //else if (T is IItem) itemList.Add((IItem)T);
            //else if (T is ITile) tileList.Add((ITile)T);
            //else if (T is IPlayer) player = T as IPlayer;

            // instead of this logic above, first check if the passed object is updateable, if so add it to the first list, if not add
            // it to the second
        }

        public void RemoveObject(IGameObject deadObject)
        {
            // added casts to "dead" for each of these remove calls.
            //if (dead is IEnemy) enemyList.Remove((IEnemy)dead);
            //else if (dead is IProjectile) projectileList.Remove((IProjectile)dead);
            //else if (dead is IItem) itemList.Remove((IItem)dead);

            // instead of this logic above, first check if the passed object is updateable, if so iterate through the first list, if
            // not iterate through the second
        }

        public void Reset()
        {
            GameObjects = new List<List<IGameObject>>();
            GameObjects.Add(new List<IGameObject>());
            GameObjects.Add(new List<IGameObject>());
        }
    }
}
