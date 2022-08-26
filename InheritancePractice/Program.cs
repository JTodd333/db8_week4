List<Animal> PetList = new List<Animal>();
ListInit(PetList);


Console.WriteLine("Welcome to the Pet Info Database!");
Console.WriteLine();
while (true) {
    Console.WriteLine("Press (1) to see list of pets.");
    Console.WriteLine("Press (2) to search a pet to see what they eat.");
    Console.WriteLine("Press (3) to Quit");
    string entry = Console.ReadLine();
    if (entry == "1")
    {
        foreach (Animal pets in PetList)
        {
            Console.WriteLine(pets);
            

        }
        Console.WriteLine();
    }
    else if (entry == "2")
    {
        Console.Write("Search for a pet by name: ");
        string name = Console.ReadLine();
        foreach (Animal found in PetList)
        {
            if (found.Name == name)
            {
                Console.WriteLine(found);
                found.Eat();
                Console.WriteLine();
            }
        }
    }
    else 
    {
        break;
    }
    
}






static void ListInit(List<Animal> thelist)
{
    Dog dog1 = new Dog("Poppy", 2019, 7);
    thelist.Add(dog1);
    Dog dog2 = new Dog("Ronnie", 2013, 8);
    thelist.Add(dog2);
    Cat cat1 = new Cat("Mrs Norris", 2010, 8);
    thelist.Add(cat1);
    Horse horse1 = new Horse("Frodo", 2008, "Quarter Horse");
    thelist.Add(horse1);
    Horse horse2 = new Horse("Stewie", 2000, "Tennessee Walker");
    thelist.Add(horse2);
}



class Animal
{
    public string Name;
    public int YearBorn;

    public Animal(string _Name, int _YearBorn)
    {
        Name = _Name;
        YearBorn = _YearBorn;
    }

    public virtual void Eat()
    {

    }
}

class Dog : Animal
{
    public int BarkVolume;

    public Dog(string _Name, int _YearBorn, int _BarkVolume) : base(_Name, _YearBorn)
    {
        BarkVolume = _BarkVolume;
    }

    public override void Eat()
    {
        Console.WriteLine("Dogs eat: dog food, treats, bones, and more!");
    }

    public override string ToString()
    {
        return $"Dog: {Name}, born {YearBorn}, barks at a {BarkVolume}.";
    }
}

class Cat : Animal
{
    public int HairLength;

    public Cat(string _Name, int _YearBorn, int _HairLength) : base(_Name, _YearBorn)
    {
       HairLength = _HairLength;
    }

    public override void Eat()
    {
        Console.WriteLine("Cats eat: cat food, treats, fish, and more!");
    }

    public override string ToString()
    {
        return $"Cat: {Name}, born {YearBorn}, Hair length(0-10): {HairLength}.";
    }
}

class Horse : Animal
{
    public string Breed;

    public Horse(string _Name, int _YearBorn, string _Breed) : base(_Name, _YearBorn)
    {
        Breed = _Breed;
    }

    public override void Eat()
    {
        Console.WriteLine("Horses eat: Oats, hay, treats, grass, and more!");
    }

    public override string ToString()
    {
        return $"Horse: {Name} Breed: {Breed}, born {YearBorn}";
    }
}