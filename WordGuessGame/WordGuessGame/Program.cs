using System;
using System.IO;

namespace WordGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string wordPath = "../../../wordList.txt";
            CreateFile(wordPath);
            Console.WriteLine("Add something yes?");
            AddMoreWords(wordPath, Console.ReadLine());
            DisplayCurrentWords(wordPath);

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
