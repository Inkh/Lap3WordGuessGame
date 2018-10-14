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
            AddMoreWords(wordPath);
            DisplayCurrentWords(wordPath);

        }

        static void CreateFile(string path)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        static void DisplayCurrentWords(string path)
        {
            //try
            //{
            //    using (StreamReader sr = File.OpenText(path))
            //    {
            //        string word = "";
            //        while ((word = sr.ReadLine()) != null)
            //        {
            //            Console.WriteLine(word);
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            ////}
            try
            {
                string[] myWords = File.ReadAllLines(path);

                foreach (string word in myWords)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void AddMoreWords(string path)
        {
            try
            {
                using(StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Hey i work too");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
