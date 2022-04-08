using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using static Game_Project.CollisionDetection;

namespace Game_Project
{
    public class CollisionResolution
    {
        private static CollisionResolution instance = new CollisionResolution();
        public static CollisionResolution Instance => instance;

        private Dictionary<Tuple<Type, Type, CollideDirection>, Tuple<string, string>> directionalCollisions = new Dictionary<Tuple<Type, Type, CollideDirection>, Tuple<string, string>>();
        private Dictionary<Tuple<Type, Type>, Tuple<string, string>> directionlessCollisions = new Dictionary<Tuple<Type, Type>, Tuple<string, string>>();

        public void ResolveCollision(IGameObject object1, IGameObject object2, CollideDirection direction, Rectangle collision)
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
                    ConstructorInfo constructor1 = commandType1.GetConstructor(types1);

                    ParameterInfo[] paramInfos = constructor1.GetParameters();
                    object[] parameters;
                    if (paramInfos.Length > 1)
                        parameters = new object[3] { object1, collision, (int)direction };
                    else
                        parameters = new object[1] { object1 };

                    ICommand command = constructor1.Invoke(parameters) as ICommand;
                    command.Execute();
                }
                if (commandObject2 != null)
                {
                    Type commandType2 = Type.GetType("Game_Project." + commandObject2);
                    Type[] types2 = { object2.GetType() };
                    ConstructorInfo constructor2 = commandType2.GetConstructor(types2);

                    ParameterInfo[] paramInfos = constructor2.GetParameters();
                    object[] parameters;
                    if (paramInfos.Length > 1)
                        parameters = new object[3] { object2, collision, (int)direction };
                    else
                        parameters = new object[1] { object2 };

                    ICommand command = constructor2.Invoke(parameters) as ICommand;
                    command.Execute();
                }
            }              
        }

        public void RegisterDirectionalCollision(Tuple<Type, Type, CollideDirection> key, Tuple<string, string> value)
        {
            directionalCollisions.Add(key, value);
        }

        public void RegisterDirectionlessCollision(Tuple<Type, Type> key, Tuple<string, string> value)
        {
            directionlessCollisions.Add(key, value);
        }

        public void LoadCollisionDictionary()
        {
            /*Many of these could use an ICommand called "FallBackCommand". 
             * This command would cause the player to be launched backwards after stepping on top of an enemy (if stepping on an enemy damages the player).
             * The player would fall back in the opposite direction thaat they were facing. 
             * For animators: For FallBackLeft, the player would be facing right, but be falling back left.
             */

            //// player colliding with the enemies
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(BatEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(BatEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(DragonEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(DragonEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(GelEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(GelEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(GoriyaEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(GoriyaEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(StalfosEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(StalfosEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(ZohEnemy)), new Tuple<string, string>("TakeDamageCommand", "EnemyChangeDirectionCommand"));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(ZohEnemy), CollideDirection.Bottom), new Tuple<string, string>(null, "EnemyDamageCommand"));

            //// player colliding with the tiles
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(Tile)), new Tuple<string, string>("IdleCommand", null));
            //directionalCollisions.Add(new Tuple<Type, Type, CollideDirection>(typeof(Player), typeof(Tile), CollideDirection.Bottom), new Tuple<string, string>("PlayerFallCommand", null));

            ////enemies colliding with the tiles
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Tile)), new Tuple<string, string>("EnemyChangeDirectionCommand", null));

            //// player colliding with items
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(Player), typeof(Item)), new Tuple<string, string>(null, "RemoveItemCommand"));

            //// enemies colliding with projectiles
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Arrow)), new Tuple<string, string>("EnemyDamageCommand", "RemoveArrowCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(SwordBeam)), new Tuple<string, string>("EnemyDamageCommand", "RemoveSwordBeamCommand"));

            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(BatEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(DragonEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GelEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(GoriyaEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(StalfosEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
            //directionlessCollisions.Add(new Tuple<Type, Type>(typeof(ZohEnemy), typeof(Boomerang)), new Tuple<string, string>("EnemyDamageCommand", "BoomerangChangeDirectionCommand"));
        }
    }
}
