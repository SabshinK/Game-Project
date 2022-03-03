using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class CollisionDetector : ICollideable, IUpdateable
    {
        CollisionResolution collisionResolution;
        public CollisionDetector() {
            
        }

        public void Update(GameTime gameTime)
        {
            /*Update method would check the rectangles of all the sprites and see if any of them are intersecting.
             * It will call Collide() when it finds an intersection between two rectangles.
            */
        }
        
        public void Collide(Player Player, ICollideable Block, ICollideable CollideDirection) {
            //collisionResolution = new CollisionResolution(Player, Block, CollideDirection);
        }       
    }
}
