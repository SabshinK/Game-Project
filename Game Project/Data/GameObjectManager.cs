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

        // To prevent errors with updating the game object lists while iterating, we will keep track of when we are iterating and have queues
        // for the items that need to be added or removed
        public bool iterating = false;
        private Queue<IGameObject> toAdd = new Queue<IGameObject>();
        private Queue<IGameObject> toRemove = new Queue<IGameObject>();

        // List of lists containing the game objects, there should be two lists, one for moving objects and one for non moving
        public List<List<IGameObject>> GameObjects { get; private set; }

        public GameObjectManager()
        {
            Reset();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            iterating = true;

            foreach (List<IGameObject> objectList in GameObjects)
            {
                foreach (IDrawable gameObject in objectList)
                {
                    gameObject.Draw(spriteBatch);
                }
            }

            iterating = false;
        }

        public void Update(GameTime gameTime)
        {
            iterating = true;

            foreach (List<IGameObject> objectList in GameObjects)
            {
                foreach (IUpdateable gameObject in objectList)
                {
                    gameObject.Update(gameTime);
                }
            }

            iterating = false;

            while (toAdd.Count > 0)
            {
                RegisterObject(toAdd.Dequeue());
            }

            while (toRemove.Count > 0)
            {
                RemoveObject(toRemove.Dequeue());
            }
        }

        // Player should always be the first object of the second list but we don't want to make this assumption
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

        public Sidekick GetSidekick()
        {
            for (int i = 0; i < GameObjects[0].Count; i++)
            {
                if (GameObjects[0][i] is ISidekick)
                    return (Sidekick)GameObjects[0][i];
            }
            // Couldn't find it
            return null;
        }

        public void RegisterObject(IGameObject newObject)
        {
            if (!iterating)
            {
                if (newObject is IMoveable)
                {
                    GameObjects[0].Add(newObject); //This will add to the first list which has the moveable items. 
                }
                else
                {
                    GameObjects[1].Add(newObject); //This will add the non-moveable items such as tile and item to the second list.
                }
            }
            else
            {
                toAdd.Enqueue(newObject);
            }
        }

        public void RemoveObject(IGameObject deadObject)
        {
            if (!iterating)
            {
                if (deadObject is IMoveable)
                {
                    GameObjects[0].Remove(deadObject); //This will remove from the first list which has the moveable items.                         
                }
                else
                {
                    GameObjects[1].Remove(deadObject); //This will remove the non-moveable item such as tile and item to the second list.
                }
            }
            else
            {
                toRemove.Enqueue(deadObject);
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
