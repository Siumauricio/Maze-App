namespace MazeGeneratorApi.Models
{
    public class MazeList
    {
        public MazeList()
        {
            this.Result = new List<PositionValue>();
        }

        public int Size { get; set; }
        public List<PositionValue> Result { get; set; }
    }

    public class PositionValue 
    {
        public PositionValue(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }
        public int X { get; set; }

        public int Y { get; set; }
        
        public int Value { get; set; }
    }
}
