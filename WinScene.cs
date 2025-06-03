public class WinScene : IScene
{
    Font font = Engine.LoadFont("assets/arial.ttf", 30);

    public void Start() { }

    public void Update() { }

    public void Render()
    {
        Engine.DrawText("YOU WIN!", 450, 350, 0, 255, 0, font);
    }
}