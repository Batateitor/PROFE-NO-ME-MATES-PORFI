public class EnemyBlue : Enemy
{
    public EnemyBlue(Image image) : base(image) { }

    protected override void RandomizeDirection()
    {
        base.RandomizeDirection();
        speed *= 2;
    }
}
