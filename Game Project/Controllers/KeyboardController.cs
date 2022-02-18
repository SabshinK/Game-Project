using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Game_Project
{
    class KeyboardController : IController
    {
		private Dictionary<Keys, ICommand> controllerMappings;

		public KeyboardController()
		{
			controllerMappings = new Dictionary<Keys, ICommand>();
		}

		public void RegisterCommand(Keys key, ICommand command)
		{
			controllerMappings.Add(key, command);
		}

		public void Update()
        {
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				// Need to check if the key is valid first
				if (controllerMappings.ContainsKey(key))
                {
					controllerMappings[key].Execute();
                }
			}
		}

		// This wouldn't necessarily be done in this way
		public void LoadContent(Game1 game)
        {

		}
    }
}
