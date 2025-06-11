using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Tao.Sdl;

class Program
{
    static float lastFrameTime;
    static DateTime startTime;

    static void Main(string[] args)
    {
        Engine.Initialize(1024, 768);
        GameManager.Instance.SetScene(new MainMenuScene());

        startTime = DateTime.Now;

        while (GameManager.Instance.IsRunning)
        {
            float currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            float deltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;

            Engine.Clear();

            if (GameManager.Instance.currentScene is MainMenuScene menu)
            {
                menu.Update();
                menu.Render();
            }
            else if (GameManager.Instance.currentScene is GameScene game)
            {
                game.Update(deltaTime);
                game.Render();
            }
            else if (GameManager.Instance.currentScene is WinScene win)
            {
                win.Update();
                win.Render();
            }
            else if (GameManager.Instance.currentScene is LoseScene lose)
            {
                lose.Update();
                lose.Render();
            }

            Engine.Show();
            Sdl.SDL_Delay(16);
        }
    }
}
