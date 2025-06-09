public class EnemyRed : Enemy
{
    public EnemyRed(Image image) : base(image) { }

    protected override void RandomizeDirection()
    {
        base.RandomizeDirection();
        speed -= 20; // un poco más lento
    }
}
