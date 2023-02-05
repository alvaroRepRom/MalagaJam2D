namespace Enemy
{
    public abstract class EnemyState
    {
        public abstract void Execute(EnemyManager enemyManager);
        public abstract void OnStateEnter(EnemyManager enemyManager);

        public abstract void ChangeSprite(EnemyManager enemyManager);
    }
}
