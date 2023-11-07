using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace HangmanGame
{
    internal class Program
    {
        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }

            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("     |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }
                        
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine(" |   |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }            
            
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|   |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }            
            
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("     |");
                Console.WriteLine("   ===");
            }            
            
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/    |");
                Console.WriteLine("   ===");
            }            
            
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   ===");
            }
        }

        private static int printWord(List<char> guessedLetters, String randomWord)
        {
            int counter = 0;
            int rightLetters = 0;
            Console.Write("\r\n");
            foreach (char c in randomWord)
            {
                if (guessedLetters.Contains(c))
                {
                    Console.WriteLine(c + " ");
                    rightLetters ++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetters;
        }

        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                //this creates the lines under the random word so it looks like it is the same line
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman :)");
            Console.WriteLine("---------------------------------------------");

            Random random = new Random();
            List<String> wordDictionary = new List<string> {"house", "tacos", "beer", "stranded", "tutorial", "software", "development"};
            int index = random.Next(wordDictionary.Count);
            String randomWord = wordDictionary[index];

            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lenghtOfWordToGuess = randomWord.Length;
            int amountTimesWrong = 0;
            List<char> lettersGuessed = new List<char>();
            int currentLettersRight = 0;

            while (amountTimesWrong != 6 && currentLettersRight != lenghtOfWordToGuess)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in lettersGuessed)
                {
                    Console.Write(letter + " ");
                }

                //Prompt user for input
                Console.Write("\nGuess a letter: ");
                char letterGuessed = Console.ReadLine()[0];

                //check if letter has already been guessed
                if (lettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\r\nYou have already guessed this letter");
                    printHangman(amountTimesWrong);
                    currentLettersRight = printWord(lettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    //Check if letter is in word.
                    bool right = false;
                    for( int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }

                    if (right)
                    {
                        printHangman(amountTimesWrong);
                        lettersGuessed.Add(letterGuessed);
                        currentLettersRight = printWord(lettersGuessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountTimesWrong++;
                        lettersGuessed.Add(letterGuessed);
                        printHangman(amountTimesWrong);
                        Console.Write("\r\n");
                        printLines(randomWord);
                        
                    }
                }
            }
            Console.WriteLine("\r\nGame is over, thank you for playing :)");
            // Console.ReadKey();
        }


    }
}