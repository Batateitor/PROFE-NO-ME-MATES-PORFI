public class Renderer
{
    private Image image;
    private Transform transform;
    private int width, height;

    public Renderer(Image image, Transform transform, int width, int height)
    {
        this.image = image;
        this.transform = transform;
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        Engine.Draw(image, transform.Position.X, transform.Position.Y, width, height);
    }
}
