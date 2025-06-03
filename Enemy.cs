using System;

public class Enemy : Entity, IPoolable
{
    private float speed;
    private float directionX, directionY;
    private Random rand = new Random();

    public Enemy(Image image) : base(image, 64, 64)
    {
        RandomizeDirection();
    }

    public override void Update(float deltaTime)
    {
        Transform.Position.X += directionX * speed * deltaTime;
        Transform.Position.Y += directionY * speed * deltaTime;

        // Rebote en los bordes
        if (Transform.Position.X < 0 || Transform.Position.X > 1024 - 64)
            directionX *= -1;
        if (Transform.Position.Y < 0 || Transform.Position.Y > 768 - 64)
            directionY *= -1;

        base.Update(deltaTime);
    }

    private void RandomizeDirection()
    {
        directionX = (float)(rand.NextDouble() * 2 - 1); // Entre -1 y 1
        directionY = (float)(rand.NextDouble() * 2 - 1);
        float length = (float)Math.Sqrt(directionX * directionX + directionY * directionY);
        directionX /= length;
        directionY /= length;
        speed = 100 + (float)(rand.NextDouble() * 100); // Entre 100 y 200
    }

    public void OnGetFromPool()
    {
        Transform.Position = new Vector2(rand.Next(0, 960), rand.Next(0, 704));
        RandomizeDirection();
    }

    public void OnReturnToPool()
    {
        // No necesita limpieza por ahora
    }
}
