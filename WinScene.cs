﻿using MyGame;
using System;

public class WinScene : IScene
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
        Engine.DrawText("YOU WIN!", 450, 250, 0, 255, 0, font);
        Engine.DrawText("M: Menu   SPACE: Retry", 400, 400, 255, 255, 255, font);
        CarrotScore.Instance.DrawFinal();
    }
}