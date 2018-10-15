using System;
using Xunit;
using System.IO;
using static WordGuessGame.Program;

namespace WordGuessTest
{
    public class UnitTest1
    {
        [Fact]
        public void WordFileCreateTest()
        {
            string path = "../../../wordList.txt";
            CreateWordFile(path);
            Assert.True(File.Exists(path) == true);
        }

        [Fact]
        public void GameFileCreateTest()
        {
            string path = "../../../game.txt";
            CreateGameFile(path);
            Assert.True(File.Exists(path) == true);
        }

        [Fact]
        public void DisplayWordTest()
        {
            string path = "../../../wordList.txt";
            Assert.True(DisplayCurrentWords(path).Length > 0);
        }

        [Fact]
        public void DisplayGameTest()
        {
            string path = "../../../game.txt";
            Assert.Equal(4, DisplayCurrentWords(path).Length);
        }

        [Fact]
        public void DeleteFileTest()
        {
            string path = "../../../game.txt";
            CreateGameFile(path);
            DeleteGameFile(path);

            Action DoesExist = (() => DoesFileExist(path));
            Exception e = Record.Exception(DoesExist);
            Assert.IsType<FileNotFoundException>(e);
        }

        [Fact]
        public void DeleteWordTest()
        {
            string path = "../../../wordList.txt";
            CreateGameFile(path);
            DeleteAWord(path, "phone");

            Assert.Equal("Word does not exist. Returning you to menu... ", DeleteAWord(path, "cat"));
        }

        [Fact]
        public void AddAWordTest()
        {
            string path = "../../../wordList.txt";
            CreateGameFile(path);
            AddMoreWords(path, "phone");
            Assert.True(DisplayCurrentWords(path).Length == 2);
        }
    }
}
