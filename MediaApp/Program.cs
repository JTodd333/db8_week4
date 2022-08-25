//Video video1 = new Video("The Shining", "Horror", "Kubrik", "R");
//video1.Play();

Digital dig1 = new Digital("The Wall", "Rock", "Pink Floyd", 80, "iTunes");
dig1.Play();

Vinyl vin1 = new Vinyl("The White Album", "Rock", "The Beatles", 45, 1000);
vin1.Play();


class Media
{
    public string Title;
    public string Genre;

    public Media(string _Title, string _Genre)
    {
        Title = _Title;
        Genre = _Genre;
    }

    public virtual void Play()    //virtual needed in order to override in other classes
    {
        Console.WriteLine("The media is playing.");
    }
}

class Video : Media
{
    public string Director;
    public string Rating;

    public Video (string _Title, string _Genre, string _Director, string _Rating)
        : base(_Title, _Genre)
    {
        Director = _Director;
        Rating = _Rating;
    }
    public override void Play()
    {
        Console.WriteLine($"Video {Title} ({Genre}) Directed by {Director} Rated {Rating}");
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
        Console.WriteLine($"Digital {Title} ({Genre}) by {Artist}, {Duration} min on {Platform}");
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
        base.Play();
        Console.WriteLine($"Vinyl {Title} ({Genre}) by {Artist}, {Duration} min. {Count} limited copies.");
    }
}