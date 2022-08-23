Sedan mycar = new Sedan(4, "Blue", true, 4);
mycar.Drive();

RaceCar myracecar = new RaceCar(4, "red", 400);
myracecar.Drive();

RaceCar secondracer = new RaceCar(3, "Yellow", 1000);

List<Vehicle> cars = new List<Vehicle>();
cars.Add(mycar);
cars.Add(myracecar);
cars.Add(secondracer);

Console.WriteLine();
Console.WriteLine("Everybody Drive!");

foreach(Vehicle car in cars)
{
    car.Drive();
}

//This comment code demonstartes polymorphism
//Vehicle something;
//something = mycar;
//something.Drive(); // It will call the correct version

//something = myracecar;
//something.Drive(); // This concept is called polymorphism

class Vehicle
{
    public int WheelCount;
    public string Color;

    public Vehicle(int _WheelCount, string _Color)
    {
        WheelCount = _WheelCount;
        Color = _Color;
    }

    public virtual void Drive()
    {
        Console.WriteLine($"I am driving a {Color} car with {WheelCount} wheels.");
    }
}

class Sedan : Vehicle    //ignore the error about constructor parameters. We'll get there!
{
    public bool HasHatchBack;
    public int DoorCount;

    public Sedan(int _SedanWheelCount, string _SedanColor, bool _HasHatchBaack, int _DoorCount) 
        : base(_SedanWheelCount, _SedanColor)  //This line can be backspaced back to prev line
    {
        HasHatchBack = _HasHatchBaack;
        DoorCount = _DoorCount;
    }
    public override void Drive()
    {
        Console.WriteLine($"I am driving speed limit in my {Color} {DoorCount}-door car!");
    }
}

class RaceCar : Vehicle
{
    public int EngineSize;
    public RaceCar(int _WheelCount, string _Color, int _EngineSize) 
        : base(_WheelCount, _Color)
    {
        EngineSize = _EngineSize;
    }

    public override void Drive()
    {
        Console.WriteLine($"I am driving really fast with my {EngineSize} engine! The car is {Color}.");
    }
}