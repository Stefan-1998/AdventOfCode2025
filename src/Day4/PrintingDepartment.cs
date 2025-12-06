namespace Advent2025.Day4
{
    public class PrintingDepartment
    {
        public class PaperRollGrid
        {
            public readonly int Height;
            public readonly int Width;
            public readonly List<PaperRoll> PaperRolls;

            public PaperRollGrid(string[] map)
            {
                Height = map.Length;
                Width = map[0].Length;
                PaperRolls = new List<PaperRoll>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (map[y][x] == '@')
                            PaperRolls.Add(new PaperRoll(x, y));
                    }
                }
            }

            public IEnumerable<PaperRoll> AccessableByForkLift()
            {
                foreach (PaperRoll roll in PaperRolls)
                {
                    if (
                        PaperRolls
                            .Where(entries => entries.IsCloseTo(roll) && entries != roll)
                            .Count() < 4
                    )
                        yield return roll;
                }
            }
        }

        public class PaperRoll
        {
            public readonly int XPostion;
            public readonly int YPostion;

            public PaperRoll(int x, int y)
            {
                XPostion = x;
                YPostion = y;
            }

            public bool IsCloseTo(PaperRoll roll) =>
                IsXPositionClose(roll.XPostion) && IsYPositionClose(roll.YPostion);

            private bool IsXPositionClose(int x)
            {
                return x + 1 == XPostion || x - 1 == XPostion || x == XPostion;
            }

            private bool IsYPositionClose(int y)
            {
                return y + 1 == YPostion || y - 1 == YPostion || y == YPostion;
            }
        }
    }
}
