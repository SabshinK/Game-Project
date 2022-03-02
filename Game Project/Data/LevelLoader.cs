using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class LevelLoader
    {
        private XmlParser parser;

        public LevelLoader()
        {
            parser = new XmlParser("level.xml");
        }
    }
}
