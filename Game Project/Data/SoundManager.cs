using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class SoundManager
    {
        private static SoundManager instance = new SoundManager();
        public static SoundManager Instance => instance;

        private List<Song> music = new List<Song>();

        private Dictionary<string, SoundEffect> sfx = new Dictionary<string, SoundEffect>();

        public void PlayEffect(string effect)
        {
            sfx[effect].Play();
        }

        public void PlayMusic()
        {

        }
        
        public void LoadContent(ContentManager content)
        {
            music.Add(content.Load<Song>("01 - At Dooms Gate"));

            sfx.Add("getAmmo", content.Load<SoundEffect>(""));
            sfx.Add("getHeart", content.Load<SoundEffect>(""));
            sfx.Add("getInstrument", content.Load<SoundEffect>(""));
            sfx.Add("jump", content.Load<SoundEffect>(""));
            sfx.Add("takeDamage", content.Load<SoundEffect>(""));
            sfx.Add("damageEnemy", content.Load<SoundEffect>(""));

            MediaPlayer.Play(music[0]);
            MediaPlayer.IsRepeating = true;
        }
    }
}
