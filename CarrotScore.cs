using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class CarrotScore
    {
        private Font font = Engine.LoadFont("assets/arial.ttf", 30);

        private static CarrotScore instance;
        public static CarrotScore Instance
        {
            get
            {
                if (instance == null)
                    instance = new CarrotScore();
                return instance;
            }
        }


        private int score = 0;
        private int highScore = 0;

        public void ResetScore() => score = 0;

        public void AddScore(int points)
        {
            score += points;
            if (score > highScore)
                highScore = score;
        }

        public int Score => score;
        public int HighScore => highScore;

        public void Draw()
        {
            Engine.DrawText($"Score: {score}", 800, 10, 255, 255, 0, font);
        }

        public void DrawFinal()
        {
            Engine.DrawText($"Final Score: {score}", 450, 300, 255, 255, 0, font);
            Engine.DrawText($"High Score: {highScore}", 450, 340, 0, 255, 0, font);
        }

    }

}
