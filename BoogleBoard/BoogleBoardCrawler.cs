using System;
using System.Collections.Generic;
using System.Linq;

namespace BoogleBoard
{
    public class BoogleBoardCrawler
    {
        private readonly BoogleCell[,] _cells;
        private readonly BoogleCell _startCell;
        private readonly IEnumerable<string> _availableWords;

        public BoogleBoardCrawler(BoogleCell[,] cells, BoogleCell startCell, string[] availableWords)
        {
            _cells = cells;
            _startCell = startCell;
            _availableWords = availableWords;
        }

        private bool HasWordStartsWith(string prefix)
        {
            return _availableWords.Any(x => x.StartsWith(prefix));
        }

        private bool WordExists(string word)
        {
            return _availableWords.Any(x => x == word);
        }

        public IEnumerable<string> Crawl()
        {
            var path = _startCell.Value.ToString();

            if (!HasWordStartsWith(path)) yield break;

            var cellsToMove = CellsToMove(_startCell);

            foreach(var cell in cellsToMove)
            {
                var result = Crawl(cell, path);

                foreach(var item in result)
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<string> Crawl(BoogleCell currentCell, string path)
        {
            path = path + currentCell.Value;

            if (!HasWordStartsWith(path)) yield break;

            if (WordExists(path)) yield return path;

            if (currentCell.IsSameCell(_startCell))
            {
                yield break;
            }

            var cellsToMoveNext = CellsToMove(currentCell);

            foreach (var cell in cellsToMoveNext)
            {
                var result = Crawl(cell, path);

                foreach (var item in result)
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<BoogleCell> CellsToMove(BoogleCell currentCell)
        {
            // left cell
            if (!currentCell.IsLeftMost)
            {
                yield return _cells[currentCell.Row, currentCell.Col - 1];
            }

            // right cell
            if (!currentCell.IsRightMost)
            {
                yield return _cells[currentCell.Row, currentCell.Col + 1];
            }

            // top cell
            if (!currentCell.IsTopMost)
            {
                yield return _cells[currentCell.Row - 1, currentCell.Col];
            }

            // bottom cell
            if (!currentCell.IsBottomMost)
            {
                yield return _cells[currentCell.Row + 1, currentCell.Col];
            }

            // topleft
            if (!currentCell.IsTopMost && !currentCell.IsLeftMost)
            {
                yield return _cells[currentCell.Row - 1, currentCell.Col - 1];
            }

            // topright
            if (!currentCell.IsTopMost && !currentCell.IsRightMost)
            {
                yield return _cells[currentCell.Row - 1, currentCell.Col + 1];
            }

            // bottomleft
            if (!currentCell.IsBottomMost && !currentCell.IsLeftMost)
            {
                yield return _cells[currentCell.Row + 1, currentCell.Col - 1];
            }

            // bottomright
            if (!currentCell.IsBottomMost && !currentCell.IsRightMost)
            {
                yield return _cells[currentCell.Row + 1, currentCell.Col + 1];
            }
        }
    }
}
