namespace Lab2.Ex1;

public class Clothing
{
    protected Clothing(string color, string name)
    {
        Console.WriteLine("Base constructor was called");
        Color = color;
        Name = name;
    }

    public bool IsWorn { get; private set; } = false;
    public string Color { get; }
    public string Name { get; }
    
    public void ToggleDress()
    {
        Console.WriteLine($"{Name} {(IsWorn?"знятий":"надітий")}");
        IsWorn = !IsWorn;
    }

    public void Print()
    {
        Console.WriteLine($"{ToString()} \t {(IsWorn?"Зняти":"Одягнути")}");
    }
    
    public override string ToString()
    {
        Console.WriteLine("ToString() was called");
        return $"{Name}, {Color}, Надітий:{(IsWorn ? "так" : "ні")}";
    }
    
    public override int GetHashCode()
    {
        Console.WriteLine("GetHashCode() was called");
        return (Name+Color).GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("Equals() was called");
        if (obj is Clothing clothing) return Name == clothing.Name && Color==clothing.Color;
        return false;
    }
}

public class Jacket : Clothing
{
    public Jacket(string color) : base(color, "Куртка")
    {
        Console.WriteLine("Jacket constructor was called");
    }
}
public class Shirt : Clothing
{
    public Shirt(string color) : base(color, "Сорочка")
    {
        Console.WriteLine("Shirt constructor was called");
    }
}

public class Pants : Clothing
{
    public Pants(string color) : base(color, "Штани")
    {
        Console.WriteLine("Pants constructor was called");
    }
}

public class FootGear : Clothing
{
    public FootGear(string color) : base(color, "Взуття")
    {
        Console.WriteLine("FootGear constructor was called");
    }
}