using System;
using Tao.Sdl;
using MyGame;

namespace MyGame
{
    public class Player : Entity
    {
        private float speed = 200;
        private float dashSpeed = 600f;
        private float dashDuration = 0.2f;  
        private float dashCooldown = 1.0f; 
        private float dashTimeLeft = 0f;
        private float dashCooldownLeft = 0f;
        private float moveX, moveY;
        private bool isDashing = false;

        public int Score { get; private set; }

        public Player(Image image) : base(image, 64, 64)
        {
            Transform.Position = new Vector2(480, 360); // Centro de la pantalla  
        }

        public override void Update(float deltaTime)
        {
            moveX = 0;
            moveY = 0;

            if (Engine.GetKey(Engine.KEY_W)) moveY -= 1;
            if (Engine.GetKey(Engine.KEY_S)) moveY += 1;
            if (Engine.GetKey(Engine.KEY_A)) moveX -= 1;
            if (Engine.GetKey(Engine.KEY_D)) moveX += 1;

            // Normaliza el vector de movimiento  
            float length = (float)Math.Sqrt(moveX * moveX + moveY * moveY);
            if (length > 0)
            {
                moveX /= length;
                moveY /= length;
            }

            // Dash  
            if (!isDashing && dashCooldownLeft <= 0 && Engine.GetKey(Engine.KEY_L))
            {
                if (!isDashing && dashCooldownLeft <= 0 && Engine.GetKey(Engine.KEY_L))
                isDashing = true;
                dashTimeLeft = dashDuration;
                dashCooldownLeft = dashCooldown;
            }

            float currentSpeed = isDashing ? dashSpeed : speed;

            Transform.Position.X += moveX * currentSpeed * deltaTime;
            Transform.Position.Y += moveY * currentSpeed * deltaTime;

            if (isDashing)
            {
                dashTimeLeft -= deltaTime;
                if (dashTimeLeft <= 0)
                {
                    isDashing = false;
                }
            }
            else if (dashCooldownLeft > 0)
            {
                dashCooldownLeft -= deltaTime;
            }

            // Mantener dentro de pantalla  
            Transform.Position.X = Math.Max(0, Math.Min(Transform.Position.X, 1024 - 64));
            Transform.Position.Y = Math.Max(0, Math.Min(Transform.Position.Y, 768 - 64));

            base.Update(deltaTime);
        }

        public void CollectCarrot(CarrotType carrot, CarrotFactory factory)
        {
            int carrotValue = carrot.GetScoreValue();
            Score += carrotValue;
            factory.ReturnCarrot(carrot);
        }

        private void OnCarrotCollision(CarrotType carrot, CarrotFactory factory)
        {
            int carrotValue = carrot.GetScoreValue();
            CarrotScore.Instance.AddScore(carrotValue);

            factory.ReturnCarrot(carrot);
        }
    }
}
