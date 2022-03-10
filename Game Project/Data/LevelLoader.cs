using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Game_Project
{
    public class LevelLoader
    {
        private static LevelLoader instance = new LevelLoader();
        public static LevelLoader Instance => instance;

        private Dictionary<string, string> fileNames;
        private List<Type> types;

        public LevelLoader()
        {
            fileNames = new Dictionary<string, string>();
            types = new List<Type>();

            LoadDictionary();
            LoadTypes();
        }

        public void LoadLevel()
        {
            foreach (KeyValuePair<string, string> element in fileNames)
            {
                XmlParser parser = new XmlParser(Path.GetFullPath(element.Value));

                Tuple<string, List<List<string>>> result = parser.ParseAsset();

                // This should probably be replaced with some sort of dictionary access at some point
                switch (result.Item1)
                {
                    case "ObjectData":
                        LoadObjectData(result.Item2);
                        break;
                    case "KeyboardMappings":
                        //LoadKeyboardMappings(result.Item2);
                        break;
                    case "AnimationData":
                        LoadAnimationData(result.Item2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadObjectData(List<List<string>> data)
        {
            foreach (List<string> dataList in data)
            {
                // Verify that the type given is a type that can be instantiated
                for (int i = 0; i < types.Count; i++)
                {
                    if (types[i] == Type.GetType(dataList[0]))
                    {
                        // This only works currently because all game object constructors only have one parameter, this may not be the case
                        // later and will have to be changed, simply add UPO
                        var constructorInfo = types[i].GetConstructor(new[] { typeof(UniversalParameterObject) });

                        // verify that constructor info isn't null
                        if (constructorInfo != null)
                        {
                            object[] parameters = new object[] 
                            { 
                                new UniversalParameterObject(new Vector2(Convert.ToInt32(dataList[1]), Convert.ToInt32(dataList[2]))) 
                            };
                            GameObjectManager.Instance.RegisterObject(constructorInfo.Invoke(parameters));
                        }
                    }
                }
            }
        }

        private void LoadKeyboardMappings(List<List<string>> data)
        {
            foreach (List<string> dataList in data)
            {
                var type = Type.GetType(dataList[1]);
            }
        }

        private void LoadAnimationData(List<List<string>> data)
        {
            foreach (List<string> dataList in data)
            {
                Rectangle[] frames = new Rectangle[dataList.Count - 4];

                // Convert all frames in the XML to rectangle objects
                for (int i = 4; i < dataList.Count; i++)
                {
                    // Rectangle parameters with be in form '%i %i %i %i', so the strings must be split and converted
                    string[] numbers = dataList[i].Split(' ', 4);
                    frames[i - 4] = new Rectangle(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]),
                        Convert.ToInt32(numbers[2]), Convert.ToInt32(numbers[3]));
                }

                SpriteFactory.Instance.RegisterAnimation(dataList[0], 
                    new Tuple<string, Rectangle[], int, int>(dataList[1], frames, Convert.ToInt32(dataList[2]), Convert.ToInt32(dataList[3])));
            }
        }

        private void LoadDictionary()
        {
            fileNames.Add("forest", @"..\..\..\..\Game Project\Data\Objects.xml");
            fileNames.Add("sprites", @"..\..\..\..\Game Project\Data\Animation.xml");
        }

        private void LoadTypes()
        {
            types.Add(typeof(Player));
            types.Add(typeof(BatEnemy));
            types.Add(typeof(DragonEnemy));
            types.Add(typeof(GelEnemy));
            types.Add(typeof(GoriyaEnemy));
            types.Add(typeof(StalfosEnemy));
            types.Add(typeof(ZohEnemy));
            types.Add(typeof(Tile));
            types.Add(typeof(Arrow));
            types.Add(typeof(Bomb));
            types.Add(typeof(Boomerang));
            types.Add(typeof(Candle));
            types.Add(typeof(SwordBeam));
        }
    }
}
