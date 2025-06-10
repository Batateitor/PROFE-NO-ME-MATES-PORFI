using System;

namespace MyGame
{
    public class Timer
    {
        private float duration;
        private float elapsedTime;
        private Font font;

        public Timer(float duration)
        {
            this.duration = duration;
            this.elapsedTime = 0f;
            this.font = new Font("assets/arial.ttf", 16);
        }

        public void Update(float deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime > duration)
                elapsedTime = duration;
        }

        public bool IsComplete()
        {
            return elapsedTime >= duration;
        }

        public void Draw(int x, int y)
        {
            float timeLeft = Math.Max(0, duration - elapsedTime);
            string text = $"Tiempo restante: {timeLeft:0.0}s";
            byte r = 255, g = 255, b = 255;
            Engine.DrawText(text, x, y, r, g, b, font);
        }
    }
}
