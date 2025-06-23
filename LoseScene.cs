using MyGame;
using System;

public class LoseScene : IScene
{
    Font font = Engine.LoadFont("assets/arial.ttf", 30);

    public void Start() 
    {

    }

    public void Update()
    {
        if (Engine.GetKey(Engine.KEY_M))
        {
            GameManager.Instance.SetScene(new MainMenuScene());
        }
        else if (Engine.GetKey(Engine.KEY_ESP))
        {
            GameManager.Instance.SetScene(new GameScene());
        }
    }

    public void Render()
    {
        Engine.DrawText("YOU LOSE!", 450, 350, 255, 0, 0, font);
        Engine.DrawText("M: Menu   SPACE: Retry", 350, 400, 255, 255, 255, font);
        CarrotScore.Instance.DrawFinal(font);

    }
}