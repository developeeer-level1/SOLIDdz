namespace PATTERNSdz
{
    public interface IShape
    {
        void Draw();
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }
    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }
    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Circle();
        }
    }
    public class RectangleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Rectangle();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            AppConfig.SetSetting("Theme", "Dark");
            AppConfig.SetSetting("Language", "English");
            Console.WriteLine(AppConfig.GetSetting("Theme"));
            Console.WriteLine(AppConfig.GetSetting("Language"));


            //2
            ShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw();

            ShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();
            rectangle.Draw();
        }
    }
}
