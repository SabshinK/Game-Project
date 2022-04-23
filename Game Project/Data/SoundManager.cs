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

        private Dictionary<string, SoundEffect> music = new Dictionary<string, SoundEffect>();
        //private delegate void LayerInstruments();
        //private LayerInstruments PlayLayered;

        private Dictionary<string, SoundEffect> sfx = new Dictionary<string, SoundEffect>();

        public void PlayEffect(string effect)
        {
            sfx[effect].Play();
        }
        
        public void LoadContent(ContentManager content)
        {
            sfx.Add("getAmmo", content.Load<SoundEffect>("Get Item"));
            //sfx.Add("getHeart", content.Load<SoundEffect>(""));
            //sfx.Add("getInstrument", content.Load<SoundEffect>(""));
            sfx.Add("jump", content.Load<SoundEffect>("JumpUp"));
            //sfx.Add("takeDamage", content.Load<SoundEffect>(""));
            //sfx.Add("damageEnemy", content.Load<SoundEffect>(""));

            //music.Add("accordianGeneric", content.Load<SoundEffect>("Accordion"));
            //music.Add("fluteGeneric", content.Load<SoundEffect>("Flute"));
            //music.Add("drumGeneric", content.Load<SoundEffect>("Drums"));
            //music.Add("harpGeneric", content.Load<SoundEffect>("Harp"));
            //music.Add("guitarGeneric", content.Load<SoundEffect>("Guitar"));
            //music.Add("speakerGeneric", content.Load<SoundEffect>("Bass_Synth_Speaker"));

            //AddMusic("guitarGeneric");

            MediaPlayer.Play(content.Load<Song>("Game_Soundtrack_All_Instruments"));
            MediaPlayer.IsRepeating = true;
        }
    }
}
