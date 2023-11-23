using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    public abstract class Shape //класс Shape - родительский класс, ниже будут классы наследники, такие как Circle и Triangle
    {
        public string FigureName { get; set; }

        public Shape(string FigureName)
        {
            this.FigureName = FigureName;
        }

        public abstract double CalcSquare(); // абстрактный метод для расчёта площадей разных фигур
    }

    public static class ShapePrototype
    {
        public static double CalcSquare(Shape shape) => shape.CalcSquare();
    }

    public class Circle : Shape
    {
        public double R { get; set; } //R - радиус

        public Circle(string FigureName, double R) : base(FigureName)
        {
            this.R = R;
        }

        public override double CalcSquare()
        {
            return Math.Round(Math.PI * Math.Pow(R, 2), 1); //нахождение площади круга с округлением до 1 знака после запятой
        }
    }

    public class Triangle : Shape
    {
        public double ab { get; set; }
        public double bc { get; set; }
        public double ac { get; set; }

        public Triangle(string FigureName, double ab, double bc, double ac) : base(FigureName)
        {
            if (ab < 0 || bc < 0 || ac < 0) 
                throw new ArgumentException($"Error: Side can not be less than 0\nCheck your input values"); //Проверка на правильность сторон треугольника
            else if (ab > (bc + ac) || bc > (ab + ac) || ac > (ab + bc)) 
                throw new ArgumentException($"Error: Your side greater than summary of two another sides\nCheck your input values");
            else
            {
                this.ab = ab;
                this.bc = bc;
                this.ac = ac;
            }
        }

        public override double CalcSquare() //расчёт площади треугольника через полупериметр и округление значения до одного знака после запятой
        {
            double p = (ab + bc + ac) / 2;
            double result = Math.Round(Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac)), 1);
            return result;
        }

        public bool IsRectangular() //проверка на прямоугольность треугольника
        {
            bool check = (ab == Math.Sqrt(Math.Pow(bc, 2) + Math.Pow(ac, 2))
                         || bc == Math.Sqrt(Math.Pow(ab, 2) + Math.Pow(ac, 2))
                         || ac == Math.Sqrt(Math.Pow(ab, 2) + Math.Pow(bc, 2)));
            return check;
        }
    }
}