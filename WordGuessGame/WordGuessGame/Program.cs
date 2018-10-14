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
            bool isValidInput = true;

            while (isValidInput)
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
                        AddMoreWords(wordPath, Console.ReadLine());
                        break;
                    case "4":
                        break;
                    case "5":
                        isValidInput = false;
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
                            sw.WriteLine("Your list");
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
                DisplayCurrentWords(wordPath);
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
    }
}
