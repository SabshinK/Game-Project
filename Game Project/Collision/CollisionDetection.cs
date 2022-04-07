using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class CollisionDetection : IUpdateable
    {
        private IPlayer player;

        private float side_overlap;
        private float updown_overlap;
        private ICollideable firstCollideable;
        private ICollideable secondCollideable;
        private Vector2 location1;
        private Vector2 location2;
        private Vector2 size1;
        private Vector2 size2;
        private Rectangle rectangleObject1;
        private Rectangle rectangleObject2;

        public enum CollideDirection { Top, Bottom, Left, Right };
        public CollideDirection direction;

        List<IEnemy> enemies;
        List<IProjectile> projectiles;
        List<IItem> items;
        List<ITile> tiles;

        private List<List<IGameObject>> gameObjects;

        private const int movingObjectSize = 128;
        private const int tileSize = 64;

        public CollisionDetection()
        {
            
        }

        public void GetCollisionLists()
        {
            gameObjects = GameObjectManager.Instance.GameObjects;
        }

        public void CheckCollision(IGameObject firstObject, IGameObject secondObject)
        {
            // Position and size can be obtained from the objects, each object has references to these things and can be gotten 
            // like: object1.Size or object1.Position. These variables are Vector2's. Currently Position is an IGameObject property
            // and Size is an ICollideable property, so there is kind of an issue with what type the object would be declared as,
            // I will have to find a solution to this

            firstCollideable = firstObject as ICollideable;
            secondCollideable = secondObject as ICollideable;
            location1 = firstObject.Position;
            location2 = secondObject.Position;
            size1 = firstCollideable.Size;
            size2 = secondCollideable.Size;

            rectangleObject1 = new Rectangle((int)location1.X, (int)location1.Y, (int)size1.X, (int)size1.Y);
            rectangleObject1 = new Rectangle((int)location2.X, (int)location2.Y, (int)size2.X, (int)size2.Y);

            // objects collide:
            if (rectangleObject1.Intersects(rectangleObject2))
            {
                if (rectangleObject1.Right >= rectangleObject2.Left)
                {
                    // left overlap (right side of player):
                    side_overlap = rectangleObject1.Right - rectangleObject2.Left;
                    direction = CollideDirection.Left;
                }
                else
                {
                    // right overlap (left side of player):
                    side_overlap = rectangleObject2.Right - rectangleObject1.Left;
                    direction = CollideDirection.Right;
                }

                if (rectangleObject1.Top <= rectangleObject2.Bottom)
                {
                    // bottom overlap (top side of player):
                    updown_overlap = rectangleObject2.Bottom - rectangleObject1.Top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollideDirection.Bottom;
                    }
                }
                else
                {
                    // top overlap (bottom side of player):
                    updown_overlap = rectangleObject1.Bottom - rectangleObject2.Top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollideDirection.Bottom;
                    }
                }

                CollisionResolution.Instance.ResolveCollision(firstObject, secondObject, direction, rectangleObject1);
            }
        }

        public void Update(GameTime gameTime)
        {
            // This all becomes checking the object in the first list in the list of lists against every next object and the objects in the
            // second list, all of the things needed for collision calculations like position and size can be taken from the object, the only
            // parameters needed for check collision are the two objects to compare

            foreach (IGameObject firstObject in gameObjects[0])
            {
                foreach (IGameObject moveableObject in gameObjects[0])
                {
                    CheckCollision(firstObject, moveableObject);
                }
                foreach (IGameObject nonMoveableObject in gameObjects[1])
                {
                    CheckCollision(firstObject, nonMoveableObject);
                }
            }
        }
    }
}
