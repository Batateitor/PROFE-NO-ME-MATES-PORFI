using System;
using System.Collections.Generic;
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
            // Inicializa el pool con zanahorias de diferentes tipos
            for (int i = 0; i < poolSize; i++)
            {
                _pool.Enqueue(GetRandomType());
            }
        }

        private CarrotType GetRandomType()
        {
            // Lógica para obtener un tipo aleatorio
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

        // Nuevo método para generar zanahorias en posiciones aleatorias
        public List<Carrot> SpawnCarrots(int count, int screenWidth, int screenHeight, int carrotSize = 64)
        {
            var carrots = new List<Carrot>();
            for (int i = 0; i < count; i++)
            {
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
