﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Game_Project
{
    class CollisionResolution : ICollideable
    {
        public enum collideDirection {Top, Bottom, Left, Right};
        private collideDirection direction;

        private ICollideable object1;       
        private ICollideable object2;

        private static Dictionary<Tuple<Type, Type, collideDirection>, Tuple<string, string>> collisionDictionary = new Dictionary<Tuple<Type, Type, collideDirection>, Tuple<string, string>>();

        private string commandObject1;
        private string commandObject2;

        public CollisionResolution(ICollideable Object1, ICollideable Object2, collideDirection CollideDirection)
        {
            direction = CollideDirection;
            object1 = Object1;
            object2 = Object2;

            Collide();
        }

        public void Collide()
        {
            if (object1 != null && object2 != null) {
                commandObject1 = collisionDictionary[new Tuple<Type, Type, collideDirection>(object1.GetType(), object2.GetType(), direction)].Item1;
                commandObject2 = collisionDictionary[new Tuple<Type, Type, collideDirection>(object1.GetType(), object2.GetType(), direction)].Item2;

                if (commandObject1 != null)
                {
                    Type commandType1 = Type.GetType("Game_Project." + commandObject1);
                    Type[] types1 = { object1.GetType() };
                    object[] parameters1 = { object1 };
                
                    ConstructorInfo constructor1 = commandType1.GetConstructor(types1);
                    constructor1.Invoke(parameters1);
                }
                if (commandObject2 != null)
                {
                    Type commandType2 = Type.GetType("Game_Project." + commandObject2);
                    Type[] types2 = { object2.GetType() };
                    object[] parameters2 = { object2 };

                     ConstructorInfo constructor2 = commandType2.GetConstructor(types2);
                    constructor2.Invoke(parameters2);
                }
            }
              
        }

        public void LoadCollisionDictionary()
        {
            /*Many of these could use an ICommand called "FallBackCommand". 
             * This command would cause the player to be launched backwards after stepping on top of an enemy (if stepping on an enemy damages the player).
             * The player would fall back in the opposite direction thaat they were facing. 
             * For animators: For FallBackLeft, the player would be facing right, but be falling back left.
             */

            // player colliding with the enemies
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "BatFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "BatFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Top), new Tuple<string, string>("TakeDamageCommand", "BatFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(BatEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "BatDamageCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "DragonFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "DragonFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(DragonEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "DragonDamageCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "GelFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "GelFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GelEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "GelDamageCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "GoriyaFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "GoriyaFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(GoriyaEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "GoriyaDamageCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "StalfosFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "StalfosFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(StalfosEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "StalfosDamageCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Left), new Tuple<string, string>("TakeDamageCommand", "ZohFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Right), new Tuple<string, string>("TakeDamageCommand", "ZohFlipCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(ZohEnemy), collideDirection.Bottom), new Tuple<string, string>(null, "ZohDamageCommand"));

            // player colliding with the tiles
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Left), new Tuple<string, string>("IdleCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Right), new Tuple<string, string>("IdleCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Top), new Tuple<string, string>("IdleCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Tile), collideDirection.Bottom), new Tuple<string, string>("PlayerFallCommand", null));

            //enemies colliding with the tiles
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(Tile), collideDirection.Bottom), new Tuple<string, string>("BatFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(Tile), collideDirection.Top), new Tuple<string, string>("BatFlipCommand", null));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(Tile), collideDirection.Left), new Tuple<string, string>("DragonFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(Tile), collideDirection.Right), new Tuple<string, string>("DragonFlipCommand", null));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(Tile), collideDirection.Left), new Tuple<string, string>("GelFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(Tile), collideDirection.Right), new Tuple<string, string>("GelFlipCommand", null));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(Tile), collideDirection.Left), new Tuple<string, string>("GoriyaFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(Tile), collideDirection.Right), new Tuple<string, string>("GoriyaFlipCommand", null));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(Tile), collideDirection.Left), new Tuple<string, string>("StalfosFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(Tile), collideDirection.Right), new Tuple<string, string>("StalfosFlipCommand", null));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(Tile), collideDirection.Left), new Tuple<string, string>("ZohFlipCommand", null));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(Tile), collideDirection.Right), new Tuple<string, string>("ZohFlipCommand", null));

            // player colliding with items
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Item), collideDirection.Left), new Tuple<string, string>(null, "RemoveItemCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Item), collideDirection.Right), new Tuple<string, string>(null, "RemoveItemCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Item), collideDirection.Top), new Tuple<string, string>(null, "RemoveItemCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(Player), typeof(Item), collideDirection.Bottom), new Tuple<string, string>(null, "RemoveItemCommand"));

            // enemies colliding with projectiles
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("BatDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("BatDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("BatDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(BatEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("BatDamageCommand", "RemoveProjectileCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("DragonDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("DragonDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("DragonDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(DragonEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("DragonDamageCommand", "RemoveProjectileCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("GelDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("GelDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("GelDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GelEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("GelDamageCommand", "RemoveProjectileCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("GoriyaDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("GoriyaDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("GoriyaDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(GoriyaEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("GoriyaDamageCommand", "RemoveProjectileCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("StalfosDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("StalfosDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("StalfosDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(StalfosEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("StalfosDamageCommand", "RemoveProjectileCommand"));

            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(IProjectile), collideDirection.Left), new Tuple<string, string>("ZohDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(IProjectile), collideDirection.Right), new Tuple<string, string>("ZohDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(IProjectile), collideDirection.Top), new Tuple<string, string>("ZohDamageCommand", "RemoveProjectileCommand"));
            collisionDictionary.Add(new Tuple<Type, Type, collideDirection>(typeof(ZohEnemy), typeof(IProjectile), collideDirection.Bottom), new Tuple<string, string>("ZohDamageCommand", "RemoveProjectileCommand"));
        }
    }
}
