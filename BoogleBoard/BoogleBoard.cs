using System.Collections.Generic;

namespace BoogleBoard
{
    public class BoogleBoard
    {
        private readonly BoogleCell[,] _cells;
        private readonly string[] _availableWords;

        public BoogleBoard(BoogleCell[,] cells, string[] availableWords)
        {
            _cells = cells;
            _availableWords = availableWords;
        }

        public IEnumerable<string> DiscoverWords()
        {
            for(var r = 0; r < _cells.GetLength(0); r++)
            {
                for(var c = 0; c < _cells.GetLength(1); c++)
                {
                    var startCell = _cells[r, c];

                    var crawler = new BoogleBoardCrawler(_cells, startCell, _availableWords);

                    var result = crawler.Crawl();

                    foreach(var item in result)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
