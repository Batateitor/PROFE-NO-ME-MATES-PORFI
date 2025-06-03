public class LoseScene : IScene
{
    Font font = Engine.LoadFont("assets/arial.ttf", 30);

    public void Start() { }

    public void Update() { }

    public void Render()
    {
        Engine.DrawText("YOU LOSE!", 450, 350, 255, 0, 0, font);
    }
}