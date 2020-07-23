using System;
using System.Collections.Generic;

namespace Hangman
{
    class Game
    {
        List<string> wordList = new List<string>();

        //Game starts
        public void PlayGame()
        {
            Greeting();
            AddWords();
            GetWord();
            GuessWord();
        }
        //Greeting the player
        private void Greeting()
        {
            Console.WriteLine("WELCOME TO THE HANGMAN GAME!");
            Console.Write("What's your name? "); var userName = Console.ReadLine();
            Console.WriteLine($"Great! Let's begin, {userName}!");
            Console.WriteLine();
        }
        //Adding words to the list
        private void AddWords()
        {
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
            Console.WriteLine($"This word contains {wordList[randomWordNumber].Length} letters.");
            for (int i = 0; i <= wordList[randomWordNumber].Length; i++)
            {
                Console.Write("_");
            };
            Console.WriteLine();
        }

        //Method for word guessing       
        //Currently the loop keeps going until you enter a single letter.
        //Need to add another method for when the user input is correct. 
        //After that there are two options: whether the letter is or is not a part of the word.
        private void GuessWord()
        {
            Console.WriteLine();
            Console.Write("Guess a letter: "); string userLetter = Console.ReadLine();

            if (!ValidateInput(userLetter))
            {
                while (!ValidateInput(userLetter))
                {
                    Console.Write("You have to guess by one letter! Guess again: ");
                    userLetter = Console.ReadLine();
                }
            }
        }

        //Validation whether the user input is correct (needs to be a single character, and the character has to be a letter)
        private bool ValidateInput(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            if (input.Length != 1)
            {
                return false;
            }
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return true;
        }
    }
}
