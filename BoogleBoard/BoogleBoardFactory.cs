namespace BoogleBoard
{
    public class BoogleBoardFactory
    {
        public BoogleBoard Create(char[,] boggles, string[] availableWords)
        {
            if (boggles.Length == 0) return new BoogleBoard(new BoogleCell[,] { }, availableWords);

            var _cells = new BoogleCell[boggles.GetLength(0), boggles.GetLength(1)];

            var totalRows = boggles.GetLength(0);
            var totalColsPerRow = boggles.GetLength(1);

            for(var r = 0; r < totalRows; r++)
            {
                for(var c = 0; c < totalColsPerRow; c++)
                {
                    _cells[r, c] = new BoogleCell
                    {
                        Col = c,
                        Row = r,
                        Value = boggles[r, c],
                        IsLeftMost = c == 0,
                        IsRightMost = c == totalColsPerRow -1,
                        IsTopMost = r == 0,
                        IsBottomMost = r == totalRows - 1
                    };
                }
            }

            return new BoogleBoard(_cells, availableWords);
        }
    }
}
