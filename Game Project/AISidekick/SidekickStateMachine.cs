using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Project
{
    public class SidekickStateMachine : ISidekickStateMachine
    {

        private Tuple<bool, bool, bool> sidekickState;
        private bool FacingRight;
        public bool Following;
        public bool Attacking;
        private Player player;

        public SidekickStateMachine(Player manager)
        {
            player = manager;
        }

        public void Attack()
        {
            Attacking = true;
        }

        public void Follow()
        {
            Following = true;
            FacingRight = player.FacingRight;

        }

        public Tuple<bool, bool, bool> getState()
        {
            sidekickState = new Tuple<bool, bool, bool>(Following, Attacking, FacingRight);
            return sidekickState;
        }

        public void Stay()
        {
            Following = false;
            FacingRight = player.FacingRight;
        }
    }
}
