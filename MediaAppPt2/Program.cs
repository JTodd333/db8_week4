//
// Always start by building your classes. "Model First".
//    (Make an instace of each as you go to test it out)
// then make lists (or whatever) for your app.
// Populate the list with initial data
//
//We broke the main app into individual tasks, which we put in their own methods.
//In this case:
//    Initalize -- populates the list with initial data
//    PrintMenu -- prints out a menu and asks for users choice
//    Buy -- buys whatever the user chose
//    Add -- allows the user to add a new item to the list
// Get the app working or one time around
// And finally add the "Would you like to go again" stuff.
//

// Main App
//Moved list outside while loop so it didnt keep re-initializing it
List<Media> allmedia = new List<Media>();   //create list
Init(allmedia);                             //initialize list
while (true)
{
    string choice = PrintMenu(allmedia).ToLower();        //prints menu
                                                //Console.WriteLine(choice);                  //prints choice we made, just a test

    if (choice == "a")
    {
        AddNew(allmedia);
    }
    else if (choice == "q")
    {
        break;   // You could also do a bool before while and flip here instead
    }
    else
    {
        int index = int.Parse(choice) - 1;   //just converting string to int
        Buy(allmedia, index);    //passing list and their choice
    }
}

//foreach(Media med in allmedia)
//{
//    Console.WriteLine(med);
//}



static void Init(List<Media> thelist)    //Populates the list only
{
    Video video1 = new Video("The Shining", "Horror", "Kubrik", "R");
    thelist.Add(video1);

    Digital dig1 = new Digital("The Wall", "Rock", "Pink Floyd", 80, "iTunes");
    thelist.Add(dig1);

    Vinyl vin1 = new Vinyl("The White Album", "Rock", "The Beatles", 45, 1000);
    thelist.Add(vin1);

    dig1 = new Digital("Invisible Touch", "Rock", "Genesis", 50, "iTunes");
    thelist.Add(dig1);
}

static void Buy(List<Media> thelist, int index)
{
    //Console.WriteLine($"Buying something index {index}");  This was just to test function
    Console.WriteLine("Is this the item you want to buy?");
    Console.WriteLine(thelist[index]);  //Will call its ToString: We're grabbing the media instance and calling it ToString();
    Console.Write("y/n: ");
    string yesno = Console.ReadLine().ToLower();
    if (yesno == "y" || yesno == "yes")
    {
        thelist.RemoveAt(index);
        Console.WriteLine("Item purchased!");
    }
    else
    {
        Console.WriteLine("Thanks anyway!");
    }
}

static void AddNew(List<Media> thelist)
{
    Console.Write("What would you like to add (video/digital/vinyl): ");
    string type = Console.ReadLine().ToLower();
    Console.Write("Title: ");
    string title = Console.ReadLine();

    Console.Write("Genre: ");
    string genre = Console.ReadLine();


    if (type == "video")
    {
        Console.Write("Director: ");
        string director = Console.ReadLine();

        Console.Write("Rating: ");
        string rating = Console.ReadLine();

        thelist.Add(new Video(title, genre, director, rating));
    }
    else if (type == "digital")
    {
        Console.Write("Artist: ");
        string artist = Console.ReadLine();

        Console.Write("Duration: ");
        string duration = Console.ReadLine();

        Console.Write("Platform: ");
        string platform = Console.ReadLine();

        thelist.Add(new Digital(title, genre, artist, int.Parse(duration), platform));
    }
    else if (type == "vinyl")
    {
        Console.Write("Artist: ");
        string artist = Console.ReadLine();

        Console.Write("Duration: ");
        string duration = Console.ReadLine();

        Console.Write("Print Count: ");
        string count = Console.ReadLine();

        thelist.Add(new Vinyl(title, genre, artist, int.Parse(duration), int.Parse(count)));
    }
}


static string PrintMenu(List<Media> thelist)
{
    Console.WriteLine("Choose a media other option:");
    for (int index = 0; index < thelist.Count; index++)
    {
        Media med = thelist[index];   //grabs the item in list, allmedia by index
        Console.WriteLine($"{index + 1}: {med}");   //#1 to show starting at 1
    }
    Console.WriteLine("(A)dd new media");
    Console.WriteLine("(Q)uit");
    Console.Write("Your choice:");
    string entry = Console.ReadLine();
    return entry;
}




class Media
{
    public string Title;
    public string Genre;

    public Media(string _Title, string _Genre)
    {
        Title = _Title;
        Genre = _Genre;
    }

    public virtual void Play()
    {
        Console.WriteLine("The media is playing.");
    }
}

class Video : Media
{
    public string Director;
    public string Rating;

    public Video(string _Title, string _Genre, string _Director, string _Rating)
        : base(_Title, _Genre)
    {
        Director = _Director;
        Rating = _Rating;
    }
    public override void Play()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Video {Title} ({Genre}) Directed by {Director} Rated {Rating}";
        
    }

}

class Music : Media
{
    public string Artist;
    public int Duration;

    public Music(string _Title, string _Genre, string _Artist, int _Duration)
        : base(_Title, _Genre)
    {
        Artist = _Artist;
        Duration = _Duration;
    }

    public override void Play()
    {
        Console.WriteLine("Music");
    }
}

class Digital : Music
{
    public string Platform;

    public Digital(string _Title, string _Genre, string _Artist, int _Duration, string _Platform)
        : base(_Title, _Genre, _Artist, _Duration)
    {
        Platform = _Platform;
    }
    public override void Play()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Digital {Title} ({Genre}) by {Artist}, {Duration} min on {Platform}";
    }
}

class Vinyl : Music
{
    public int Count;

    public Vinyl(string _Title, string _Genre, string _Artist, int _Duration, int _Count)
        : base(_Title, _Genre, _Artist, _Duration)
    {
        Count = _Count;
    }

    public override void Play()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Vinyl {Title} ({Genre}) by {Artist}, {Duration} min. {Count} limited copies.";
    }
}