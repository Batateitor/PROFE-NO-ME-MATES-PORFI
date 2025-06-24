using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Carrot : Entity, IPoolable
    {
        public CarrotType Type { get; private set; }
        public int Points => Type.GetScoreValue();

        public Carrot(CarrotType type) : base(new Image(type.GetImagePath()), 64, 64)
        {
            Type = type;
            Console.WriteLine(type.GetImagePath());
        }

        public void OnGetFromPool()
        {

        }

        public void OnReturnToPool()
        {

        }
    }

}
