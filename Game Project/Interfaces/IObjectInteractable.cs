using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project.Interfaces
{
    internal interface IObjectInteractable
    {
        public void Interact(); // Changing states and updating the game for when an interactable object is influenced by the player.
    }
}
