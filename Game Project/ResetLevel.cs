using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    class ResetLevel
    {
        LevelLoader loader;
        public ResetLevel()
        {
            loader = new LevelLoader();
        }

        public void Reset()
        {
            loader.LoadLevel();
        }
    }
}
