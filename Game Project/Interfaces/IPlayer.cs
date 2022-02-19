namespace Game_Project
{
    public interface IPlayer
    {
        public void BackToIdleRight();
        public void BackToIdleLeft();
        public void Update(); //both move left and moveRight would need to implement this. 
    }
}
