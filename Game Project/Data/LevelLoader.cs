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
        private Dictionary<string, Type> types;

        public LevelLoader()
        {
            fileNames = new Dictionary<string, string>();
            types = new Dictionary<string, Type>();

            LoadDictionary();
            LoadTypes();
        }

        public void LoadLevel()
        {
            foreach (KeyValuePair<string, string> element in fileNames)
            {
                XmlParser parser = new XmlParser(Path.GetFullPath(element.Value));

                Tuple<string, List<List<object>>> result = parser.ParseAsset();

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

        private void LoadObjectData(List<List<object>> data)
        {
            foreach (List<object> dataList in data)
            {
                // Store object type
                string type = dataList[0].ToString();

                // Verify that the type given is a type that can be instantiated
                if (types.ContainsKey(type))
                {
                    var constructorInfo = types[type].GetConstructor(new[] { typeof(UniversalParameterObject) });

                    if (constructorInfo != null)
                    {
                        // need to load in the data correctly
                        object[] parameters = new object[]
                        {
                            new UniversalParameterObject(new object[1]) 
                        };
                        GameObjectManager.Instance.RegisterObject(constructorInfo.Invoke(parameters));
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

        private void LoadAnimationData(List<List<object>> data)
        {
            foreach (List<object> dataList in data)
            {
                Rectangle[] frames = new Rectangle[dataList.Count - 4];

                // Convert all frames in the XML to rectangle objects
                for (int i = 4; i < dataList.Count; i++)
                {
                    // Rectangle parameters with be in form '%i %i %i %i', so the strings must be split and converted
                    string[] numbers = dataList[i].ToString().Split(' ', 4);
                    frames[i - 4] = new Rectangle(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1]),
                        Convert.ToInt32(numbers[2]), Convert.ToInt32(numbers[3]));
                }

                SpriteFactory.Instance.RegisterAnimation(dataList[0].ToString(), 
                    new Tuple<string, Rectangle[], int, int>(dataList[1].ToString(), frames, Convert.ToInt32(dataList[2]), Convert.ToInt32(dataList[3])));
            }
        }

        private void LoadDictionary()
        {
            fileNames.Add("sprites", @"..\..\..\..\Game Project\Data\Animation.xml");
            fileNames.Add("forest", @"..\..\..\..\Game Project\Data\Objects.xml");            
        }

        private void LoadTypes()
        {
            types.Add("Player", typeof(Player));
            types.Add("BatEnemy", typeof(BatEnemy));
            types.Add("DragonEnemy", typeof(DragonEnemy));
            types.Add("GelEnemy", typeof(GelEnemy));
            types.Add("GoriyaEnemy", typeof(GoriyaEnemy));
            types.Add("StalfosEnemy", typeof(StalfosEnemy));
            types.Add("ZohEnemy", typeof(ZohEnemy));
            types.Add("Tile", typeof(Tile));
            types.Add("Arrow", typeof(Arrow));
            types.Add("Bomb", typeof(Bomb));
            types.Add("Boomerang", typeof(Boomerang));
            types.Add("Candle", typeof(Candle));
            types.Add("SwordBeam", typeof(SwordBeam));
        }
    }
}
