namespace MyGame
{
    public enum CarrotType
    {
        Common = 0,
        Rare = 1,
        Epic = 2
    }

    public static class CarrotTypeExtensions
    {
        public static int GetScoreValue(this CarrotType type)
        {
            switch (type)
            {
                case CarrotType.Common:
                    return 100;
                case CarrotType.Rare:
                    return 200;
                case CarrotType.Epic:
                    return 500;
                default:
                    return 0;
            }
        }
    }

    public class Carrot
    {
        public CarrotType Type { get; }
        public int Points { get; }
        public string ImagePath { get; }
        public Transform Transform { get; internal set; }

        public Carrot(CarrotType type)
        {
            Type = type;
            Points = type.GetScoreValue();
            ImagePath = GetImagePath(type);
        }

        private string GetImagePath(CarrotType type)
        {
            switch (type)
            {
                case CarrotType.Common:
                    return "assets/carrot_common.png";
                case CarrotType.Rare:
                    return "assets/carrot_rare.png";
                case CarrotType.Epic:
                    return "assets/carrot_epic.png";
                default:
                    return string.Empty;
            }
        }
    }
}