Console.WriteLine("Welcome to Todd's Cars!");
Console.WriteLine();
List<Car> cars = new List<Car>();
Init(cars);

while (true)
{
    int choice = PrintMenu(cars);
    if (choice == cars.Count + 1)
    {
        AddCar(cars);
    }
    else if (choice == cars.Count + 2)
    {
        break;
    }
    else
    {
        BuyCar(cars, choice - 1);
    }
}
Console.WriteLine("Have a great day!");


static void Init(List<Car> thelist)
{
    Car new1 = new Car("Jeep", "Gladiator (Willys)", 2022, 50575);
    thelist.Add(new1);
    Car new2 = new Car("Jeep", "Grand Cherokee (Trailhawk)", 2022, 61950);
    thelist.Add(new2);
    Car new3 = new Car("Dodge", "Ram 1500 (Classic)", 2022, 52820);
    thelist.Add(new3);
    UsedCar used1 = new UsedCar("Jeep", "Compass (Trailhawk)", 2019, 24590, 62935);
    thelist.Add(used1);
    UsedCar used2 = new UsedCar("Jeep", "Cherokee (Trailhawk)", 2014, 19990, 96880);
    thelist.Add(used2);
    UsedCar used3 = new UsedCar("Jeep", "Wrangler (Rubicon)", 2020, 47590, 52846);
    thelist.Add(used3);
    UsedCar used4 = new UsedCar("Dodge", "Durango (SXT)", 2020, 36990, 31723);
    thelist.Add(used4);
    UsedCar used5 = new UsedCar("Dodge", "Challenger (R/T Scat Pack)", 2020, 45590, 29920);
    thelist.Add(used5);
}

static int PrintMenu(List<Car> thelist)
{
    for (int index = 0; index < thelist.Count; index++)
    {
        Car car = thelist[index];
        Console.WriteLine($"{index +1}. {car}");
    }
    Console.WriteLine($"{thelist.Count + 1}. Add a car");
    Console.WriteLine($"{thelist.Count + 2}. Quit");
    Console.WriteLine();
    Console.Write("Please enter # of car to purchase or other menu option: ");
    string entry = Console.ReadLine();
    return int.Parse(entry);

}

static void BuyCar(List<Car> thelist, int carchoice)
{
    Console.WriteLine(thelist[carchoice]);
    Console.Write("Would you like to buy this car? (y/n): ");
    string choice = Console.ReadLine().ToLower();
    if (choice == "y" || choice == "yes")
    {
        thelist.RemoveAt(carchoice);
        Console.WriteLine("Excellent! Our finance department will be in touch shortly.");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Thanks anyway! Returning to menu.");
        Console.WriteLine();
    }
}

static void AddCar(List<Car> thelist)
{
    Console.Write("Are you adding a new or used car? (new/used): ");
    string entry = Console.ReadLine().ToLower();
    Console.Write("Make: ");
    string make = Console.ReadLine();
    Console.Write("Model: ");
    string model = Console.ReadLine();
    Console.Write("Year: ");
    int year = int.Parse(Console.ReadLine());
    Console.Write("Price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    if (entry == "new")
    {
        thelist.Add(new Car(make, model, year, price));
        Console.WriteLine($"Thank you! {model} added.");
    }
    else if (entry == "used")
    {
        Console.Write("Mileage: ");
        double mileage = double.Parse(Console.ReadLine());
        thelist.Add(new UsedCar(make, model, year, price, mileage));
        Console.WriteLine($"Thank you! {model} added.");
        Console.WriteLine();
    }

}

class Car
{
    public string Make;
    public string Model;
    public int Year;
    public decimal Price;

    public Car(string _Make, string _Model, int _Year, decimal _Price)
    {
        Make = _Make;
        Model = _Model;
        Year = _Year;
        Price = _Price;
    }

    public override string ToString()
    {
        return $"{Year} {Make} - {Model} \t ${Price}";
    }

}

class UsedCar: Car
{
    public double Mileage;

    public UsedCar(string _Make, string _Model, int _Year, decimal _Price, double _Mileage)
        : base(_Make, _Model, _Year, _Price)
    {
        Mileage = _Mileage;
    }

    public override string ToString()
    {
        return $"{Year} {Make} - {Model} \t ${Price} (Used) {Mileage} miles";
    }
}