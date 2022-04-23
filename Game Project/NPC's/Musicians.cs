using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class Musicians
    {
        
        public delegate void MusicianActivated(string itemName);

        public static event MusicianActivated OnActivateMusician;

        public static void OnEvent(string itemName)
        {
            if (OnActivateMusician != null)
                OnActivateMusician(itemName);
        }

    }
}
