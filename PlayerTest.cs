using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace MyGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;
        private const float Delta = 0.016f;

        [TestInitialize]
        public void Setup()
        {
            player = new Player(Engine.LoadImage("assets/player.png"));
            GameManager.Instance.Player = player;
        }

        [TestMethod]
        public void Player_Does_Not_Exceed_Screen_Bounds()
        {
            // Colocamos al jugador fuera de límites y llamamos Update
            player.Transform.Position = new Vector2(-100, -100);
            player.Update(Delta);
            Assert.IsTrue(player.Transform.Position.X >= 0, "X menor que 0");
            Assert.IsTrue(player.Transform.Position.Y >= 0, "Y menor que 0");

            player.Transform.Position = new Vector2(2000, 2000);
            player.Update(Delta);
            Assert.IsTrue(player.Transform.Position.X <= 1024 - 64, "X mayor que ancho permitido");
            Assert.IsTrue(player.Transform.Position.Y <= 768 - 64, "Y mayor que alto permitido");
        }

        [TestMethod]
        public void Player_Movement_Applies_DeltaTime_And_Speed()
        {
            EngineDebug.SetKeyState(Engine.KEY_D, true);

            var startX = player.Transform.Position.X;
            player.Update(1.0f);
            var expected = startX + 200f * 1.0f;
            Assert.AreEqual(expected, player.Transform.Position.X, 1e-5, "Movimiento en X incorrecto");

            EngineDebug.SetKeyState(Engine.KEY_D, false);
        }
    }

    public static class EngineDebug
    {
        private static readonly System.Collections.Generic.Dictionary<int, bool> keyStates = new System.Collections.Generic.Dictionary<int, bool>();

        public static void SetKeyState(int key, bool pressed)
        {
            keyStates[key] = pressed;
        }

        public static bool GetKey(int c)
        {
            return keyStates.ContainsKey(c) && keyStates[c];
        }
    }
}
