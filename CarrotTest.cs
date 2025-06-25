using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGame;

namespace MyGame.Tests
{
    [TestClass]
    public class CarrotTests
    {
        [DataTestMethod]
        [DataRow(CarrotType.Common, 100, "assets/carrot_common.png")]
        [DataRow(CarrotType.Rare, 200, "assets/carrot_rare.png")]
        [DataRow(CarrotType.Epic, 500, "assets/carrot_epic.png")]
        public void Carrot_Type_Assigns_Points_And_ImagePath(CarrotType type, int expectedPoints, string expectedPath)
        {
            var carrot = new Carrot(type);

            Assert.AreEqual(expectedPoints, carrot.Points, $"Los puntos no coinciden para el tipo {type}");
            Assert.AreEqual(expectedPath, carrot.ImagePath, $"La ruta de imagen no coincide para el tipo {type}");
        }
    }
}
