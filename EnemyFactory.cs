using System.Collections.Generic;

public class EnemyFactory
{
    private ObjectPool<Enemy> pool;
    private Image enemyImage;
    private List<Enemy> activeEnemies;

    public EnemyFactory(Image image)
    {
        enemyImage = image;
        pool = new ObjectPool<Enemy>(() => new Enemy(enemyImage));
        activeEnemies = new List<Enemy>();
    }

    public void Spawn()
    {
        var enemy = pool.Get();
        activeEnemies.Add(enemy);
        GameManager.Instance.RegisterEntity(enemy);

        // Conectar colisiones con el jugador
        var player = GameManager.Instance.Player;
        if (player != null)
        {
            player.Collider.others.Add(enemy.Collider);
            enemy.Collider.others.Add(player.Collider);

            enemy.Collider.OnCollision += (c) =>
            {
                GameManager.Instance.SetScene(new LoseScene());
            };
        }
    }

    public void DespawnAll()
    {
        foreach (var e in activeEnemies)
        {
            GameManager.Instance.UnregisterEntity(e);
            pool.Return(e);
        }
        activeEnemies.Clear();
    }
}
