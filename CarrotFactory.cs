using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    using System;
    using System.Collections.Generic;

    public class CarrotFactory
    {
        private Random rand = new Random();
        private List<Carrot> activeCarrots = new List<Carrot>();

        public List<Carrot> SpawnCarrots(int count, int screenWidth, int screenHeight, int size = 64)
        {
            List<Carrot> newCarrots = new List<Carrot>();

            for (int i = 0; i < count; i++)
            {
                CarrotType type = (CarrotType)rand.Next(0, 3);
                Carrot carrot = new Carrot(type);

                float x = rand.Next(0, screenWidth - size);
                float y = rand.Next(0, screenHeight - size);
                carrot.Transform.Position = new Vector2(x, y);

                newCarrots.Add(carrot);
            }

            activeCarrots.AddRange(newCarrots);
            return newCarrots;
        }

        public void Clear()
        {
            activeCarrots.Clear();
        }

        public List<Carrot> GetActiveCarrots() => activeCarrots;
    }

}
