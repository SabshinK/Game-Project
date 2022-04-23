using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Game_Project.GameStateMachine;

namespace Game_Project
{
	class KeyboardController : IController // wanted to add a new file instead of modifying a perfectly working file.
    {
        // Dictionary that keeps track of key mappings that are tied to the game state (the key). The contained dictionaries
		// Keep track of the key to be pressed, whether the key is to be pressed or held, and the ICommand to be executed upon key press
		private Dictionary<states, Dictionary<Keys, Tuple<bool, ICommand>>> stateMappings;

		// Some keys should only fire off commands the moment they are pressed, so these keys will be stored and if they are being held then
		// a new command won't fire until the player stops pressing the key and presses it again
		private List<Keys> keysDown;

		public Game1 game;

        public KeyboardController(Game1 game)
		{
			this.game = game;
			keysDown = new List<Keys>();
		}

		public void RegisterCommand(states currState, Keys key, bool isHeld, ICommand command)
		{
			stateMappings[currState].Add(key, new Tuple<bool, ICommand>(isHeld, command));
		}

		private void CheckKeysDown(KeyboardState state)
        {
			// Since we can't iterate through a list and remove things from it at the same time, we will keep track of the
			// keys that need to be removed and modify keysDown after iterating
			List<Keys> keysUp = new List<Keys>();

			foreach (Keys key in keysDown)
			{
				if (state.IsKeyUp(key))
					keysUp.Add(key);
			}

			foreach (Keys key in keysUp)
            {
				keysDown.Remove(key);
            }
        }

		public void Update(GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState();
			Keys[] pressedKeys = state.GetPressedKeys();
			Dictionary<Keys, Tuple<bool, ICommand>> mappings = stateMappings[game.State];

			// Clear out keys that aren't being pressed
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
			
			CheckKeysDown(state);
        }

		public void LoadContent(GameStateMachine stateMachine, Player player, Sidekick sidekick)
		{
			stateMappings = new Dictionary<states, Dictionary<Keys, Tuple<bool, ICommand>>>();
			stateMappings.Add(states.playing, new Dictionary<Keys, Tuple<bool, ICommand>>());
			stateMappings.Add(states.paused, new Dictionary<Keys, Tuple<bool, ICommand>>());
			stateMappings.Add(states.over, new Dictionary<Keys, Tuple<bool, ICommand>>());
			stateMappings.Add(states.win, new Dictionary<Keys, Tuple<bool, ICommand>>());

			RegisterCommand(states.playing, Keys.A, true, new PlayerMoveLeftCommand(player));
			RegisterCommand(states.playing, Keys.W, true, new PlayerJumpCommand(player));
			RegisterCommand(states.playing, Keys.D, true, new PlayerMoveRightCommand(player));
			RegisterCommand(states.playing, Keys.Left, true, new PlayerMoveLeftCommand(player));
			RegisterCommand(states.playing, Keys.Up, true, new PlayerJumpCommand(player));
			RegisterCommand(states.playing, Keys.Right, true, new PlayerMoveRightCommand(player));
			RegisterCommand(states.playing, Keys.Q, false, new QuitCommand(game));			
			RegisterCommand(states.playing, Keys.N, false, new AttackCommand(player));
			RegisterCommand(states.playing, Keys.E, false, new UseItemCommand(player));
			RegisterCommand(states.playing, Keys.R, false, new ResetCommand(game));
			RegisterCommand(states.playing, Keys.P, false, new PauseCommand(stateMachine));

			// Musician Commands
			RegisterCommand(states.playing, Keys.Space, false, new MusicianCommand(player));

			// Sidekick Commands
			//RegisterCommand(states.paused, Keys.Space, false, new SidekickStayOrFollowCommand(sidekick));

			RegisterCommand(states.paused, Keys.Q, false, new QuitCommand(game));
			RegisterCommand(states.paused, Keys.R, false, new ResetCommand(game));
			RegisterCommand(states.paused, Keys.P, false, new PauseCommand(stateMachine));
			RegisterCommand(states.paused, Keys.A, false, new ItemScrollLeftCommand());
			RegisterCommand(states.paused, Keys.D, false, new ItemScrollRightCommand());

			RegisterCommand(states.win, Keys.Q, false, new QuitCommand(game));
			RegisterCommand(states.win, Keys.R, false, new ResetCommand(game));

			RegisterCommand(states.over, Keys.Q, false, new QuitCommand(game));
			RegisterCommand(states.over, Keys.R, false, new ResetCommand(game));
		}
	}
}
