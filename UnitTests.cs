using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testovoe.UnitTests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void SquareCircleTest()
        {
            //Задаём значения для проверки правильности расчётов при помощи формулы
            Circle circle = new Circle("Circle", 351);
            double expected = 387047.3;
            
            //Проверяем с помощью метода CalcSquare
            double result = circle.CalcSquare();

            //Сравнение ожиданий и результата
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void SquareTriangleTest()
        {
            //Задаём значения для проверки правильности расчётов при помощи формул
            Triangle triangle = new Triangle("Triangle", 4, 4, 5);
            double expected = 7.8;

            //Проверяем с помощью метода CalcSquare
            double result = triangle.CalcSquare();

            //Сравнение ожиданий и результата
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RectangleTriangleOrNot()
        {
            //Задаём значения для проверки правильности расчётов при помощи формул
            var triangle = new Triangle("Triangle", 2, 3, 4);

            //Проверяем с помощью метода CalcSquare
            var result = triangle.IsRectangular();

            //Сравнение ожиданий и результата
            Assert.IsFalse(result);
        }
    }
}
