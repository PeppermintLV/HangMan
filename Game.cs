using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Hangman
{
    class Game
    {
        List<string> wordList;
        List<string> letterInputs;
        char[] word;
        char[] result;

        //Game starts
        public void PlayGame()
        {
            Greeting();
            AddWords();
            GuessWord();
        }

        //Greeting the player, explaining rules        
        private void Greeting()
        {
            Console.WriteLine("WELCOME TO THE HANGMAN GAME!"); Console.WriteLine(); 
            Console.WriteLine("GAME DESCRIPTION:"); 
            Console.WriteLine("1. The computer chooses a word from a secret list."); 
            Console.WriteLine("2. You have to guess the word until your lives run out."); Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(); Console.SetCursorPosition(0, 7);
            Console.ForegroundColor = ConsoleColor.Green;            
            Console.WriteLine("Good luck!"); Thread.Sleep(1000); Console.ResetColor();
        }

        //Adding words to the list
        private void AddWords()
        {
            wordList = new List<string>();
            wordList.Add("science");
            wordList.Add("mobility");
            wordList.Add("obvious");
            wordList.Add("attempt");
            wordList.Add("summertime");
            wordList.Add("hedgehog");
            wordList.Add("computer");
        }

        //Get a random word from the list
        private void GetWord()
        {
            Random random = new Random();
            int randomWordNumber = random.Next(1, wordList.Count);

            word = wordList[randomWordNumber].ToCharArray();
            result = new char[wordList[randomWordNumber].Length];

            for (int i = 0; i < word.Length; i++)
            {
                result[i] = '_';
            };

            Console.Clear();
            Console.WriteLine("LET'S PLAY THE HANGMAN GAME!");
            Console.WriteLine();
            Console.WriteLine(result);
        }

        //Method for word guessing      
        private void GuessWord()
        {
            GetWord();
            letterInputs = new List<string>();
            bool _gameNoStop = true;
            while (_gameNoStop)
            {
                Console.WriteLine();
                Console.Write("Guess a letter: ");

                string userLetter = Console.ReadLine();

                //if (!ValidateInput(userLetter))
                //{
                    while (!ValidateInput(userLetter))
                    {
                        //You have to guess by one letter!
                        Console.Write("Guess again: ");
                        userLetter = Console.ReadLine();
                    }
                //}
                var letter = userLetter.ToCharArray();
                updateWord(letter[0]);

                Console.Clear();
                Console.WriteLine("LET'S PLAY THE HANGMAN GAME!");
                Console.WriteLine();
                Console.WriteLine(result);

                _gameNoStop = result.Any(m => m == '_');             
             }
            if (!_gameNoStop)
            {
                Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You WON!"); Console.ResetColor();
                ContinueGame();
            }
        }

        //Validation whether the user input is correct
        private bool ValidateInput(string input)
        {
            //Checking if there is any input
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Your input was empty!");
                return false;
            }

            //If input is 1 character
            if (input.Length > 1)
            {
                Console.WriteLine("Your input was more than 1 character long!");
                return false;
            }

            //If the character is letter
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                {
                    Console.WriteLine("Your input was not a letter!");
                    return false;
                }
            }

            //If the letter hasn't been guessed yet
            foreach (string item in letterInputs)
            {
                if (input == item)
                {
                    Console.WriteLine("You already guessed this letter!");
                    return false;
                }
            }

            letterInputs.Add(input);
            return true;            
        }

        //Updating the word after each guess
        private void updateWord(char letter)
        {
            for (int i = 0; i <= word.Length - 1; i++)
            {
                if (word[i] == letter)
                {
                    result[i] = word[i];
                }
            }
        }

        //Asking the user if he/she wants to continue playing the game. Input has to be 'y' or 'n'.
        private void ContinueGame()
        {
            Console.WriteLine(); 
            Console.Write("Continue game? (y/n): "); 

            var userAnswer = Console.ReadLine();

            while (userAnswer != "y" && userAnswer != "n")
            {            
            Console.Write("Continue game? (y/n): "); 
            userAnswer = Console.ReadLine();
            }

            if (userAnswer == "n")
            {
                Console.WriteLine();
                Console.WriteLine("Thanks for playing the Hangman game!");
            }

            if (userAnswer == "y")
            {
                GuessWord();
            }
        }
    }
}
