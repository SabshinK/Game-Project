using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class SidekickStateMachine :ISidekickStateMachine
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
            FacingRight = player.FacingRight;

        }

        public Tuple<bool, bool> getState()
        {
            sidekickState = new Tuple<bool, bool>(Following, FacingRight);
            return sidekickState;
        }

        public void Stay()
        {
            Following = false;
            FacingRight = player.FacingRight;
        }
    }
}
