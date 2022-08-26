abstract class Movie
{
    public string Title { get; set; }
    public enum Genre
    {
        Drama,
        Comedy,
        Horror,
        Romance,
        Action
    }
    public int RunTime { get; set; }

    public List<Movie> scenes;

    public virtual void PrintScenes()
    {
        for(int i = 0; i < scenes.Count; i++)
        {
            Console.WriteLine($"{i}. {scenes[i]}");
        }

    }

    public abstract void Play();
}

class VHS : Movie
{

}