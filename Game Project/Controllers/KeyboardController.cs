using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
	class KeyboardController : IController // wanted to add a new file instead of modifying a perfectly working file.
    {
        // Dictionary that keeps track of key mappings that are tied to the game state (the key). The contained dictionaries
		// Keep track of the key to be pressed, whether the key is to be pressed or held, and the ICommand to be executed upon key press
		private Dictionary<bool, Dictionary<Keys, Tuple<bool, ICommand>>> stateMappings;

		// Some keys should only fire off commands the moment they are pressed, so these keys will be stored and if they are being held then
		// a new command won't fire until the player stops pressing the key and presses it again
		private List<Keys> keysDown;

		public Game1 game;

        public KeyboardController(Game1 game)
		{
			this.game = game;
			keysDown = new List<Keys>();
		}

		public void RegisterCommand(bool pausedCommand, Keys key, bool isHeld, ICommand command)
		{
			stateMappings[pausedCommand].Add(key, new Tuple<bool, ICommand>(isHeld, command));
		}

		private void CheckKeysDown(KeyboardState state)
        {
			foreach (Keys key in keysDown)
            {
				if (state.IsKeyUp(key))
                {
					keysDown.Remove(key);
                }
            }
        }

		public void Update(GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState();
			Keys[] pressedKeys = state.GetPressedKeys();
			Dictionary<Keys, Tuple<bool, ICommand>> mappings = stateMappings[game.paused];
			
			// Clear out keys that aren't being pressed
			CheckKeysDown(state);

			foreach (Keys key in pressedKeys)
			{
				if (mappings.ContainsKey(key))
                {
					if (!keysDown.Contains(key) || mappings[key].Item1) // If the key we want isn't being pressed and held or if it should be held
					{
						mappings[key].Item2.Execute();

						// Keep track of the key if it doesn't need to be held
						if (!mappings[key].Item1)
							keysDown.Add(key);
					}
                }
			}
        }

		public void LoadContent(Player player, Sidekick sidekick)
		{
			stateMappings = new Dictionary<bool, Dictionary<Keys, Tuple<bool, ICommand>>>();
			stateMappings.Add(false, new Dictionary<Keys, Tuple<bool, ICommand>>());
			stateMappings.Add(true, new Dictionary<Keys, Tuple<bool, ICommand>>());

			RegisterCommand(false, Keys.A, true, new PlayerMoveLeftCommand(player));
			RegisterCommand(false, Keys.W, true, new PlayerJumpCommand(player));
			RegisterCommand(false, Keys.D, true, new PlayerMoveRightCommand(player));
			RegisterCommand(false, Keys.Left, true, new PlayerMoveLeftCommand(player));
			RegisterCommand(false, Keys.Up, true, new PlayerJumpCommand(player));
			RegisterCommand(false, Keys.Right, true, new PlayerMoveRightCommand(player));
			RegisterCommand(false, Keys.Q, false, new QuitCommand(game));			
			RegisterCommand(false, Keys.N, false, new AttackCommand(player));
			RegisterCommand(false, Keys.D1, false, new UseItemCommand(player, 1));
			RegisterCommand(false, Keys.D2, false, new UseItemCommand(player, 2));
			RegisterCommand(false, Keys.D3, false, new UseItemCommand(player, 3));
			RegisterCommand(false, Keys.D4, false, new UseItemCommand(player, 4));
			RegisterCommand(false, Keys.D5, false, new UseItemCommand(player, 5));
			RegisterCommand(false, Keys.E, false, new TakeDamageCommand(player));
			RegisterCommand(false, Keys.R, false, new ResetCommand(game));
			RegisterCommand(false, Keys.P, false, new PauseCommand(game));

			// AI Commands
			RegisterCommand(false, Keys.Space, false, new SidekickStayOrFollowCommand(sidekick));
            
			RegisterCommand(true, Keys.Q, false, new QuitCommand(game));
			RegisterCommand(true, Keys.R, false, new ResetCommand(game));
			RegisterCommand(true, Keys.P, false, new PauseCommand(game));
			RegisterCommand(true, Keys.I, false, new InventoryCommand(game));
			RegisterCommand(true, Keys.A, false, new ItemScrollLeftCommand());
			RegisterCommand(true, Keys.D, false, new ItemScrollRightCommand());
		}
	}
}
