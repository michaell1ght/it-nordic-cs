using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(1.5);

            Func<double, double> calculatePerimeter;
            Func<double, double> calculateRadius;
            calculatePerimeter = CalculatePerimeter;
            calculateRadius = CalculateRadius;
            Console.WriteLine(circle.Calculate(calculatePerimeter));
            Console.WriteLine(circle.Calculate(calculateRadius));

        }
        static double CalculatePerimeter(double radius)
        {
            return radius * 2 * Math.PI;
        }

        static double CalculateRadius(double radius)
        {
            return Math.PI * Math.Pow(radius,2);
        }
    }

    //Реализовать возможность вычисления периметра и площади окружности.
    //Создать экземпляр класса с радиусом = 1.5
    //Рассчитать периметр и площадь пользуясь методом Calculate() у созданного экземпляра класса.
    //Вывести на экран результат вычислений в формате:
    //            For the circle with radius 1.5
    //Perimeter is 9.42477796076938. Радиус * 2пи
    //Square is 7.06858347057703 пи * радиус ^3
    public sealed class Circle
    {
        private double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }
        public double Calculate(Func<double, double> operation)
        {
            return operation(_radius);
        }
    }
}
