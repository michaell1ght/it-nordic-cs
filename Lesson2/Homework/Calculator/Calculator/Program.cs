using System;
using static System.Math;
namespace DemoApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Аннотация:");
            Console.WriteLine($"Для ввода доступны значения не менее {float.MinValue} и не более {float.MaxValue}");
            Console.WriteLine("Числа с плавающей точкой можно вводить с разделителем \".\" или \",\" ");
            Console.WriteLine("Введите первое число");
            float firstOperand = float.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите второе число");
            float secondOperand = float.Parse(Console.ReadLine().Replace(".", ","));
            Console.WriteLine("Введите символ, соответствующий арифметической операции из списка:");
            Console.WriteLine("сложение: +");
            Console.WriteLine("вычитание: -");
            Console.WriteLine("деление: /");
            Console.WriteLine("умножение: *");
            Console.WriteLine("возведение в степень: ^");
            Console.WriteLine("остаток от деления : %");
            char mathOperationType = char.Parse(Console.ReadLine());
            switch (mathOperationType) {
                case '+':
                    float result = firstOperand + secondOperand;
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                case '*':
                    result = firstOperand * secondOperand;
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                case '/':
                    result = firstOperand / secondOperand;
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                case '^':
                    result = Convert.ToSingle(Math.Pow((double) firstOperand, (double) secondOperand));
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                case '%':
                    result = Convert.ToSingle((int) firstOperand % (int)secondOperand);
                    Console.WriteLine($"Результат = {result}");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
