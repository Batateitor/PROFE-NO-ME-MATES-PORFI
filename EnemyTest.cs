using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;
using System;

namespace MyGame.Tests
{
    [TestClass]
    public class EnemyTests
    {
        private Player dummyPlayer;

        [TestInitialize]
        public void Setup()
        {
            dummyPlayer = new Player(Engine.LoadImage("assets/player.png"));
            dummyPlayer.Transform.Position = new Vector2(512, 384);
            GameManager.Instance.Player = dummyPlayer;
        }

        [TestMethod]
        public void Enemy_Direction_Is_Normalized()
        {
            // Arrange
            var enemy = new Enemy(Engine.LoadImage("assets/ghost.png"));

            // Act
            enemy.OnGetFromPool();
            float dx = GetPrivateField<float>(enemy, "directionX");
            float dy = GetPrivateField<float>(enemy, "directionY");
            double length = Math.Sqrt(dx * dx + dy * dy);

            // Assert: longitud ≈ 1
            Assert.IsTrue(Math.Abs(length - 1.0) < 1e-5, "La dirección del enemigo no está normalizada");
        }

        [TestMethod]
        public void Enemy_Spawn_Away_From_Player()
        {
            // Arrange
            var enemy = new Enemy(Engine.LoadImage("assets/ghost.png"));

            // Act
            enemy.OnGetFromPool();
            var spawnPos = enemy.Transform.Position;
            var playerPos = dummyPlayer.Transform.Position;
            double dist = Math.Sqrt(
                Math.Pow(spawnPos.X - playerPos.X, 2) +
                Math.Pow(spawnPos.Y - playerPos.Y, 2)
            );

            Assert.IsTrue(dist >= 150.0, "El enemigo apareció demasiado cerca del jugador");
        }

        private T GetPrivateField<T>(object obj, string fieldName)
        {
            var fi = obj.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return (T)fi.GetValue(obj);
        }
    }
}
