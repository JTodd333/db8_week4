Console.WriteLine("Welcome to the LOTR Character Index");
Console.WriteLine("-----------------------------------");
Console.WriteLine();


Warrior Warrior1 = new Warrior("Aragorn", 8, 7, "Sword");
Warrior Warrior2 = new Warrior("Gimli", 9, 6, "Axe");
Wizard Wizard1 = new Wizard("Galdalf", 6, 9, 8, 6);
Wizard Wizard2 = new Wizard("Saruman", 5, 7, 7, 7);
Wizard Wizard3 = new Wizard("Radagast", 4, 7, 7, 5);



List<GameCharacter> gameCharacters = new List<GameCharacter>();
gameCharacters.Add(Warrior1);
gameCharacters.Add(Warrior2);
gameCharacters.Add(Wizard1);
gameCharacters.Add(Wizard2);
gameCharacters.Add(Wizard3);

foreach (GameCharacter character in gameCharacters)
{
    character.Play();
}

class GameCharacter
{
    public string Name;
    public int Strength;
    public int Intelligence;

    public GameCharacter(string _Name, int _Strength, int _Intelligence)
    {
        Name = _Name;
        Strength = _Strength;
        Intelligence = _Intelligence;
    }

    public virtual void Play()
    {
        Console.WriteLine($"{Name} [Strength: {Strength} Intelligence: {Intelligence}]");
    }

}

class Warrior : GameCharacter
{
    public string WeaponType;

    public Warrior(string _Name, int _Strength, int _Intelligence, string _WeaponType)
        : base(_Name, _Strength, _Intelligence)
    {
        WeaponType = _WeaponType;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} (Class: Warrior) [Strength: {Strength}, Intelligence: {Intelligence}, Weapon: {WeaponType}]");
    }
}

class MagicUsingChar : GameCharacter
{
    public int MagicalEnergy;

    public MagicUsingChar(string _Name, int _Strength, int _Intelligence, int _MagicalEnergy)
        : base(_Name, _Strength, _Intelligence)
    {
        MagicalEnergy = _MagicalEnergy;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} [Strength: {Strength}, Intelligence: {Intelligence}, Magical Energy: {MagicalEnergy}]");
    }    // Couldnt think of character type to add with magic ability but not more specialized than a wizard.
}

class Wizard : MagicUsingChar
{
    public int SpellNumber;

    public Wizard(string _Name, int _Strength, int _Intelligence, int _MagicalEnergy, int _SpellNumber)
        : base(_Name, _Strength, _Intelligence, _MagicalEnergy)
    {
         SpellNumber = _SpellNumber;
    }

    public override void Play()
    {
        Console.WriteLine($"{Name} (Class: Wizard) [Strength: {Strength}, Intelligence: {Intelligence}, Magical Energy: {MagicalEnergy}, Spell Count: {SpellNumber}]");
    }

}