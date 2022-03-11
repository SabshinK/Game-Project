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

        private int firstObject_top;
        private int firstObject_bottom;
        private int firstObject_left;
        private int firstObject_right;
        private int secondObject_top;
        private int secondObject_bottom;
        private int secondObject_left;
        private int secondObject_right;
        private int side_overlap;
        private int updown_overlap;
        private CollisionResolution collisionResolution; // ??

        private CollisionResolution.collideDirection direction;

        public CollisionDetection()
        {
            //direction = null; // is this bad? i just feel weird about not defining direction outside of an if-else statement in Update()
            /*  So I think all the stuff that was in here should go in update? I think the object manager or game will call
            *   Update on the collision detector object which will check for all collisions with the info that was in here.
            **/
        }

        public void Collide()
        {

            collisionResolution = new CollisionResolution(firstObject, secondObject, direction); // am i supposed to do anything else with this?

        }

        public void Update(GameTime gameTime)
        {
            //check locations
            firstObject_top = firstObject.location.y;
            firstObject_bottom = firstObject.location.y + firstObject.size.height;
            firstObject_left = firstObject.location.x;
            firstObject_right = firstObject.location.x + firstObject.size.width;
            secondObject_top = secondObject.location.y;
            secondObject_bottom = secondObject.location.y + secondObject.size.height;
            secondObject_left = secondObject.location.x;
            secondObject_right = secondObject.location.x + secondObject.size.width;

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
