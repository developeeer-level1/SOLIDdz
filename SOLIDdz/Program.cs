using System.Globalization;
using System.Text.Json;

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



    public interface ICoordinatesService
    {
        (double Latitude, double Longitude) GetCoordinates();
    }
    public class GeoLocation
    {
        public string GetRawCoordinates()
        {
            return "37.7749, -122.4194";
        }
    }

    public class GeoLocationAdapter : ICoordinatesService
    {
        private readonly GeoLocation _geoLocation;

        public GeoLocationAdapter(GeoLocation geoLocation)
        {
            _geoLocation = geoLocation;
        }

        public (double Latitude, double Longitude) GetCoordinates()
        {
            string[] parts = _geoLocation.GetRawCoordinates().Split(',');
            double lat = double.Parse(parts[0].Trim(), CultureInfo.InvariantCulture);
            double lon = double.Parse(parts[1].Trim(), CultureInfo.InvariantCulture);
            return (lat, lon);
        }
    }

    class Program
    {
        static void Main()
        {
            AppConfig config = AppConfig.Instance;
            config.SetSetting("Theme", "Dark");
            config.SetSetting("Language", "English");
            Console.WriteLine(config.GetSetting("Theme"));
            Console.WriteLine(config.GetSetting("Language"));



            ShapeFactory circleFactory = new CircleFactory();
            IShape circle = circleFactory.CreateShape();
            circle.Draw();
            ShapeFactory rectangleFactory = new RectangleFactory();
            IShape rectangle = rectangleFactory.CreateShape();
            rectangle.Draw();



            GeoLocation geolocation = new GeoLocation();
            ICoordinatesService coordinatesService = new GeoLocationAdapter(geolocation);
            var coordinates = coordinatesService.GetCoordinates();
            Console.WriteLine($"Latitude: {coordinates.Latitude}, Longitude: {coordinates.Longitude}");
        }
    }
}