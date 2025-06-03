using System;
using System.Collections.Generic;

public class Collider
{
    public event Action<Collider> OnCollision;

    public Transform Transform { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public List<Collider> others;

    public Collider(Transform transform, int width, int height)
    {
        this.Transform = transform;
        this.Width = width;
        this.Height = height;
        others = new List<Collider>();
    }

    public void CheckCollisions()
    {
        foreach (var other in others)
        {
            if (IsCollidingWith(other))
            {
                OnCollision?.Invoke(other);
            }
        }
    }

    private bool IsCollidingWith(Collider other)
    {
        return !(Transform.Position.X + Width < other.Transform.Position.X ||
                 Transform.Position.X > other.Transform.Position.X + other.Width ||
                 Transform.Position.Y + Height < other.Transform.Position.Y ||
                 Transform.Position.Y > other.Transform.Position.Y + other.Height);
    }
}
