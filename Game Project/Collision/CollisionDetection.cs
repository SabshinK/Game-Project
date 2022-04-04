using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class CollisionDetection : IUpdateable
    {
        private ICollideable firstObject;
        private ICollideable secondObject;

        private IPlayer player;

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
        private Rectangle rectangleObject1;
        private Rectangle rectangleObject2;

        private CollisionResolution collisionResolution;
        public enum CollideDirection { Top, Bottom, Left, Right };
        public CollideDirection direction;

        GameObjectManager gameObjectManager;

        GameTime gameTime;

        private object[] listArray;

        List<IEnemy> enemies;
        List<IProjectile> projectiles;
        List<IItem> items;
        List<ITile> tiles;

        private const int movingObjectSize = 128;
        private const int tileSize = 64;

        public CollisionDetection()
        {
            player = GameObjectManager.Instance.player;

            //Ask Object Manager for the lists
            listArray = GameObjectManager.Instance.GetObjectLists();

            enemies = (List<IEnemy>)listArray[0];
            projectiles = (List<IProjectile>)listArray[1];
            items = (List<IItem>)listArray[2];
            tiles = (List<ITile>)listArray[3];

            collisionResolution = new CollisionResolution();
        }

        public void CheckCollision()
        {
            //check locations
            firstObject_top = firstObjectLocation.Y;
            firstObject_bottom = firstObjectLocation.Y + movingObjectSize;
            firstObject_left = firstObjectLocation.X;
            firstObject_right = firstObjectLocation.X + movingObjectSize;

            // change this part so that we don't use constants for sizing and instead access something like secondObject.size?
            if (secondObject.GetType() == typeof(Tile))
            {
                secondObject_top = secondObjectLocation.Y;
                secondObject_bottom = secondObjectLocation.Y + tileSize;
                secondObject_left = secondObjectLocation.X;
                secondObject_right = secondObjectLocation.X + tileSize;
            }
            else
            {
                secondObject_top = secondObjectLocation.Y;
                secondObject_bottom = secondObjectLocation.Y + movingObjectSize;
                secondObject_left = secondObjectLocation.X;
                secondObject_right = secondObjectLocation.X + movingObjectSize;
            }
            
            //calculate rectangles
            //are we sure this is how to make rectangles bc idk where to find the right info but everything i'm finding is making me think it should include width/height
            rectangleObject1 = new Rectangle((int)firstObjectLocation.X, (int)firstObjectLocation.Y, (int)firstObject_bottom, (int)firstObject_right);
            rectangleObject2 = new Rectangle((int)secondObjectLocation.X, (int)secondObjectLocation.Y, (int)secondObject_bottom, (int)secondObject_right);

            // objects collide:
            //if (!(firstObject_right < secondObject_left || secondObject_right < firstObject_left || firstObject_bottom < secondObject_top || secondObject_bottom < firstObject_top))
            if (rectangleObject1.Intersects(rectangleObject2)) // changed this so that we can make sure it works before changing everything else
            {
                // TO DO : make third rectangle using intersect method, compare width and height to determine what kind of collision (vert or horizontal),
                // not sure how to know what specific direction collision is without getting rid of the code we already have

                if (firstObject_right >= secondObject_left)
                {
                    // left overlap (right side of player):
                    side_overlap = firstObject_right - secondObject_left;
                    direction = CollideDirection.Left;
                }
                else
                {
                    // right overlap (left side of player):
                    side_overlap = secondObject_right - firstObject_left;
                    direction = CollideDirection.Right;
                }

                if (firstObject_top <= secondObject_bottom)
                {
                    // bottom overlap (top side of player):
                    updown_overlap = secondObject_bottom - firstObject_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollideDirection.Bottom;
                    }
                }
                else
                {
                    // top overlap (bottom side of player):
                    updown_overlap = firstObject_bottom - secondObject_top;
                    if (updown_overlap > side_overlap)
                    {
                        direction = CollideDirection.Bottom;
                    }
                }

                collisionResolution.ResolveCollision(firstObject, secondObject, direction, rectangleObject1, rectangleObject2);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in enemies)
            {
                // player and enemies
                firstObjectLocation = player.Position;
                firstObject = player;

                secondObjectLocation = enemy.Position;
                secondObject = enemy;
                
                CheckCollision();

                firstObjectLocation = enemy.Position;
                firstObject = enemy;

                foreach (ITile tile in tiles)
                {
                    // enemies and tiles
                        secondObjectLocation = tile.Position;
                        secondObject = tile;

                        CheckCollision();
                }
                foreach (IProjectile projectile in projectiles)
                {
                    // enemies and projectiles
                        secondObjectLocation = projectile.Position;
                        secondObject = projectile;

                        CheckCollision();
                }
            }

            firstObjectLocation = player.Position;
            firstObject = player;

            foreach (ITile tile in tiles)
            {
                // player and tiles
                        secondObjectLocation = tile.Position;
                        secondObject = tile;

                        CheckCollision();
            }
            foreach (IItem item in items) 
            {
                    // player and items
                        secondObjectLocation = item.Position;
                        secondObject = item;

                        CheckCollision();
            }
        }

    }
}
