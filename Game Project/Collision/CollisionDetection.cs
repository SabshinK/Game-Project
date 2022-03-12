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
        private CollisionResolution collisionResolution;

        private CollisionResolution.collideDirection direction;

        GameObjectManager gameObjectManager;

        GameTime gameTime;

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
            enemies = GameObjectManager.Instance.enemyList;
            projectiles = GameObjectManager.Instance.projectileList;
            items = GameObjectManager.Instance.itemList;
            tiles = GameObjectManager.Instance.tileList;
        }

        public void Collide()
        {

            collisionResolution = new CollisionResolution(firstObject, secondObject, direction);

        }

        public void CheckCollision()
        {
            //check locations
            firstObject_top = firstObjectLocation.Y;
            firstObject_bottom = firstObjectLocation.Y + movingObjectSize;
            firstObject_left = firstObjectLocation.X;
            firstObject_right = firstObjectLocation.X + movingObjectSize;

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

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in enemies)
            {
                foreach (ITile tile in tiles)
                {
                    foreach (IItem item in items) 
                    {
                        foreach (IProjectile projectile in projectiles)
                        {
                            // player and enemies
                            firstObjectLocation = player.Position;
                            firstObject = player;

                            secondObjectLocation = enemy.Position;
                            secondObject = enemy;

                            CheckCollision();

                            // player and tiles
                            firstObjectLocation = player.Position;
                            firstObject = player;

                            secondObjectLocation = tile.Position;
                            secondObject = tile;

                            CheckCollision();

                            // enemies and tiles
                            firstObjectLocation = enemy.Position;
                            firstObject = enemy;

                            secondObjectLocation = tile.Position;
                            secondObject = tile;

                            CheckCollision();

                            // player and items
                            firstObjectLocation = player.Position;
                            firstObject = player;

                            secondObjectLocation = item.Position;
                            secondObject = item;

                            CheckCollision();

                            // enemies and projectiles
                            firstObjectLocation = enemy.Position;
                            firstObject = enemy;

                            secondObjectLocation = projectile.Position;
                            secondObject = projectile;

                            CheckCollision();
                        }
                    }
                }
            }
        }
    }
}
