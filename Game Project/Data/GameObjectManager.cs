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
                    gameObject.Draw(spriteBatch);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (List<IGameObject> objectList in GameObjects)
            {
                foreach (IUpdateable gameObject in objectList)
                {
                    gameObject.Update(gameTime);
                }
            }
        }

        // Player should always be the first object of the second list but I don't want to make this assumption
        public Player GetPlayer()
        {
            for (int i = 0; i < GameObjects[0].Count; i++)
            {
                if (GameObjects[0][i] is IPlayer)
                    return (Player)GameObjects[0][i];
            }
            // Couldn't find it
            return null;
        }

        public void RegisterObject(IGameObject newObject)
        {
            //if (T is IEnemy) enemyList.Add((IEnemy)T);
            //else if (T is IProjectile) projectileList.Add((IProjectile)T);
            //else if (T is IItem) itemList.Add((IItem)T);
            //else if (T is ITile) tileList.Add((ITile)T);
            //else if (T is IPlayer) player = T as IPlayer;

            // instead of this logic above, first check if the passed object is moveable, if so add it to the first list, if not add
            // it to the second. There will always be two lists in the list of lists
        }

        public void RemoveObject(IGameObject deadObject)
        {
            // added casts to "dead" for each of these remove calls.
            //if (dead is IEnemy) enemyList.Remove((IEnemy)dead);
            //else if (dead is IProjectile) projectileList.Remove((IProjectile)dead);
            //else if (dead is IItem) itemList.Remove((IItem)dead);

            // instead of this logic above, first check if the passed object is moveable, if so iterate through the first list, if
            // not iterate through the second. There will always be two lists in the list of lists
        }

        public void Reset()
        {
            GameObjects = new List<List<IGameObject>>();
            GameObjects.Add(new List<IGameObject>()); // Moveable list
            GameObjects.Add(new List<IGameObject>()); // Non-Moveable list
        }
    }
}
