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

        public XmlParser(string fileName)
        {
            // load reader settings with XML Schema validation
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add("urn:level-schema", "level.xsd");
            settings.ValidationType = ValidationType.Schema;

            reader = XmlReader.Create(fileName, settings);
        }

        public void Parse()
        {

        }
    }
}
