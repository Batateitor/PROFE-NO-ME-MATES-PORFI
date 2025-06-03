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
    }

    public void Update()
    {
        if (Engine.GetKey(Engine.KEY_ESP))
        {
            GameManager.Instance.SetScene(new GameScene());
        }
    }
}
