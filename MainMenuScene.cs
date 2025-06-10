public class MainMenuScene : IScene
{
    Font font = Engine.LoadFont("assets/arial.ttf", 30);

    public void Start()
    {
        GameManager.Instance.updatables.Clear();
        GameManager.Instance.drawables.Clear();
    }

    public void Render()
    {
        Engine.DrawText("Press SPACE to start", 350, 350, 255, 255, 255, font);
        Engine.DrawText("Controls:", 350, 400, 255, 255, 0, font);
        Engine.DrawText("Arrows: Move Player", 350, 440, 255, 255, 255, font);
        Engine.DrawText("L: Dash", 350, 480, 255, 255, 255, font);
    }

    public void Update()
    {
        if (Engine.GetKey(Engine.KEY_ESP))
        {
            GameManager.Instance.SetScene(new GameScene());
        }
    }
}
