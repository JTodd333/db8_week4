Digital music1 = new Digital("The Wall", "Pink Floyd", "iTunes");
Vinyl music2 = new Vinyl("Sgt. Pepper's Lonely Hearts Club Band", "The Beatles", 1000);


List<Music> songs = new List<Music>();
songs.Add(music1);
songs.Add(music2);

//Music music3 = new Music();  Will not be work now because abstract

// By adding "abstract" we are blocking anyone from creating an instance of Music.
// We can still make instances of classes derived from Music.
// We can still use the Music type in out lists.
abstract class Music
{
    public string Title;
    public string Artist;
    //public Music() { }  Just example of a default pne with no parameters
    public Music(string _Title, string _Artist)
    {
        Title = _Title;
        Artist = _Artist;
    }

    //For your virtual functions in an abstract class, you can just
    //shorthand it like this:
    public abstract void Print();
    //The above is the same as below but using abstract instead of virtual
    //public virtual void Print()
    //{
    //                      //Will never be called because no instance of it
    //} 

}

class Digital : Music
{
    public string Platform;

    public Digital(string _Title, string _Artist, string _Platform) : base(_Title, _Artist)  
        //First ( ) are parameters being put into the base ( )
    {
        Platform = _Platform;
    }
    public override void Print()
    {
        Console.WriteLine("This is a digital album");
    }
}



// By adding "sealed" means classes cannot be derived from vinyl.
// This is rarely ever used!!
sealed class Vinyl : Music  
{
    public int Count;

    public Vinyl(string _Title, string _Artist, int _Count) : base(_Title, _Artist)
    {
         Count = _Count;
    }

    public override void Print()
    {
        Console.WriteLine("This is a vinyl record");
    }

}