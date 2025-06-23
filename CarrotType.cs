using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                case CarrotType.Common: return 100;
                case CarrotType.Rare: return 200;
                case CarrotType.Epic: return 500;
                default: return 0;
            }
        }

        public static string GetImagePath(this CarrotType type)
        {
            switch (type)
            {
                case CarrotType.Common: return "assets/carrot_common.png";
                case CarrotType.Rare: return "assets/carrot_rare.png";
                case CarrotType.Epic: return "assets/carrot_epic.png";
                default: return "";
            }
        }
    }

}
