using System;
using System.Collections.Generic;
using Xunit;
using BoogleBoard;
using Shouldly;
using System.Linq;

namespace BoogleBoard.Tests
{
    public class BoogleBoard_Should
    {
        private string[] words = { "GEEKS", "FOR", "QUIZ", "GO" };
        private char[,] boogles = new[,]
        {
            {'G', 'I', 'Z' },
            {'U', 'E', 'K' },
            {'Q', 'S', 'E' }
        };
        private string[] expectedResults = { "GEEKS", "QUIZ" };

        [Fact]
        public void Return_Correct_Result()
        {
            var sut = new BoogleBoardFactory().Create(boogles, words);

            var result = sut.DiscoverWords();

            result.ShouldBe(expectedResults);
        }
    }
}
