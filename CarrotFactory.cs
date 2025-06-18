using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame;

namespace MyGame
{
    public class CarrotFactory
    {
        private readonly Random _random = new Random();
        private readonly Queue<CarrotType> _pool = new Queue<CarrotType>();

        public CarrotFactory(int poolSize = 20)
        {
            for (int i = 0; i < poolSize; i++)
            {
                _pool.Enqueue(GetRandomType());
            }
        }

        private CarrotType GetRandomType()
        {
            return (CarrotType)_random.Next(0, 3);
        }

        public CarrotType GetCarrot()
        {
            if (_pool.Count > 0)
                return _pool.Dequeue();
            return GetRandomType();
        }

        public void ReturnCarrot(CarrotType carrot)
        {
            _pool.Enqueue(carrot);
        }

        public List<Carrot> SpawnCarrots(int count, int screenWidth, int screenHeight, int carrotSize = 64)
        {
            if (screenWidth <= carrotSize || screenHeight <= carrotSize)
                throw new ArgumentException("El tamaño de pantalla debe ser mayor que el tamaño de la zanahoria.");

            var carrots = new List<Carrot>();
            for (int i = 0; i < count; i++)
            {
                Debug.Print($"Spawning carrot {i + 1}/{count}");
                var type = GetCarrot();
                var carrot = new Carrot(type);
                float x = _random.Next(0, screenWidth - carrotSize);
                float y = _random.Next(0, screenHeight - carrotSize);
                carrot.Transform.Position = new Vector2(x, y);
                carrots.Add(carrot);
            }
            return carrots;
        }
    }
}
   
