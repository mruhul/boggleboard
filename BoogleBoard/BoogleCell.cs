namespace BoogleBoard
{
    public class BoogleCell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public char Value { get; set; }
        
        public bool IsLeftMost { get; set; }
        public bool IsRightMost { get; set; }
        public bool IsTopMost { get; set; }
        public bool IsBottomMost { get; set; }

        public bool IsSameCell(BoogleCell cell)
        {
            return cell.Row == this.Row 
                && cell.Col == this.Col;
        }
    }
}
