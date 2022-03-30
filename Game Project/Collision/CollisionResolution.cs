using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;
using static Game_Project.CollisionDetection;

namespace Game_Project
{
    public class CollisionResolution
    {
        private Dictionary<Tuple<Type, Type, CollideDirection>, Tuple<string, string>> directionalCollisions = new Dictionary<Tuple<Type, Type, CollideDirection>, Tuple<string, string>>();
        private Dictionary<Tuple<Type, Type>, Tuple<string, string>> directionlessCollisions = new Dictionary<Tuple<Type, Type>, Tuple<string, string>>();

        public CollisionResolution()
        {
            // constructor
        }

        public void ResolveCollision(ICollideable object1, ICollideable object2, CollideDirection direction, Rectangle FirstRectangle, Rectangle SecondRectangle)
        {
            string commandObject1 = null;
            string commandObject2 = null;

            if (object1 != null && object2 != null) 
            {
                if (directionalCollisions.ContainsKey(new Tuple<Type, Type, CollideDirection>(object1.GetType(), object2.GetType(), direction)))
                {
                    commandObject1 = directionalCollisions[new Tuple<Type, Type, CollideDirection>(object1.GetType(), object2.GetType(), direction)].Item1;
                    commandObject2 = directionalCollisions[new Tuple<Type, Type, CollideDirection>(object1.GetType(), object2.GetType(), direction)].Item2;                    
                }
                else if (directionlessCollisions.ContainsKey(new Tuple<Type, Type>(object1.GetType(), object2.GetType())))
                {
                    commandObject1 = directionlessCollisions[new Tuple<Type, Type>(object1.GetType(), object2.GetType())].Item1;
                    commandObject2 = directionlessCollisions[new Tuple<Type, Type>(object1.GetType(), object2.GetType())].Item2;
                }

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
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(BatEnemy)), new Tuple<string, string>("TakeDamageCommand", "BatFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(BatEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "BatDamageCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(DragonEnemy)), new Tuple<string, string>("TakeDamageCommand", "DragonFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(DragonEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "DragonDamageCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(GelEnemy)), new Tuple<string, string>("TakeDamageCommand", "GelFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(GelEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "GelDamageCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(GoriyaEnemy)), new Tuple<string, string>("TakeDamageCommand", "GoriyaFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(GoriyaEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "GoriyaDamageCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(StalfosEnemy)), new Tuple<string, string>("TakeDamageCommand", "StalfosFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(StalfosEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "StalfosDamageCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(ZohEnemy)), new Tuple<string, string>("TakeDamageCommand", "ZohFlipCommand"));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(ZohEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "ZohDamageCommand"));

            // player colliding with the tiles
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(Tile)), new Tuple<string, string>("IdleCommand", null));
            directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(Tile), CollideDirection.Bottom), new Tuple<string, string>("PlayerFallCommand", null));

            //enemies colliding with the tiles
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Tile)), new Tuple<string, string>("BatFlipCommand", null));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Tile)), new Tuple<string, string>("DragonFlipCommand", null));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Tile)), new Tuple<string, string>("GelFlipCommand", null));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Tile)), new Tuple<string, string>("GoriyaFlipCommand", null));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Tile)), new Tuple<string, string>("StalfosFlipCommand", null));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Tile)), new Tuple<string, string>("ZohFlipCommand", null));

            // player colliding with items
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(Item)), new Tuple<string, string>(null, "RemoveItemCommand"));

            // enemies colliding with projectiles
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Arrow)), new Tuple<string, string>("BatDamageCommand", "RemoveArrowCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Arrow)), new Tuple<string, string>("DragonDamageCommand", "RemoveArrowCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Arrow)), new Tuple<string, string>("GelDamageCommand", "RemoveArrowCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Arrow)), new Tuple<string, string>("GoriyaDamageCommand", "RemoveArrowCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Arrow)), new Tuple<string, string>("StalfosDamageCommand", "RemoveArrowCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Arrow)), new Tuple<string, string>("ZohDamageCommand", "RemoveArrowCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(SwordBeam)), new Tuple<string, string>("BatDamageCommand", "RemoveSwordBeamCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(SwordBeam)), new Tuple<string, string>("DragonDamageCommand", "RemoveSwordBeamCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(SwordBeam)), new Tuple<string, string>("GelDamageCommand", "RemoveSwordBeamCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(SwordBeam)), new Tuple<string, string>("GoriyaDamageCommand", "RemoveSwordBeamCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(SwordBeam)), new Tuple<string, string>("StalfosDamageCommand", "RemoveSwordBeamCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(SwordBeam)), new Tuple<string, string>("ZohDamageCommand", "RemoveSwordBeamCommand"));

            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Boomerang)), new Tuple<string, string>("BatDamageCommand", "BoomerangChangeDirectionCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Boomerang)), new Tuple<string, string>("DragonDamageCommand", "BoomerangChangeDirectionCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Boomerang)), new Tuple<string, string>("GelDamageCommand", "BoomerangChangeDirectionCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Boomerang)), new Tuple<string, string>("GoriyaDamageCommand", "BoomerangChangeDirectionCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Boomerang)), new Tuple<string, string>("StalfosDamageCommand", "BoomerangChangeDirectionCommand"));
            directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Boomerang)), new Tuple<string, string>("ZohDamageCommand", "BoomerangChangeDirectionCommand"));
        }
    }
}
