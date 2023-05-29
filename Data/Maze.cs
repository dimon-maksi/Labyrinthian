namespace Labyrinthian.Data
{
    public class Maze
    {
        public Cell[,] map;
        public int Size { get; set; }
        private Random random;

        public Maze()
        {
            Size = 10;
            random = new Random();
        }

        public Maze(int Size)
        {
            this.Size = Size;
            random = new Random();
        }

        public void Generate()
        {
            map = new Cell[Size, Size];
            initialize();
            fill();
        }

        private void initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    map[i, j] = new Cell();
                }
            }
        }

        private void fill()
        {
            map[(int)Size / 2 - 2, 0].OpenWay("Left");
            map[(int)Size / 2, Size - 1].OpenWay("Right");
            Point start = new Point(0, 0);
            VisitCell(start);
        }

        private void VisitCell(Point cell)
        {
            map[cell.Y, cell.X].IsFilled = true;

            string[] directions = { "Top", "Right", "Bottom", "Left" };
            directions = directions.OrderBy(x => random.Next()).ToArray();

            foreach (var direction in directions)
            {
                Point neighbor = GetNeighbor(cell, direction);

                if (IsValidCell(neighbor) && !map[neighbor.Y, neighbor.X].IsFilled)
                {
                    OpenPassage(cell, neighbor);
                    VisitCell(neighbor);
                }
            }
        }

        private Point GetNeighbor(Point cell, string direction)
        {
            int neighborY = cell.Y;
            int neighborX = cell.X;

            switch (direction)
            {
                case "Top":
                    neighborY--;
                    break;
                case "Right":
                    neighborX++;
                    break;
                case "Bottom":
                    neighborY++;
                    break;
                case "Left":
                    neighborX--;
                    break;
            }

            return new Point(neighborY, neighborX);
        }

        private bool IsValidCell(Point cell)
        {
            return cell.Y >= 0 && cell.Y < Size && cell.X >= 0 && cell.X < Size;
        }

        private void OpenPassage(Point current, Point neighbor)
        {
            int deltaY = neighbor.Y - current.Y;
            int deltaX = neighbor.X - current.X;

            if (deltaY == -1)
            {
                map[current.Y, current.X].OpenWay("Top");
                map[neighbor.Y, neighbor.X].OpenWay("Bottom");
            }
            else if (deltaX == 1)
            {
                map[current.Y, current.X].OpenWay("Right");
                map[neighbor.Y, neighbor.X].OpenWay("Left");
            }
            else if (deltaY == 1)
            {
                map[current.Y, current.X].OpenWay("Bottom");
                map[neighbor.Y, neighbor.X].OpenWay("Top");
            }
            else if (deltaX == -1)
            {
                map[current.Y, current.X].OpenWay("Left");
                map[neighbor.Y, neighbor.X].OpenWay("Right");
            }
        }
    }
}
