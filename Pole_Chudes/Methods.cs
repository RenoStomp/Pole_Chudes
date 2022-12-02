using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pole_Chudes
{
    internal class Methods
    {
        public static string[] ReturnWordsArray()
        {
            string[] wordsArray = new string[15] {"attractor", "kinescope", "void", "insomnia",
                      "calculator", "vocabulary", "language", "manipulation", "instruction", 
                      "combination", "integral", "consultation", "observatory", "factory", "lesson"};
            return wordsArray;
        }
        public static void WriteWordExplanation(string guessingWord, string[] wordsArray)
        {
            Console.WriteLine("\n\nHere is the word explanation:");

            if (guessingWord == wordsArray[0])
            {
                Console.WriteLine("In the mathematical field of dynamical " +
                    "systems, it is a set of states toward which a system tends " +
                    "to evolve, for a wide variety of starting conditions of the system.");
            }
            else if (guessingWord == wordsArray[1])
            {
                Console.WriteLine("Recording of a television " +
                    "program on motion picture film, directly through " +
                    "a lens focused on the screen of a video monitor.");
            }
            else if (guessingWord == wordsArray[2])
            {
                Console.WriteLine("Vast spaces between filaments " +
                    "(the largest-scale structures in the universe), " +
                    "which contain very few or no galaxies.");
            }
            else if (guessingWord == wordsArray[3])
            {
                Console.WriteLine("A sleep disorder in which people have trouble sleeping." +
                    " They may have difficulty falling asleep, or staying asleep as long as desired.");
            }
            else if (guessingWord == wordsArray[4])
            {
                Console.WriteLine("A portable electronic device used to perform " +
                    "calculations, ranging from basic arithmetic to complex mathematics.");
            }
            else if (guessingWord == wordsArray[5])
            {
                Console.WriteLine("Set of familiar words within a person's language.");
            }
            else if (guessingWord == wordsArray[6])
            {
                Console.WriteLine("A structured system of communication.");
            }
            else if (guessingWord == wordsArray[7])
            {
                Console.WriteLine("A behavior designed to exploit, control, " +
                    "or otherwise influence others to one’s advantage.");
            }
            else if (guessingWord == wordsArray[8])
            {
                Console.WriteLine("A booklet that instructs the user on how to use anything.");
            }
            else if (guessingWord == wordsArray[9])
            {
                Console.WriteLine("A mathematical technique that determines the " +
                    "number of possible arrangements in a collection of items where " +
                    "the order of the selection does not matter.");
            }
            else if(guessingWord == wordsArray[10])
            {
                Console.WriteLine("This symbol is assigns numbers to functions " +
                    "in a way that describes displacement, area, volume, and other " +
                    "concepts that arise by combining infinitesimal data.");
            }
            else if (guessingWord == wordsArray[11])
            {
                Console.WriteLine("A meeting between a patient with a physician " +
                    "to get health advice or treatment plan for a symptom or condition, " +
                    "most often at a professional health facility such as a doctor's office, clinic or hospital.");
            }
            else if (guessingWord == wordsArray[12])
            {
                Console.WriteLine("A location used for observing terrestrial, marine, or celestial events.");
            }
            else if (guessingWord == wordsArray[13])
            {
                Console.WriteLine("An industrial facility, often a complex consisting of several buildings" +
                    " filled with machinery, where workers manufacture items or operate machines which" +
                    " process each item into another.");
            }
            else if (guessingWord == wordsArray[14])
            {
                Console.WriteLine("A structured period of time where learning is intended to occur.");
            }
        }
        public static string StartGameAndReturnWinnerName(string guessingWord, string guessingWordHidden, 
            string[] wordsArray, char[] guessingWordHiddenArray, int rounds, string firstPlayer, 
            string secondPlayer, int firstPlayerCount, int secondPlayerCount)
        {

            while (guessingWord != guessingWordHidden)
            {
                string playerName;
                if (rounds % 2 != 0)
                {
                    playerName = firstPlayer;
                }
                else
                {
                    playerName = secondPlayer;
                }
                string prevGuessingWordHidden = guessingWordHidden;
                string input = RequestForALetterAndReturnItInLowCase(playerName);
                if (input == guessingWord)
                {
                    return playerName;
                }
                string letterInput = ReturnCorrectInput(input, guessingWord);
                if (letterInput == guessingWord)
                {
                    return playerName;
                }
                var letter = char.Parse(letterInput);

                guessingWordHidden = CompareAndReturnGuessingWord(guessingWord, letter, 
                    guessingWordHiddenArray, guessingWordHidden);

                if (guessingWordHidden != prevGuessingWordHidden)
                {
                    if (rounds % 2 != 0)
                    {
                        firstPlayerCount++;
                    }
                    else
                    {
                        secondPlayerCount++;
                    }
                }

                Console.Clear();

                rounds++;
                string writeRound = $"ROUND {rounds}";
                Console.SetCursorPosition(Console.WindowWidth / 2 - writeRound.Length / 2, 0);
                Console.WriteLine(writeRound);

                Console.Write($"So here is the word you need to guess: {guessingWordHidden}");
                WriteWordExplanation(guessingWord, wordsArray); 
                Console.WriteLine($"\n{firstPlayer}: {firstPlayerCount} points\n{secondPlayer}: " +
                    $"{secondPlayerCount} points");
            }
            if(firstPlayerCount > secondPlayerCount)
            {
                return firstPlayer;
            }
            else if(secondPlayerCount > firstPlayerCount)
            {
                return secondPlayer;
            }
            else
            {
                return "DRAW";
            }
        }
        public static string ReturnCorrectInput(string letterInput, string guessingWord)
        {
            bool incorrect = true;
            while (incorrect)
            {
                letterInput = Regex.Replace(letterInput, @"[^a-z]", "");
                if (letterInput == " " || !char.TryParse(letterInput, out char test))
                {
                    Console.Write("\nIncorrect input.\n\nInput just one letter and press enter: ");
                    letterInput = Console.ReadLine().ToLower();
                    if (letterInput == guessingWord)
                    {
                        break;
                    }
                }
                else
                {
                    incorrect = false;
                }
            }
            return letterInput;
        }
        public static string RequestForALetterAndReturnItInLowCase(string playerName)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - (21), 11);
            Console.Write($"Now time for {playerName} to guess a letter\n\nWrite only one letter" +
                " or if you know the word input it here and press ENTER: ");

            return Console.ReadLine().ToLower();
        }
        public static string CompareAndReturnGuessingWord(string guessingWord, char letter, char[] guessingWordHiddenArray, string guessingWordHidden)
        {
            int letterIndex = 0;
            foreach (var letterForCompare in guessingWord)
            {
                if (letterForCompare.Equals(letter))
                {
                    guessingWordHiddenArray[letterIndex] = letter;
                }
                letterIndex++;
            }

            if (new string(guessingWordHiddenArray) == guessingWordHidden)
            {
                Console.WriteLine($"It is no \"{letter}\" letter in this word :(\nBetter luck next try!");
            }
            else
            {
                Console.WriteLine($"It IS \"{letter}\" letter in this word ☻!☺!☺!☻");
            }
            guessingWordHidden = new string(guessingWordHiddenArray);
            Console.WriteLine($"\nWord you need to guess: {guessingWordHidden}\nPress any button to continue");

            Console.ReadKey();
            return guessingWordHidden;
        }
    }
}