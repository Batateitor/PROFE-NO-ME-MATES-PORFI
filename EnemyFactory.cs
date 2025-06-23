using System;
using System.Collections.Generic;

public class EnemyFactory
{
    private ObjectPool<Enemy> poolWhite;
    private ObjectPool<EnemyBlue> poolBlue;
    private ObjectPool<EnemyRed> poolRed;

    private Image imgWhite;
    private Image imgBlue;
    private Image imgRed;

    private List<Enemy> activeEnemies = new List<Enemy>();

    private Random rand = new Random();

    public EnemyFactory(Image white, Image blue, Image red)
    {
        imgWhite = white;
        imgBlue = blue;
        imgRed = red;

        poolWhite = new ObjectPool<Enemy>(() => new Enemy(imgWhite));
        poolBlue = new ObjectPool<EnemyBlue>(() => new EnemyBlue(imgBlue));
        poolRed = new ObjectPool<EnemyRed>(() => new EnemyRed(imgRed));

    }

    public void Spawn()
    {
        int type = rand.Next(0, 3);
        Enemy enemy = null;

        switch (type)
        {
            case 0: enemy = poolWhite.Get(); break;
            case 1: enemy = poolBlue.Get(); break;
            case 2: enemy = poolRed.Get(); break;
        }

        enemy.ResetLifetime();

        activeEnemies.Add(enemy);
        GameManager.Instance.RegisterEntity(enemy);

        enemy.Collider.others.Add(GameManager.Instance.Player.Collider);
        GameManager.Instance.Player.Collider.others.Add(enemy.Collider);

        enemy.Collider.OnCollision += (c) =>
        {
            GameManager.Instance.SetScene(new LoseScene());
        };
    }

    public void DespawnAll()
    {
        foreach (var e in activeEnemies)
        {
            GameManager.Instance.UnregisterEntity(e);
            if (e is EnemyRed red)
                poolRed.Return(red);
            else if (e is EnemyBlue blue)
                poolBlue.Return(blue);
            else if (e is Enemy white)
                poolWhite.Return(white);
        }
        activeEnemies.Clear();
    }

    public void Despawn(Enemy enemy)
    {
        GameManager.Instance.UnregisterEntity(enemy);
        activeEnemies.Remove(enemy);

        if (enemy is EnemyRed red)
            poolRed.Return(red);
        else if (enemy is EnemyBlue blue)
            poolBlue.Return(blue);
        else
            poolWhite.Return(enemy);
    }
}
