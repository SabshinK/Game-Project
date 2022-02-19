namespace Game_Project
{
    public interface IEnemy
    {
        public void ChangeDirection();

        public void Attack();

        public void TakeDamage();

        public void Draw();
    }
}
