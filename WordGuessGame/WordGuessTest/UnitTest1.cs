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

        [Theory]
        [InlineData(false, "../../../game.txt")]
        public void DeleteFileTest(bool expected, string path)
        {
            DeleteGameFile(path);

            bool doesExist = File.Exists(path);
            Assert.True(expected == doesExist);
        }

        [Fact]
        public void DeleteWordTest()
        {
            string path = "../../../wordList.txt";
            DeleteAWord(path, "phone");

            Assert.Equal("Word does not exist. Returning you to menu... ", DeleteAWord(path, "cat"));
        }

        [Fact]
        public void AddAWordTest()
        {
            string path = "../../../wordList.txt";
            AddMoreWords(path, "phone");
            Assert.True(DisplayCurrentWords(path).Length == 2);
        }
    }
}
