public abstract class Entity : IUpdatable, IDrawable
{
    public Transform Transform { get; protected set; }
    public Renderer Renderer { get; protected set; }
    public Collider Collider { get; protected set; }

    public Entity(Image image, int width, int height)
    {
        Transform = new Transform();
        Renderer = new Renderer(image, Transform, width, height);
        Collider = new Collider(Transform, width, height);
    }

    public virtual void Update(float deltaTime)
    {
        Collider?.CheckCollisions();
    }

    public virtual void Draw()
    {
        Renderer?.Draw();
    }
}
