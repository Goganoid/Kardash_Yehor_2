namespace Lab2.Ex2;

public class PostCompany
{
    private List<Package> _packages;

    public PostCompany(List<Package> packages)
    {
        _packages = packages;
    }
    public void ListPackages(double maxWeight,
        SortOptions sortOption = SortOptions.ByArrival,
        double minWeight=0,
        GroupOptions groupOptions=GroupOptions.BySize)
    {
        var query = _packages
            .Where(p => p.Weight < maxWeight)
            .Where(p => p.Weight > minWeight)
            .OrderBy(p =>
            {
                return sortOption switch
                {
                    SortOptions.ByArrival => p.ArrivalPoint,
                    SortOptions.ByDeparture => p.DeparturePoint
                };
            })
            .GroupBy(p =>
            {
                return groupOptions switch
                {
                    GroupOptions.BySize => p.PackageType.ToString(),
                    GroupOptions.ByType => p.PackageSize.ToString(),
                };
            });
        foreach (var category in query)
        {
            Console.WriteLine($"Category: {category.Key}");
            foreach (var package in category)
            {
                Console.WriteLine($"\t{package}");
            }
        }
    }


}

public class Package
{
    private static int Counter = 0;
    public readonly double PricePerKm;
    public readonly string Name;
    public readonly PackageTypes PackageType;
    public readonly Sizes PackageSize;
    
    public readonly Position DeparturePoint;
    public readonly Position ArrivalPoint;
    public Position CurrentPosition { get; private set; }
    
 
    
    public double Weight { get; private set; }
    public double DistanceToArrival => Math.Abs(CurrentPosition.Distance - ArrivalPoint.Distance);
    public double Cost => Math.Abs(DeparturePoint.Distance - ArrivalPoint.Distance) * PricePerKm;
    public Package(double weight,PackageTypes packageType,Sizes packageSize,Position departurePoint, Position arrivalPoint, double pricePerKmPerKm=0.2f)
    {
        DeparturePoint = departurePoint;
        ArrivalPoint = arrivalPoint;
        Weight = weight;
        PackageType = packageType;
        PackageSize = packageSize;
        Name = $"Посилка {Counter++}";
        PricePerKm = pricePerKmPerKm;
        // create random point between
        var u = Random.Shared.NextDouble();
        Func<double,double,double> valueBetween = (v, v1) => (1 - u) * v + u * v1;
        CurrentPosition = new Position
        {
            X = valueBetween(departurePoint.X, arrivalPoint.X),
            Y = valueBetween(departurePoint.X, arrivalPoint.X)
        };
    }

    public override string ToString()
    {
        return $"{Name},Вага:{Weight},Відстань:{DistanceToArrival:F1}, Ціна:{Cost:F1}, Місце відправлення:{DeparturePoint},Місце прибуття:{ArrivalPoint}";
    }
}

public enum Sizes
{
    Small=0,
    Medium=1,
    Big=2
}
public enum SortOptions
{
    ByArrival,
    ByDeparture
}

public enum GroupOptions
{
    BySize,
    ByType
}
public enum PackageTypes
{
    Letter,
    Parcel,
    Package
}

public struct Position: IComparable<Position>
{
    public double X { get; set; }
    public double Y { get; set; }

    public double Distance => Math.Sqrt(X * X + Y * Y);

    public int CompareTo(Position b)
    {
        if (Distance < b.Distance) return -1;
        if (Math.Abs(Distance - b.Distance) < 10e-5) return 0;
        return 1;
    }

    public static Position operator -(Position a,Position b)
    {
        return new Position {X = a.X - b.X, Y = a.X - b.X};
    }

    public override string ToString()
    {
        return $"X={X},Y={Y}";
    }

    public Position()
    {
        X = Random.Shared.Next(10);
        Y = Random.Shared.Next(10);
    }
}