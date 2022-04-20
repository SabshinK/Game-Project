using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class CollisionDetection : IUpdateable
    {
        public enum CollideDirection { Top, Bottom, Left, Right };

        private List<List<IGameObject>> gameObjects;

        public CollisionDetection()
        {
            
        }

        public void CheckCollision(IGameObject firstObject, IGameObject secondObject)
        {
            ICollideable firstCollideable = firstObject as ICollideable;
            ICollideable secondCollideable = secondObject as ICollideable;

            if (firstCollideable.Size != null && secondCollideable.Size != null)
            {
                Rectangle rectangleObject1 = new Rectangle((int)firstObject.Position.X, (int)firstObject.Position.Y, (int)firstCollideable.Size.X, (int)firstCollideable.Size.Y);
                Rectangle rectangleObject2 = new Rectangle((int)secondObject.Position.X, (int)secondObject.Position.Y, (int)secondCollideable.Size.X, (int)secondCollideable.Size.Y);

                // objects collide:
                if (rectangleObject1.Intersects(rectangleObject2))
                {
                    Rectangle collision = Rectangle.Intersect(rectangleObject1, rectangleObject2);
                    CollideDirection direction;

                    // Collisions are with respect to the first object, i.e. a left collision is one where object 2 is to the left of
                    // the first object, etc.
                    if (collision.Width >= collision.Height)    // Vertical collision
                    {
                        if (collision.Y > rectangleObject1.Y)
                            direction = CollideDirection.Bottom;
                        else
                            direction = CollideDirection.Top;
                    }
                    else    // Horizontal collision
                    {
                        if (rectangleObject1.X < collision.X)
                            direction = CollideDirection.Right;
                        else
                            direction = CollideDirection.Left;
                    }

                    CollisionResolution.Instance.ResolveCollision(firstObject, secondObject, direction, collision);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            gameObjects = GameObjectManager.Instance.GameObjects;

            for (int i = 0; i < gameObjects[0].Count; i++)
            {
                for (int j = i + 1; j < gameObjects[0].Count; j++)
                {
                    // Check each moveable object with each next moveable object and onward
                    CheckCollision(gameObjects[0][i], gameObjects[0][j]);
                }
                foreach (IGameObject nonMoveableObject in gameObjects[1])
                {
                    // Check moveable against the non-moveables
                    CheckCollision(gameObjects[0][i], nonMoveableObject);
                }
            }
        }
    }
}
