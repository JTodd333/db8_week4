RAM mod1 = new RAM("Intel", "DDR3", 32);
Console.WriteLine(mod1.GetBrand());
//mod1.Brand = "AMD";   Can't do this, read only, can't change it.
mod1.SetType("DDR2");
Console.WriteLine(mod1.GetType());
mod1.SetType("Hello");
Console.WriteLine(mod1.GetType());   //Should not work because not valid, remains DDR2
mod1.SetGB(100);
Console.WriteLine(mod1.GetGB());


//Compare:
//mod1.Type = "Hello";   -- Programmers want to do this
//mod1.SetType("Hello");  --  ...with this "actually" happening behind the scenes

class RAM
{
    // Common technique ("pattern") -- make all our member variables private
    // This is generall true for most programming languages, not just C#
    public string Brand;
    private string Type;  //DDR, DDR2, DDR3, DDR4
    private int GB;       // any number between 1 and 32 inclusive

    //Constructor with validation
    public RAM(string _Brand, string _Type, int _GB)
    {
        Brand = _Brand;
        if (_Type == "DDR" || _Type == "DDR2" || _Type == "DDR3" || _Type == "DDR4")
        {
            Type = _Type;
        }
        else
        {
            Type = "DDR";    // Setting some default in case creating object with invalid entry
        }
        if (_GB >= 1 && _GB <= 32)
        {
            GB = _GB;
        }
        else
        {
            GB = 4;
        }
    }

    //Let's set up this protection:
    // 1. The user cannot change the brand, but can
    //     look at it (Read-Only)
    // 2. The user can set the type and look at it, but
    //    is limited to available types (Read/Write, but with validation
    // 3. The user can set the GB and look at it, but
    //    is limited to the range 1 - 32 (Read/Write, but with validation)

    // Methods called getters/setters

    public string GetBrand()
    {
        return Brand;
    }

    public string GetType()
    {
        return Type;
    }

    public void SetType(string _Type)  //Set general doesnt return anything, takes info in
    {
        //Valid options:
        //DDR, DDR2, DDR3, DDR4
        if (_Type == "DDR" || _Type == "DDR2" || _Type == "DDR3" || _Type == "DDR4")
        {
            Type = _Type;
        }
        // No else here because a consolewrite would be displayed to user, user hasnt entered anything yet.
        // We would validate entry before calling this function. Only "else" might be an error log.
        else
        {
            //Normally we would write something to a system log file for devlopers to read
        }
    }

    public int GetGB()
    {
        return GB;
    }
    public void SetGB(int value) // Often for setter people just use the param name "value"
    {
        if((value >= 1 && value <= 32))
        {
            GB = value;
        }
    }
}

