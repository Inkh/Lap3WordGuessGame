using System;
using System.IO;

namespace WordGuessGame
{
    class Program
    {
        public static string wordPath = "../../../wordList.txt";
        public static string gamePath = "../../../game.txt";

        static void Main(string[] args)
        {

            CreateFile(wordPath);
            EntryMenu();
        }

        static void EntryMenu()
        {
            bool returnToMenu = true;

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
                        break;
                    case "2":
                        DisplayCurrentWords(wordPath);
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

        static void CreateFile(string path)
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

        static string[] DisplayCurrentWords(string path)
        {
            try
            {
                string[] myWords = File.ReadAllLines(path);

                foreach (string word in myWords)
                {
                    Console.WriteLine(word);
                }

                return myWords;
            }
            catch (Exception)
            {

                throw;
            }

        }

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
    }
}
