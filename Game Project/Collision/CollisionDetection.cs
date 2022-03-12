using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionDetection : ICollideable, IUpdateable
    {
        private ICollideable firstObject;
        private ICollideable secondObject;

        private float firstObject_top;
        private float firstObject_bottom;
        private float firstObject_left;
        private float firstObject_right;
        private float secondObject_top;
        private float secondObject_bottom;
        private float secondObject_left;
        private float secondObject_right;
        private float side_overlap;
        private float updown_overlap;
        private Vector2 firstObjectLocation;
        private Vector2 secondObjectLocation;
        private CollisionResolution collisionResolution;

        private CollisionResolution.collideDirection direction;

        Tuple<ICollideable, ICollideable> twoObjects;

        GameTime gameTime;

        public CollisionDetection()
        {
            //Ask Object Manager for the lists


        }

        public void Collide()
        {

            collisionResolution = new CollisionResolution(firstObject, secondObject, direction);

        }

        public Tuple<ICollideable, ICollideable> GetTwoObjects()
        {
            Tuple<ICollideable, ICollideable> twoObjectsToCollide;

            return twoObjectsToCollide;
        }

        public void Update(GameTime gameTime)
        {
            twoObjects = GetTwoObjects();

            //check locations
            firstObject_top = firstObjectLocation.Y;
            firstObject_bottom = firstObjectLocation.Y + 128;
            firstObject_left = firstObjectLocation.X;
            firstObject_right = firstObjectLocation.X + 128;

            if (secondObject.GetType() == typeof(Tile))
            {
                secondObject_top = secondObjectLocation.Y;
                secondObject_bottom = secondObjectLocation.Y + 64;
                secondObject_left = secondObjectLocation.X;
                secondObject_right = secondObjectLocation.X + 64;
            } else
            {
                secondObject_top = secondObjectLocation.Y;
                secondObject_bottom = secondObjectLocation.Y + 128;
                secondObject_left = secondObjectLocation.X;
                secondObject_right = secondObjectLocation.X + 128;
            }


            // objects collide:
            if (!(firstObject_right < secondObject_left || secondObject_right < firstObject_left || firstObject_bottom < secondObject_top || secondObject_bottom < firstObject_top)) 
            {
                if (firstObject_right >= secondObject_left)
                {
                    // left overlap (right side of player):
                    side_overlap = firstObject_right - secondObject_left;
                    direction = CollisionResolution.collideDirection.Left;
                }
                else
                {
                    // right overlap (left side of player):
                    side_overlap = secondObject_right - firstObject_left;
                    direction = CollisionResolution.collideDirection.Right;
                }

                if (firstObject_top <= secondObject_bottom)
                {
                    // bottom overlap (top side of player):
                    updown_overlap = secondObject_bottom - firstObject_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollisionResolution.collideDirection.Bottom;
                    }
                }
                else
                {
                    // top overlap (bottom side of player):
                    updown_overlap = firstObject_bottom - secondObject_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollisionResolution.collideDirection.Bottom;
                    }
                }

                Collide();

            }

        }
    }
}
