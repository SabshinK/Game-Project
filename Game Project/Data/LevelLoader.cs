using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Game_Project
{
    public class LevelLoader
    {
        private static LevelLoader instance = new LevelLoader();
        public static LevelLoader Instance => instance;

        private XmlParser parser;
        private Dictionary<string, string> fileNames;

        public LevelLoader()
        {
            fileNames = new Dictionary<string, string>();
        }

        public void LoadLevel()
        {
            //// change so that full path name isn't necessary
            //parser = new XmlParser(@"Data/level.xml");
            //// Get data from the parser and give that data to the classes needed
            //ObjectManager.Instance.LoadDictionary(parser.ParseAsset());
            //SpriteFactory.Instance.LoadDictionary(parser.ParseAsset());
            //KeyboardController.Instance.LoadDictionary(parser.ParseAsset());
            foreach (KeyValuePair<string, string> element in fileNames)
            {
                XmlParser parser = new XmlParser(element.Value);

                Tuple<string, List<List<string>>> result = parser.ParseAsset();
                switch (result.Item1)
                {
                    case "ObjectData":
                        LoadObjectData(result.Item2);
                        break;
                    case "KeyboardMappings":
                        LoadKeyboardMappings(result.Item2);
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
                // create class of object type
                Type objectType = Type.GetType(dataList[0]);
                // instantiate the object
                var constructorInfo = typeof(Player).GetConstructor(new[] { typeof(Vector2) });
                ObjectManager.RegisterObject();
            }
        }

        //private void LoadKeyboardMappings(List<List<string>> data)
        //{
        //    foreach (List<string> dataList in data)
        //    {
        //        var type = Type.GetType(dataList[1]);
        //        Keys key = 
        //    }
        //}

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
            fileNames.Add("forest", @"Data/level.xml");
        }
    }
}
