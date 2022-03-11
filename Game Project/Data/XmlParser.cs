using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Game_Project
{
    public class XmlParser
    {
        private XmlReader reader;
        private XmlReaderSettings settings;
        private Dictionary<string, Func<object>> readTypes;

        public XmlParser(string fileName)
        {
            // load reader settings with XML Schema validation
            settings = new XmlReaderSettings();
            // change so that full path name isn't necessary
            settings.Schemas.Add("urn:level-schema", Path.GetFullPath(@"..\..\..\..\Game Project\Data\level.xsd"));
            settings.ValidationType = ValidationType.Schema;

            //this.fileName = fileName;
            reader = XmlReader.Create(fileName, settings);

            readTypes = new Dictionary<string, Func<object>>();
            LoadDictionary();
        }

        public Tuple<string, List<List<Tuple<int, object>>>> ParseAsset()
        {
            // Declare data storage variables
            List<List<Tuple<int, object>>> data = new List<List<Tuple<int, object>>>();
            string type;

            // Jump to asset, store type for LevelLoader
            ReadToFollowing("Asset");
            type = reader[0];

            // looking for next item subtree
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (reader.Name.Equals("Item"))
                    {
                        // Store the original position of the reader and set the reader to a subtree for easy reading
                        XmlReader storedReader = reader;
                        reader = reader.ReadSubtree();
                        // Call on ParseItem to read the subtree and store the data
                        data.Add(ParseItem());
                        // set reader back and skip to the end Item tag
                        reader = storedReader;
                        ReadToFollowing("Item");
                    }
                }
            }

            return new Tuple<string, List<List<Tuple<int, object>>>>(type, data);
        }

        private List<Tuple<int, object>> ParseItem()
        {
            // Initialize list of string data
            List<Tuple<int, object>> data = new List<Tuple<int, object>>();

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    if (readTypes.ContainsKey(reader.Name))
                    {
                        // if the item has an attribute, it is the index for the parameter object and should be returned
                        int parameterIndex = -1;
                        if (reader.HasAttributes)
                            parameterIndex = Convert.ToInt32(reader[0]);
                        data.Add(new Tuple<int, object>(parameterIndex, readTypes[reader.Name].Invoke()));
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Reads content until the XmlNodeType with the given name is found
        /// </summary>
        /// <param name="element"></param>
        private void ReadToFollowing(string element)
        {
            while (!reader.Name.Equals(element))
            {
                reader.Read();
            }
        }

        private void LoadDictionary()
        {
            readTypes.Add("ObjectType", () => reader.ReadElementContentAsString());
            readTypes.Add("X", () => reader.ReadElementContentAsInt());
            readTypes.Add("Y", () => reader.ReadElementContentAsInt());
            readTypes.Add("FacingRight", () => reader.ReadElementContentAsBoolean());
            readTypes.Add("Animation", () => reader.ReadElementContentAsString());
            readTypes.Add("Key", () => reader.ReadElementContentAsString());
            readTypes.Add("Command", () => reader.ReadElementContentAsString());
            readTypes.Add("AnimationName", () => reader.ReadElementContentAsString());
            readTypes.Add("Texture", () => reader.ReadElementContentAsString());
            readTypes.Add("Speed", () => reader.ReadElementContentAsInt());
            readTypes.Add("Scale", () => reader.ReadElementContentAsInt());
            readTypes.Add("Rectangle", () => reader.ReadElementContentAsString());
        }
    }
}
