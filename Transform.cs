public class Transform
{
    public Vector2 Position;
    public float Rotation;
    public Vector2 Scale;

    public Transform()
    {
        Position = new Vector2(0, 0);
        Rotation = 0;
        Scale = new Vector2(1, 1);
    }
}
