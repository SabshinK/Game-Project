using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static Game_Project.CollisionDetection;

namespace Game_Project
{
    public class LevelLoader
    {
        private static LevelLoader instance = new LevelLoader();
        public static LevelLoader Instance => instance;

        private Dictionary<string, string> fileNames;

        public LevelLoader()
        {
            fileNames = new Dictionary<string, string>();

            LoadDictionary();
        }

        public void LoadFile(string file)
        {
            XmlParser parser = new XmlParser(Path.GetFullPath(fileNames[file]));

            Tuple<string, List<List<Tuple<string, object>>>> result = parser.ParseAsset();

            // This should probably be replaced with some sort of dictionary access at some point
            switch (result.Item1)
            {
                case "ObjectData":
                    LoadObjectData(result.Item2);
                    break;
                case "AnimationData":
                    LoadAnimationData(result.Item2);
                    break;
                case "CollisionData":
                    LoadCollisionData(result.Item2);
                    break;
                default:
                    break;
            }
        }

        private void LoadAnimationData(List<List<Tuple<string, object>>> data)
        {
            foreach (List<Tuple<string, object>> itemList in data)
            {
                Rectangle[] frames = new Rectangle[itemList.Count - 4];

                // Convert all frames in the XML to rectangle objects
                for (int i = 4; i < itemList.Count; i++)
                {
                    // Rectangle parameters with be in form '%i %i %i %i', so the strings must be split and converted
                    string[] numbers = itemList[i].Item2.ToString().Split(' ', 4);
                    frames[i - 4] = new Rectangle(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]),
                        Convert.ToInt32(numbers[2]), Convert.ToInt32(numbers[3]));
                }

                SpriteFactory.Instance.RegisterAnimation(itemList[0].Item2.ToString(),
                    new Tuple<Texture2D, Rectangle[], int, int>(Texture2DStorage.GetTexture(itemList[1].Item2.ToString()), frames, 
                    Convert.ToInt32(itemList[2].Item2), Convert.ToInt32(itemList[3].Item2)));
            }
        }

        private void LoadCollisionData(List<List<Tuple<string, object>>> data)
        {
            foreach (List<Tuple<string, object>> itemList in data)
            {
                int direction = (int)itemList[2].Item2;
                string command1 = null;
                string command2 = null;
                if (!itemList[3].Item2.ToString().Equals("null"))
                    command1 = itemList[3].Item2.ToString();
                if (!itemList[4].Item2.ToString().Equals("null"))
                    command2 = itemList[4].Item2.ToString();

                if (direction >= 0)
                {
                    CollisionResolution.Instance.RegisterDirectionalCollision(new Tuple<Type, Type, CollideDirection>(
                        Type.GetType("Game_Project." + itemList[0].Item2), Type.GetType("Game_Project." + itemList[1].Item2), 
                        (CollideDirection)direction), new Tuple<string, string>(command1, command2));
                }
                else
                {
                    CollisionResolution.Instance.RegisterDirectionlessCollision(new Tuple<Type, Type>(
                        Type.GetType("Game_Project." + itemList[0].Item2), Type.GetType("Game_Project." + itemList[1].Item2)), 
                        new Tuple<string, string>(command1, command2));
                }
            }
        }

        private void LoadObjectData(List<List<Tuple<string, object>>> data)
        {
            foreach (List<Tuple<string, object>> itemList in data)
            {
                string type = itemList[0].Item2.ToString();
                ConstructorInfo constructorInfo = Type.GetType("Game_Project." + type).GetConstructor(new[] { typeof(UniversalParameterObject) });

                if (constructorInfo != null)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>();

                    parameters.Add("Position", new Vector2(Convert.ToInt32(itemList[1].Item2), Convert.ToInt32(itemList[2].Item2)));
                    // Go through any other parameters
                    for (int i = 3; i < itemList.Count; i++)
                    {
                        parameters.Add(itemList[i].Item1, itemList[i].Item2);
                    }

                    // create object with given parameter object
                    object[] parameterObject = new object[] { new UniversalParameterObject(parameters) };
                    GameObjectManager.Instance.RegisterObject(constructorInfo.Invoke(parameterObject) as IGameObject);
                }
            }
        }

        private void LoadDictionary()
        {
            fileNames.Add("sprites", @"..\..\..\..\Game Project\Data\Animation.xml");
            fileNames.Add("collision", @"..\..\..\..\Game Project\Data\Collision.xml");
            fileNames.Add("forest", @"..\..\..\..\Game Project\Data\Objects.xml");
        }
    }
}
