using System;
using System.IO;

namespace WordGuessGame
{
    class Program
    {
        public static string wordPath = "../../../wordList.txt";
        public static string gamePath = "../../../game.txt";
        public static bool returnToMenu = true;

        static void Main(string[] args)
        {
            CreateWordFile(wordPath);
            EntryMenu();
        }
        /// <summary>
        /// Displays menu and options for playing the game.
        /// Users could either view current 'database', add to db, delete from db, or exit.
        /// </summary>
        static void EntryMenu()
        {

            while (returnToMenu)
            {
                Console.WriteLine("Welcome to the word guess game!");
                Console.WriteLine("[1] Start a game");
                Console.WriteLine("[2] View your current list");
                Console.WriteLine("[3] Add a word");
                Console.WriteLine("[4] Delete a word");
                Console.WriteLine("[5] Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        PlayGame(gamePath);
                        break;
                    case "2":
                        string[] list = DisplayCurrentWords(wordPath);
                        foreach (string word in list)
                        {
                            Console.WriteLine(word);
                        }
                        break;
                    case "3":
                        DisplayCurrentWords(wordPath);
                        Console.WriteLine("What word would you like to add?");
                        AddMoreWords(wordPath, userInput = Console.ReadLine());
                        Console.WriteLine($"Sweet! {userInput} has been added to your existing list. Returning you to the menu...");
                        break;
                    case "4":
                        DisplayCurrentWords(wordPath);
                        Console.WriteLine("What word would you like to erase?");
                        Console.WriteLine(DeleteAWord(wordPath, userInput = Console.ReadLine()));
                        break;
                    case "5":
                        returnToMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input, cannot comprehend. Please try again");
                        break;
                }
            }
        }

        /// <summary>
        /// Creates the 'database' for holding our potential words.
        /// </summary>
        /// <param name="path">Path to file</param>
        static void CreateWordFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        try
                        {
                            sw.WriteLine("Your List: ");
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            sw.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Reads through the file then returns a list of words.
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>List of words</returns>
        static string[] DisplayCurrentWords(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);

                return myWords;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds to 'database' of words
        /// </summary>
        /// <param name="path">File Path</param>
        /// <param name="input">Word to add</param>
        static void AddMoreWords(string path, string input)
        {
            try
            {
                using(StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(input);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes from 'database' of words
        /// </summary>
        /// <param name="path">File Path</param>
        /// <param name="input">Word to delete</param>
        /// <returns>Sentence indicating whether word was found</returns>
        static string DeleteAWord(string path, string input)
        {
            try
            {
                string[] currentList = DisplayCurrentWords(wordPath);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        bool isFound = false;
                        // Start on the second line so title is not factored in
                        sw.WriteLine("Your List: ");
                        for (int i = 1; i < currentList.Length; i++)
                        {
                            if (currentList[i] != input)
                            {
                                sw.WriteLine(currentList[i]);
                            }
                            else if (currentList[i] == input)
                            {
                                isFound = true;
                            }
                        }
                        return isFound ? $"{input} has been deleted. Returning you to menu..." : "Word does not exist. Returning you to menu... ";
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates the game file.
        /// </summary>
        /// <param name="path">File Path</param>
        static void CreateGameFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        try
                        {
                            sw.WriteLine("Game on!");
                            sw.WriteLine("You current guesses");
                            sw.WriteLine(" ");
                            sw.WriteLine("--------------------");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        finally
                        {
                            sw.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Handles logic of the game. Users input individual letters.
        /// Empty list will populate with letters that are guessed correctly.
        /// Calls method to delete file once game is over.
        /// </summary>
        /// <param name="path">File Path</param>
        static void PlayGame(string path)
        {
            CreateGameFile(gamePath);
            //Reads words file
            string[] wordList = DisplayCurrentWords(wordPath);

            //Random generator
            Random rdm = new Random();

            //Generate a random index to pick a random word from list
            int randIdx = rdm.Next(1,wordList.Length);

            //Splits word into individual chars
            char[] wordToGuess = wordList[randIdx].ToCharArray();

            //Our output to console. Will be empty at first
            char[] currentWordProgress = new char[wordToGuess.Length];

            //Populate array with underscores if user hasn't guess the letter
            for (int i = 0; i < currentWordProgress.Length; i++)
            {
                currentWordProgress[i] = '_';
            }

            //Appends hidden word to game file
            AddMoreWords(gamePath, string.Join(" ", currentWordProgress));

            bool gameWon = false;

            //To be populated by guesses
            string guessSoFar = "";

            while (!gameWon)
            {
                string[] listToDisplay = DisplayCurrentWords(gamePath);
                foreach (string sentence in listToDisplay)
                {
                    Console.WriteLine(sentence);
                }

                Console.WriteLine("Guess a letter: ");

                //Checks if game is won
                if (Array.IndexOf(currentWordProgress, '_') >= 0)
                {
                    try
                    {
                        char userInput = Console.ReadLine().ToLower()[0];

                        //Concatenate letter after each user guess
                        guessSoFar += userInput + " ";

                        //Show list
                        UpdateWordGuess(gamePath, currentWordProgress, guessSoFar);

                        if (ContainsLetter(string.Join("", wordToGuess), userInput))
                        {
                            for(int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuess[i] == userInput)
                                {
                                    currentWordProgress[i] = userInput;
                                }
                            }
                            //Show list
                            UpdateWordGuess(gamePath, currentWordProgress, guessSoFar);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Letters only. Please try again.");
                    }
                }
                else
                {
                    DeleteGameFile(gamePath);
                    gameWon = true;
                    Console.WriteLine("Game won! Would you like to [1] play another game or [2] exit?");
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            PlayGame(gamePath);
                            break;

                        case "2":
                            returnToMenu = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the game file.
        /// </summary>
        /// <param name="path">File Path</param>
        static void DeleteGameFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Checks if string contains a letter.
        /// </summary>
        /// <param name="word">Game word</param>
        /// <param name="input">Guessed letter</param>
        /// <returns>True if guessed correctly, False otherwise</returns>
        static bool ContainsLetter(string word, char input)
        {
            if (word.Contains(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the game file everytime the user guesses a letter.
        /// </summary>
        /// <param name="path">File Path</param>
        /// <param name="input">Game word</param>
        /// <param name="guess">Guessed letter</param>
        static void UpdateWordGuess(string path, char[] input, string guess)
        {
            try
            {
                string[] currentList = DisplayCurrentWords(gamePath);
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        for (int i = 0; i < currentList.Length - 1; i++)
                        {
                            if (i == 2)
                            {
                                sw.WriteLine(guess);
                            }
                            else
                            {
                                sw.WriteLine(currentList[i]);
                            }
                        }
                        sw.WriteLine(string.Join(" ", input));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
