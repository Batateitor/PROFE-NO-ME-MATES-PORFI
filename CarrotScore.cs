using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class CarrotScore
    {
        private static CarrotScore _instance;
        private int _score;

        private CarrotScore() { }

        public static CarrotScore Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CarrotScore();
                return _instance;
            }
        }

        public int Score => _score;

        public void AddScore(int value)
        {
            _score += value;
        }

        public void ResetScore()
        {
            _score = 0;
        }

        public void DrawScore()
        {
            int score = this.Score;
            Console.SetCursorPosition(0, 0);
            Console.Write($"Puntaje: {score}");
        }

    }
}
