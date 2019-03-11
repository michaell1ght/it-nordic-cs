using System;

namespace ColorCollection
{
    [Flags]
    enum ColorCollection
    {
        Empty = 0,
        Black = 1,
        Blue = 2,
        Cyan = 4,
        Grey = 8,
        Green = 16,
        Magenta = 32,
        Red = 64,
        White = 128,
        Yellow = 256
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            int i = 0;
            ColorCollection favouriteColorList = new ColorCollection();
            ColorCollection allColorList = new ColorCollection();
            allColorList = ColorCollection.Black | ColorCollection.Blue | ColorCollection.Cyan | ColorCollection.Green
                | ColorCollection.Grey | ColorCollection.Magenta | ColorCollection.Red | ColorCollection.White
                | ColorCollection.Yellow;
            Console.WriteLine("The members of the ColorCollection are:");
            foreach (string colorFromCollection in Enum.GetNames(typeof(ColorCollection)))
                if (colorFromCollection != "Empty")
                {
                    Console.WriteLine(colorFromCollection);
                }
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine($"Input color number {i + 1} from ColorCollection");
                string inputColor = Console.ReadLine().ToLower();
                inputColor = inputColor.Substring(0, 1).ToUpper() + inputColor.Remove(0, 1);
                Console.WriteLine(inputColor);
                switch (inputColor)
                {
                    case "Black":
                        favouriteColorList = favouriteColorList | ColorCollection.Black;
                        break;
                    case "Blue":
                        favouriteColorList = favouriteColorList | ColorCollection.Blue;
                        break;
                    case "Cyan":
                        favouriteColorList = favouriteColorList | ColorCollection.Cyan;
                        break;
                    case "Grey":
                        favouriteColorList = favouriteColorList | ColorCollection.Grey;
                        break;
                    case "Green":
                        favouriteColorList = favouriteColorList | ColorCollection.Green;
                        break;
                    case "Magenta":
                        favouriteColorList = favouriteColorList | ColorCollection.Magenta;
                        break;
                    case "Red":
                        favouriteColorList = favouriteColorList | ColorCollection.Red;
                        break;
                    case "White":
                        favouriteColorList = favouriteColorList | ColorCollection.White;
                        break;
                    case "Yellow":
                        favouriteColorList = favouriteColorList | ColorCollection.Yellow;
                        break;
                    default:
                        Console.WriteLine("incorrect value");
                        Console.ReadKey();
                        Environment.Exit(13);
                        break;
                }
            }
            Console.WriteLine($"list of not selected colors is {favouriteColorList}");
            Console.WriteLine($"list of not selected colors is {allColorList ^ favouriteColorList}");
            Console.ReadKey();
        }
    }
}
