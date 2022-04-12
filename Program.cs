using Lab2.Ex1;
using Lab2.Ex2;

void Ex2()
{
    PostCompany postCompany = new(new List<Package>()
    {
        new(5, PackageTypes.Letter, Sizes.Small, new Position(), new Position()),
        new(10, PackageTypes.Letter, Sizes.Small,new Position(), new Position()),
        new(15, PackageTypes.Parcel, Sizes.Small, new Position(), new Position()),
        new(20, PackageTypes.Parcel, Sizes.Medium, new Position(), new Position()),
        new(18, PackageTypes.Package, Sizes.Big, new Position(), new Position()),
        new(30, PackageTypes.Package, Sizes.Big, new Position(), new Position()),
    });
    Console.WriteLine("Group by:\n1.Type\n2.Size");
    var answer = Console.ReadLine();
    var groupBy = GroupOptions.BySize;
    if(answer=="1") groupBy = GroupOptions.ByType;
    Console.WriteLine("Sort by:\n1.Arrival position \n2.Departure position");
    answer = Console.ReadLine();
    var sortBy = SortOptions.ByDeparture;
    if (answer == "1") sortBy = SortOptions.ByArrival;
    
    postCompany.ListPackages(20,groupOptions:groupBy,sortOption:sortBy);
}

void Ex1()
{
    Clothing[] clothings =
    {
        new Jacket("Червоний"),
        new Jacket("Синій"),
        new FootGear("Жовтий"),
        new Pants("Рожевий"),
        new Shirt("Чорний"),
        new Shirt("Сірий"),
    };
    do
    {
        for (int i = 0; i < clothings.Length; i++)
        {
            Console.Write($"{i}.");
            clothings[i].Print();
        }
        Console.WriteLine("Оберіть варіант щоб одягнути або зняти");
        uint option = 0;
        while (!uint.TryParse(Console.ReadLine(), out option) || option > clothings.Length)
        {
            Console.WriteLine("Неправильний варіант");
        }
        clothings[option].ToggleDress();
        Console.WriteLine("Продовжити? Так/Ні");
    } while (Console.ReadLine() == "так");
}

Console.WriteLine("Оберіть завдання 1,2");
var answer = Console.ReadLine();
if(answer=="1") Ex1();
else if(answer=="2") Ex2();