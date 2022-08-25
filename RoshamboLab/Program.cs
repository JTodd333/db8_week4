
//Practice for random
//Random rnd = new Random();
//int num = rnd.Next(0, 3);
// can use a for loop to test the below
//Roshambo r1 = (Roshambo)rnd.Next(0, 3);   //This is casting
//Console.WriteLine(r1);

RandomPlayer player1 = new RandomPlayer("Fred");
//player1.Generate();                             (not needed just to test)
//Console.WriteLine(player1.CurrentChoice);

AlwaysPlayer player2 = new AlwaysPlayer("Sally", Roshambo.Rock);
//player2.Generate();
//Console.WriteLine(player2.CurrentChoice);

AlwaysPlayer player3 = new AlwaysPlayer("Sam", Roshambo.Paper);

RandomPlayer player4 = new RandomPlayer("Jim");

Play(player1, player2);
Play(player1, player2);
Play(player1, player2);

Play(player1, player3);
Play(player1, player3);
Play(player1, player3);

Play(player1, player4);
Play(player1, player4);
Play(player1, player4);

Play(player2, player4);
Play(player3, player4);

static void Play(Player p1, Player p2)
{
    // This is an example of polymorphism: We're calling
    // the respective Generate function based on the class,
    // even though we dont actually know in this ucntion
    // what the class is of each
    p1.Generate();
    p2.Generate();

    string winner = "";

    if (p1.CurrentChoice == p2.CurrentChoice)
    {
        winner = "Nobody";
    }
    else if (p1.CurrentChoice == Roshambo.Rock)
    {
        if (p2.CurrentChoice == Roshambo.Paper)
        {
            // paper beats rock -- player 2 wins
            winner = p2.Name;
        }
        else //p2 is playing scissors
        {
            // rock beats scissors -- player 1 wins
            winner = p1.Name;
        }
    }
    else if (p1.CurrentChoice == Roshambo.Paper)//p1 is playing scissors
    {
        if (p2.CurrentChoice == Roshambo.Paper)
        {
            // paper beats rock -- player 1 wins
            winner = p1.Name;
        }
        else //p2 is playing scissors
        {
            // scissors beats paper -- player 2 wins
            winner = p2.Name;
        }
    }
    else  //p1 is playing scissors
    {
        if(p2.CurrentChoice == Roshambo.Rock)
        {
            //Rock beats scissors -- player 2 wins
            winner = p2.Name;
        }
        else //p2 is playing paper
        {
            //scissors beats paper -- player 1 wins
            winner = p1.Name;
        }

    }

    Console.WriteLine($"Players: {p1.Name} ({p1.CurrentChoice}) and {p2.Name} ({p2.CurrentChoice}). Result: {winner} wins!");
}

enum Roshambo
{
    Rock,     // this one is 0
    Paper,    // this one is 1
    Scissors, // this one is 2
    //None      // this one is 3
}

abstract class Player
{
    public string Name;
    public Roshambo CurrentChoice;

    public virtual void Generate()
    {

    }

}

class RandomPlayer : Player
{
    public RandomPlayer(string _Name)
    {
        Name = _Name;
    }
    public override void Generate()
    {
        Random rnd = new Random();
        CurrentChoice = (Roshambo)rnd.Next(0, 3);
    }
}

class AlwaysPlayer : Player
{
    public AlwaysPlayer(string _Name, Roshambo _Choice)
    {
        Name = _Name;
        CurrentChoice = _Choice;
    }
}