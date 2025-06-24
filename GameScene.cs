using System;
using System.Collections.Generic;
using MyGame;

public class GameScene : IScene
{
    Image playerImg = Engine.LoadImage("assets/player.png");
    Image ghostImg = Engine.LoadImage("assets/FantasmitaUwU.png");
    Image background = Engine.LoadImage("assets/bosquetenebrosoUUUUUU.png");

    float spawnTimer = 0;
    private List<Enemy> activeEnemies = new List<Enemy>();
    private Timer timer;
    private Font font = Engine.LoadFont("assets/arial.ttf", 24);

    public void Start()
    {
        Image imgWhite = Engine.LoadImage("assets/FantasmitaUwU.png");
        Image imgBlue = Engine.LoadImage("assets/FantasmitaUwUAzul.png");
        Image imgRed = Engine.LoadImage("assets/FantasmitaUwURojo.png");

        GameManager.Instance.EnemyFactory = new EnemyFactory(imgWhite, imgBlue, imgRed);

        GameManager.Instance.GameTime = 0;

        GameManager.Instance.Player = new Player(playerImg);
        GameManager.Instance.RegisterEntity(GameManager.Instance.Player);

        for (int i = 0; i < 2; i++)
            GameManager.Instance.EnemyFactory.Spawn();
        
        CarrotScore.Instance.ResetScore();

        GameManager.Instance.carrotFactory = new CarrotFactory();
        
        List<Carrot> carrots = GameManager.Instance.carrotFactory.SpawnCarrots(10, 1024, 768);
        foreach (var carrot in carrots)
        {
            GameManager.Instance.RegisterEntity(carrot);
            GameManager.Instance.Player.Collider.others.Add(carrot.Collider);
            carrot.Collider.others.Add(GameManager.Instance.Player.Collider);

            carrot.Collider.OnCollision += (c) =>
            {
                CarrotScore.Instance.AddScore(carrot.Points);
                GameManager.Instance.UnregisterEntity(carrot);
            };
        }


        foreach (var enemy in GameManager.Instance.EnemyFactory.GetType().GetField("activeEnemies", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(GameManager.Instance.EnemyFactory) as List<Enemy>)
        {
            GameManager.Instance.Player.Collider.others.Add(enemy.Collider);
            enemy.Collider.others.Add(GameManager.Instance.Player.Collider);

            enemy.Collider.OnCollision += (c) =>
            {
                GameManager.Instance.SetScene(new LoseScene());
            };
        }

        timer = new Timer(30f);
    }

    public void Update(float deltaTime)
    {
        spawnTimer += deltaTime;
        if (spawnTimer > 3)
        {
            GameManager.Instance.EnemyFactory.Spawn();
            spawnTimer = 0;
        }

        timer.Update(deltaTime);
        GameManager.Instance.Update(deltaTime);

        if (timer.IsComplete())
        {
            GameManager.Instance.SetScene(new WinScene());
        }
    }

    public void Render()
    {
        Engine.Draw(background, 0, 0);
        GameManager.Instance.Draw();

        int x = 254 - 10 - 220;
        int y = 10;
        timer.Draw(x, y);

        CarrotScore.Instance.Draw();

    }
}