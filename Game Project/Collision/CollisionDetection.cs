using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class CollisionDetection : IUpdateable
    {
        private float side_overlap;
        private float updown_overlap;

        public enum CollideDirection { Top, Bottom, Left, Right };
        public CollideDirection direction;

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
