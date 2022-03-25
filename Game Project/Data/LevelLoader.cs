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

        // This constant corresponds to the number of parameters that need to be passed to the UniversalParameterObject
        // If more parameters are added then this number will change
        private const int UPO_PARAMETER_COUNT = 3;

        public LevelLoader()
        {
            fileNames = new Dictionary<string, string>();
            types = new Dictionary<string, Type>();

            LoadDictionary();
            LoadTypes();
        }

        public void LoadLevel()
        {
            // Guarantee new instances of the dictionaries and lists of data
            GameObjectManager.Instance.Reset();

            foreach (KeyValuePair<string, string> element in fileNames)
            {
                XmlParser parser = new XmlParser(Path.GetFullPath(element.Value));

                Tuple<string, List<List<Tuple<int, object>>>> result = parser.ParseAsset();

                // This should probably be replaced with some sort of dictionary access at some point
                switch (result.Item1)
                {
                    case "ObjectData":
                        LoadObjectData(result.Item2);
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadObjectData(List<List<Tuple<int, object>>> data)
        {
            foreach (List<Tuple<int, object>> itemList in data)
            {
                // Store object type
                string type = itemList[0].Item2.ToString();

                // Verify that the type given is a type that can be instantiated
                if (types.ContainsKey(type))
                {
                    var constructorInfo = types[type].GetConstructor(new[] { typeof(UniversalParameterObject) });

                    if (constructorInfo != null)
                    {
                        object[] parameters = new object[UPO_PARAMETER_COUNT];
                        // The first parameter is always a location vector
                        parameters[0] = new Vector2(Convert.ToInt32(itemList[1].Item2), Convert.ToInt32(itemList[2].Item2));
                        // Go through any other parameters
                        for (int i = 3; i < itemList.Count; i++)
                        {
                            // The parameter at the specified index should be set to the item at index i within in the loop
                            parameters[itemList[i].Item1] = itemList[i].Item2;
                        }

                        // create object with given parameter object
                        object[] parameterObject = new object[] { new UniversalParameterObject(parameters) };
                        GameObjectManager.Instance.RegisterObject(constructorInfo.Invoke(parameterObject));
                    }
                }
            }
        }

        private void LoadDictionary()
        {
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
