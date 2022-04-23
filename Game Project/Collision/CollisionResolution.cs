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
                    ConstructorInfo[] constructor1 = commandType1.GetConstructors();

                    ParameterInfo[] paramInfos = constructor1[0].GetParameters();
                    object[] parameters;
                    if (paramInfos.Length > 1)
                        parameters = new object[3] { object1, collision, (int)direction };
                    else
                        parameters = new object[1] { object1 };

                    ICommand command = constructor1[0].Invoke(parameters) as ICommand;
                    command.Execute();
                }
                if (commandObject2 != null)
                {
                    Type commandType2 = Type.GetType("Game_Project." + commandObject2);
                    ConstructorInfo[] constructor2 = commandType2.GetConstructors();

                    ParameterInfo[] paramInfos = constructor2[0].GetParameters();
                    object[] parameters;
                    if (paramInfos.Length > 1)
                        parameters = new object[3] { object2, collision, (int)direction };
                    else
                        parameters = new object[1] { object2 };

                    ICommand command = constructor2[0].Invoke(parameters) as ICommand;
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

        }
    }
}
