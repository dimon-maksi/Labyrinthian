namespace Labyrinthian.Data
{
    public class Cell
    {
        public bool IsFilled { get; set; }
        public bool Top { get; private set; }
        public bool Right { get; private set; }        
        public bool Bottom { get; private set; }
        public bool Left { get; private set; }
        public Cell()
        {
            IsFilled = false;
            this.Top = false;
            this.Right = false;
            this.Bottom = false;
            this.Left = false;
        }
        /// <summary>
        /// Top, Right, Bottom, Left
        /// </summary>
        /// <param name="Value"></param>
        public void OpenWay(string way)
        {
            if(way != null)
            {
                if (way.Contains("Top")) { this.Top = true; }
                if (way.Contains("Right")) { this.Right = true; }
                if (way.Contains("Bottom")) { this.Bottom = true; }
                if (way.Contains("Left")) { this.Left = true; }
            }
        }
        public override string ToString()
        {
            string result = "";
            if (this.Top) { result += "_Top"; }
            if (this.Right) { result += "_Right"; }
            if (this.Bottom) { result += "_Bottom"; }
            if (this.Left) { result += "_Left"; }
            return result;
        }
    }
}
