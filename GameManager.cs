using System;
using System.Collections.Generic;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance => instance ?? (instance = new GameManager());

    public Player Player;
    public EnemyFactory EnemyFactory;
    public List<IUpdatable> updatables = new List<IUpdatable>();
    public List<IDrawable> drawables = new List<IDrawable>();
    public IScene currentScene;
    public bool IsRunning = true;
    public float GameTime;

    private GameManager() { }

    public void RegisterEntity(Entity entity)
    {
        updatables.Add(entity);
        drawables.Add(entity);
    }

    public void UnregisterEntity(Entity entity)
    {
        updatables.Remove(entity);
        drawables.Remove(entity);
    }

    public void SetScene(IScene scene)
    {
        updatables.Clear();
        drawables.Clear();
        currentScene = scene;
        scene.Start();
    }

    public void Update(float deltaTime)
    {
        GameTime += deltaTime;

        foreach (var u in updatables)
            u.Update(deltaTime);
    }

    public void Draw()
    {
        foreach (var d in drawables)
            d.Draw();
    }
}
