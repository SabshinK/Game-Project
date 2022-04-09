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
            // instead of this logic above, first check if the passed object is moveable, if so add it to the first list, if not add
            // it to the second. There will always be two lists in the list of lists
            
            if (newObject is IPlayer || newObject is IEnemy || newObject is IProjectile) 
            {
                GameObjects[0].Add(newObject); //This will add to the first list which has the moveable items. 
            } 
            else 
            {
                GameObjects[1].Add(newObject); //This will add the non-moveable items such as tile and item to the second list.
            }
        }

        public void RemoveObject(IGameObject deadObject)
        {
            // instead of this logic above, first check if the passed object is moveable, if so iterate through the first list, if
            // not iterate through the second. There will always be two lists in the list of lists
            if (deadObject is IPlayer || deadObject is IEnemy || deadObject is IProjectile) 
            {
                GameObjects[0].Remove(deadObject); //This will remove from the first list which has the moveable items. 
            } 
            else 
            {
                GameObjects[1].Remove(deadObject); //This will remove the non-moveable item such as tile and item to the second list.
            }  
        }

        public void Reset()
        {
            GameObjects = new List<List<IGameObject>>();
            GameObjects.Add(new List<IGameObject>()); // Moveable list
            GameObjects.Add(new List<IGameObject>()); // Non-Moveable list
        }
    }
}
