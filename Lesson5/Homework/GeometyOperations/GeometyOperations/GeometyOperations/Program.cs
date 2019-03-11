using System;

namespace GeometyOperations
{
    [Flags]
    enum FigureTypes
    {
        Circle = 1,
        Triange = 2,
        Rectangle = 3

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            FigureTypes figure = new FigureTypes();
            int i = 0;
            figure = FigureTypes.Circle | FigureTypes.Rectangle | FigureTypes.Triange;
            Console.WriteLine("The figure list is:");
            for (i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1} , {(FigureTypes)Enum.GetValues(typeof(FigureTypes)).GetValue(i)}");
            }
            Console.WriteLine("Input the number of one figure from the list");
            try
            {
                uint figureNumber = uint.Parse(Console.ReadLine());
                if (figure.HasFlag((FigureTypes)figureNumber) && figureNumber!=0)
                {
                        switch (figureNumber)
                        {
                            case 1:
                                Console.WriteLine("Input figure diameter");
                                    double circleDiameter = double.Parse(Console.ReadLine());
                                    if (circleDiameter > 0)
                                    {
                                        try
                                        {
                                            Console.WriteLine($"Square = {Math.Round(Math.PI * Math.Pow((circleDiameter / 2), 2))}");
                                            Console.WriteLine($"Perimeter length = {Math.Round(2 * Math.PI * (circleDiameter / 2))}");
                                            Console.ReadKey();
                                        }
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine($"{e.GetType()} , {e.Message}");
                                            Console.ReadKey();
                                        }
                                        catch (OverflowException e)
                                        {
                                            Console.WriteLine($"{e.GetType()} , {e.Message}");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("parameter value must be more than zero");
                                        Console.ReadKey();
                                        throw new ArgumentOutOfRangeException();
                                    }
                                break;
                            case 2:
                                Console.WriteLine("Input figure side length");
                                    double triangleSideLength = double.Parse(Console.ReadLine());
                                    if (triangleSideLength > 0)
                                    {
                                        Console.WriteLine($"Square = {Math.Round((Math.Sqrt(3) / 4) * triangleSideLength)}");
                                        Console.WriteLine($"Perimeter length = {Math.Round(3 * triangleSideLength)}");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("parameter value must be more than zero");
                                        Console.ReadKey();
                                        throw new ArgumentOutOfRangeException();
                                    } 
                                break;
                            case 3:
                                Console.WriteLine($"Input figure width");
                                    double rectanglewidth = double.Parse(Console.ReadLine());
                                    if (rectanglewidth>0)
                                    {
                                        Console.WriteLine($"Input figure heith");
                                        double rectangleheith = double.Parse(Console.ReadLine());
                                        if (rectanglewidth > 0)
                                        {
                                            Console.WriteLine($"Square = {Math.Round(rectanglewidth * rectangleheith)}");
                                            Console.WriteLine($"Perimeter length = {Math.Round(2 * rectanglewidth * rectangleheith)}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("parameter value must be more than zero");
                                            Console.ReadKey();
                                            throw new ArgumentOutOfRangeException();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("parameter value must be more than zero");
                                        Console.ReadKey();
                                        throw new ArgumentOutOfRangeException();
                                    }
                                break;
                        }
                }
                else
                {
                    Console.WriteLine("The figure number must be 1, 2 or 3");
                    Console.ReadKey();
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.GetType()} , {e.Message}");
                Console.ReadKey();
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"{e.GetType()} , {e.Message}");
                Console.ReadKey();
            }
        }
    }
}
