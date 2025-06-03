using System;
using Tao.Sdl;

public class Player : Entity
{
    private float speed = 200;

    public Player(Image image) : base(image, 64, 64)
    {
        Transform.Position = new Vector2(480, 360); // Centro de la pantalla
    }

    public override void Update(float deltaTime)
    {
        float dx = 0, dy = 0;
        if (Engine.GetKey(Engine.KEY_W)) dy -= 1;
        if (Engine.GetKey(Engine.KEY_S)) dy += 1;
        if (Engine.GetKey(Engine.KEY_A)) dx -= 1;
        if (Engine.GetKey(Engine.KEY_D)) dx += 1;

        Transform.Position.X += dx * speed * deltaTime;
        Transform.Position.Y += dy * speed * deltaTime;

        // Mantener dentro de pantalla
        Transform.Position.X = Math.Max(0, Math.Min(Transform.Position.X, 1024 - 64));
        Transform.Position.Y = Math.Max(0, Math.Min(Transform.Position.Y, 768 - 64));

        base.Update(deltaTime);
    }
}
