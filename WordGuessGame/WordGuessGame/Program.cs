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
            
        }

        static void CreateFile(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    try
                    {
                        sw.Write("Your list" +
                            "");
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

        static void DisplayCurrentWords(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string word = "";
                    while ((word = sr.ReadLine()) != null)
                    {

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void AddMoreWords()
        {

        }
    }
}
