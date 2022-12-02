using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Pole_Chudes;
public class Program
{
    public static void Main(string[] args)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - 18, 0);
        Console.WriteLine("WELCOME TO THE \"POLE CHUDES\" GAME!");
        Console.WriteLine("This game is for two players only\n");
        Console.Write("Input name of the first player here: ");
        string firstPlayer = Console.ReadLine();
        Console.Write("Input name of the second player here: ");
        string secondPlayer = Console.ReadLine();

        Console.WriteLine("\nAwesome! Now press any key to start the game!");
        Console.ReadKey();
        Console.Clear();

        int firstPlayerCount = 0;
        int secondPlayerCount = 0;

        int rounds = 1;

        Random rand = new Random();
        string[] wordsArray = Methods.ReturnWordsArray();
        string guessingWord = wordsArray[rand.Next(wordsArray.Length)];

        string writeRound = $"ROUND {rounds}";
        Console.SetCursorPosition(Console.WindowWidth / 2 - writeRound.Length / 2, 0);
        Console.WriteLine(writeRound);

        Console.Write("So here is the word you need to guess: ");

        char[] guessingWordHiddenArray = new char[guessingWord.Length];

        for (int i = 0; i < guessingWord.Length; i++)
        {
            guessingWordHiddenArray[i] = '*';
            Console.Write("*");
        }

        string guessingWordHidden = new string(guessingWordHiddenArray);

        Methods.WriteWordExplanation(guessingWord, wordsArray);

        Console.WriteLine($"\n{firstPlayer}: {firstPlayerCount} points\n{secondPlayer}: {secondPlayerCount} points");
        Console.WriteLine("\nPress ENTER to continue\n");
        Console.ReadKey();


        string winner = Methods.StartGameAndReturnWinnerName(guessingWord, guessingWordHidden, wordsArray, 
            guessingWordHiddenArray, rounds, firstPlayer, secondPlayer, firstPlayerCount, secondPlayerCount);

        Console.SetCursorPosition(Console.WindowWidth / 2 - (21), 11);
        Console.WriteLine("CONGRATULATIONS! YOU HAVE GUESSED THE WORD!");
        Console.ReadKey();
        Console.Clear();
        if(winner == "DRAW")
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 5);
            Console.WriteLine("!!! DRAW !!!");
        }
        else
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 13, 5);
            Console.WriteLine($"THE WINNER IS !!! {winner} !!!");
        }
        Console.ReadKey();
    }

}
