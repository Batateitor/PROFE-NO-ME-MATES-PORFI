using System;
using System.Collections.Generic;
using MyGame;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance => instance ?? (instance = new GameManager());

    public Player Player;
    public EnemyFactory EnemyFactory;
    public CarrotFactory carrotFactory;
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

    public void RegisterCarrots(List<Carrot> carrots)
    {
        foreach (var carrot in carrots)
        {
            updatables.Add(carrot);
            drawables.Add(carrot);
        }
    }

    public void UnregisterCarrots(List<Carrot> carrots)
    {
        foreach (var carrot in carrots)
        {
            updatables.Remove(carrot);
            drawables.Remove(carrot);
        }
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

        var updatablesCopy = new List<IUpdatable>(updatables);

        foreach (var u in updatablesCopy)
            u.Update(deltaTime);
    }

    public void Draw()
    {
        foreach (var d in drawables)
            d.Draw();
    }
}
