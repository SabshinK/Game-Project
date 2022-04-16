using System;
using System.Collections.Generic;
using System.Text;
using static Game_Project.ISidekickStateMachine;

namespace Game_Project.Sidekick
{
    class SidekickStateMachine :ISidekickStateMachine
    {

        private Tuple<bool, bool> sidekickState;
        private bool FacingRight;
        public bool Following;
        private Player player;

        public SidekickStateMachine()
        {
        }

        public void Attack()
        {
            //Attack is random

        }

        public void Follow()
        {
            Following = true;
            FacingRight = player.FaceRight;

        }

        public Tuple<bool, bool> getState()
        {
            sidekickState = new Tuple<bool, bool>(Following, FacingRight);
            return sidekickState;
        }

        public void Stay()
        {
            Following = false;
            FacingRight = player.FaceRight;
        }
    }
}
