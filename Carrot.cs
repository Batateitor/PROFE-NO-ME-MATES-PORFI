using MyGame;

public class Carrot : Entity
{
    public CarrotType Type { get; }
    public int Points { get; }
    public string ImagePath { get; }

    public Carrot(CarrotType type)
        : base(new Image(GetImagePath(type)), 64, 64)
    {
        this.Type = type;
        Points = GetPoints(type);
        ImagePath = GetImagePath(type);
    }

    private static string GetImagePath(CarrotType type)
    {
        switch (type)
        {
            case CarrotType.Rare:
                return "assets/carrot_rare.png";
            case CarrotType.Epic:
                return "assets/carrot_epic.png";
            default:
                return "assets/carrot_common.png";
        }
    }

    private int GetPoints(CarrotType type)
    {
        switch (type)
        {
            case CarrotType.Rare:
                return 10;
            case CarrotType.Epic:
                return 20;
            default:
                return 5;
        }
    }
}