using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace Game_Project
{
    class XmlParser
    {
        private XmlReader reader;
        private XmlReaderSettings settings;
        private string fileName;
        private Dictionary<string, Func<object>> readTypes;

        public XmlParser(string fileName)
        {
            // load reader settings with XML Schema validation
            settings = new XmlReaderSettings();
            // change so that full path name isn't necessary
            settings.Schemas.Add("urn:level-schema", Path.GetFullPath(@"..\..\..\..\Game Project\Data\level.xsd"));
            settings.ValidationType = ValidationType.Schema;

            this.fileName = fileName;
        }

        public Tuple<string, List<List<string>>> ParseAsset()
        {
            // Declare data storage variables
            List<List<string>> data = new List<List<string>>();
            string type;

            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                // Jump to asset, store type for LevelLoader
                ReadToFollowing(reader, "Asset");
                type = reader[0];

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name.Equals("Item"))
                        {
                            data.Add(ParseItem(reader.ReadSubtree()));
                        }
                    }
                }
            }

            //// Parse until the end tag
            //while (!(reader.NodeType == XmlNodeType.EndElement && reader.Name.Equals("Asset")))
            //{
            //    reader.Read();
            //    if (reader.Name.Equals("Item"))
            //    {
            //        data.Add(ParseItem());
            //    }
            //}
            //// move past the end tag for next call

            return new Tuple<string, List<List<string>>>(type, data);
        }

        private List<string> ParseItem(XmlReader reader)
        {
            // Initialize list of string data
            List<string> data = new List<string>();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    data.Add(reader.Value);
                }
            }

            return data;
        }

        /// <summary>
        /// Reads content until the XmlNodeType with the given name is found
        /// </summary>
        /// <param name="element"></param>
        private void ReadToFollowing(XmlReader reader, string element)
        {
            while (!reader.Name.Equals(element))
            {
                reader.Read();
            }
        }

        private void LoadDictionary()
        {
            Func<object> GetType = () => reader.ReadContentAsInt();
        }
    }
}
