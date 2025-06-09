using System;

public class Enemy : Entity, IPoolable
{
    protected float speed;
    protected float directionX, directionY;
    protected Random rand = new Random();
    private float lifetime; // Tiempo restante de vida en segundos

    public Enemy(Image image) : base(image, 64, 64)
    {
        ResetLifetime();
    }

    public void ResetLifetime()
    {
        lifetime = 15f; // 15 segundos
    }

    public override void Update(float deltaTime)
    {
        Transform.Position.X += directionX * speed * deltaTime;
        Transform.Position.Y += directionY * speed * deltaTime;

        if (Transform.Position.X < 0 || Transform.Position.X > 1024 - 64)
            directionX *= -1;
        if (Transform.Position.Y < 0 || Transform.Position.Y > 768 - 64)
            directionY *= -1;

        base.Update(deltaTime);

        lifetime -= deltaTime;
        if (lifetime <= 0)
        {
            GameManager.Instance.EnemyFactory.Despawn(this);
        }
    }

    protected virtual void RandomizeDirection()
    {
        directionX = (float)(rand.NextDouble() * 2 - 1);
        directionY = (float)(rand.NextDouble() * 2 - 1);
        float length = (float)Math.Sqrt(directionX * directionX + directionY * directionY);
        directionX /= length;
        directionY /= length;
        speed = 100 + (float)(rand.NextDouble() * 100);
    }

    public virtual void OnGetFromPool()
    {
        Transform.Position = GetRandomSpawnPositionAwayFromPlayer();
        RandomizeDirection();
        ResetLifetime();
    }

    public virtual void OnReturnToPool() { }

    protected Vector2 GetRandomSpawnPositionAwayFromPlayer()
    {
        Vector2 playerPos = GameManager.Instance.Player.Transform.Position;
        Vector2 pos;
        do
        {
            pos = new Vector2(rand.Next(0, 1024 - 64), rand.Next(0, 768 - 64));
        } while (Distance(pos, playerPos) < 150);
        return pos;
    }

    protected float Distance(Vector2 a, Vector2 b)
    {
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;
        return (float)Math.Sqrt(dx * dx + dy * dy);
    }
}
