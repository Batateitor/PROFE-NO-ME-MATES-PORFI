using System;
using System.Collections.Generic;

public class GameScene : IScene
{
    Image playerImg = Engine.LoadImage("assets/player.png");
    Image ghostImg = Engine.LoadImage("assets/FantasmitaUwU.png");
    Image background = Engine.LoadImage("assets/bosquetenebrosoUUUUUU.png");

    float spawnTimer = 0;

    public void Start()
    {
        GameManager.Instance.GameTime = 0;

        GameManager.Instance.Player = new Player(playerImg);
        GameManager.Instance.RegisterEntity(GameManager.Instance.Player);

        GameManager.Instance.EnemyFactory = new EnemyFactory(ghostImg);

        for (int i = 0; i < 5; i++)
            GameManager.Instance.EnemyFactory.Spawn();

        // Conectar colisiones
        foreach (var enemy in GameManager.Instance.EnemyFactory.GetType().GetField("activeEnemies", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(GameManager.Instance.EnemyFactory) as List<Enemy>)
        {
            GameManager.Instance.Player.Collider.others.Add(enemy.Collider);
            enemy.Collider.others.Add(GameManager.Instance.Player.Collider);

            enemy.Collider.OnCollision += (c) =>
            {
                GameManager.Instance.SetScene(new LoseScene());
            };
        }
    }

    public void Update(float deltaTime)
    {
        spawnTimer += deltaTime;
        if (spawnTimer > 3)
        {
            GameManager.Instance.EnemyFactory.Spawn();
            spawnTimer = 0;
        }

        GameManager.Instance.Update(deltaTime);

        if (GameManager.Instance.GameTime >= 30f)
            GameManager.Instance.SetScene(new WinScene());
    }

    public void Render()
    {
        Engine.Draw(background, 0, 0);
        GameManager.Instance.Draw();
    }
}

