public class Day2T1
{
    public class Shape
    {
        public string Name { get; }

        public Shape(string name)
        {
            Name = name;
        }

        public virtual double CalculateArea()
        {
            return 0; 
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; }
        public double Height { get; }

        public Triangle(string name, double triangleBase, double height) : base(name)
        {
            Base = triangleBase;
            Height = height;
        }

        public override double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }

    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine($"Shape: {shape.Name}, Area: {shape.CalculateArea()}");
    }

    public static void Main()
    {
        var circle = new Circle("Circle 1", 5);
        var rectangle = new Rectangle("Rectangle 1", 4, 6);
        var triangle = new Triangle("Triangle 1", 3, 8);

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
