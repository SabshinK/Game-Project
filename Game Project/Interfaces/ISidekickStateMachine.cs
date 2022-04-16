using System;

namespace Game_Project
{
    public interface ISidekickStateMachine
    {


        //This method is left in here in case we need it later. If it is not needed, take that boi out
        public void Follow();

        public void Stay();

        public void Attack();

        public Tuple<bool, bool, bool> getState(); // It's stay/follow, left/right
    }
}
