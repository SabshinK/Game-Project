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
            collisionResolution = new CollisionResolution();
        }

        public void GetCollisionLists()
        {
            player = GameObjectManager.Instance.player;

            //Ask Object Manager for the lists
            listArray = GameObjectManager.Instance.GetObjectLists();

            enemies = (List<IEnemy>)listArray[0];
            projectiles = (List<IProjectile>)listArray[1];
            items = (List<IItem>)listArray[2];
            tiles = (List<ITile>)listArray[3];

        }

        public void CheckCollision()
        {
            // change this part so that we don't use constants for sizing and instead access something like secondObject.size?
            rectangleObject1 = new Rectangle((int)firstObjectLocation.X, (int)firstObjectLocation.Y, movingObjectSize, movingObjectSize);
            if (secondObject.GetType() == typeof(Tile)) rectangleObject2 = new Rectangle((int)secondObjectLocation.X, (int)secondObjectLocation.Y, tileSize, tileSize);
            else rectangleObject2 = new Rectangle((int)secondObjectLocation.X, (int)secondObjectLocation.Y, movingObjectSize, movingObjectSize);

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
