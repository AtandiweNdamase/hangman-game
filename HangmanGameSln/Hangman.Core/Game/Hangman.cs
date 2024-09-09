using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
       
        private int _lives = 6;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
           
        }
        


        public void Run()
        {
            string correctWord = string.Empty;

            _renderer.Render(5, 5, _lives);

            string[] wordList = new string[20] { "dogma", "xenophobia", "malevolence","nepotism","cupidity","bombastic","nostalgia","pandemic","flourish","utopia",
              "dystopia","energy","aura","solar","constellation","infinity","galaxy","mutants","dragon","equivalence"};
            Random randomWords = new Random();
            var letter = randomWords.Next(0, 19);
            string guessWord = wordList[letter];
            char[] attempt = new char[guessWord.Length];
            for (int i = 0; i < guessWord.Length; i++)
            {
                attempt[i] = '_';
            }
            while ( _lives > 0 && _lives <=6)
            {

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(attempt);

                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = char.Parse( Console.ReadLine());
                 bool correctGuess = false;
                {
                    for (int a = 0; a < guessWord.Length; a++)
                    {
                        if (nextGuess == guessWord[a])
                        {
                            attempt[a] = nextGuess;
                            correctGuess = true;
                        }
                    }
                    if (!correctGuess )
                    {
                        _lives--;
                        _renderer.Render(5, 5, _lives);
                    }
                }
                //if a player wins
                correctWord = new string(attempt);
                if (correctWord == guessWord)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Yes! you survived :)");
                }
                
                
            }
            if (correctWord!= guessWord)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("You've been hanged!!");
                Console.WriteLine(" The word was :" + guessWord);
            }
            
        }

    }
}
