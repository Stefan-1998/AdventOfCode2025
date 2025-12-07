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
        }

        public class PaperRollManager
        {
            private PaperRollGrid _grid;
            private Dictionary<string, List<string>> paperRollNeighbourMap;

            public PaperRollManager(PaperRollGrid grid)
            {
                _grid = grid ?? throw new ArgumentNullException();
                paperRollNeighbourMap = new();
                CreateConnectionMap();
            }

            private void CreateConnectionMap()
            {
                foreach (var roll in _grid.PaperRolls)
                {
                    var closeRollIds = _grid
                        .PaperRolls.Where(neibourRoll => neibourRoll.IsCloseTo(roll))
                        .Select(neibourRoll => neibourRoll.ID);

                    paperRollNeighbourMap.Add(roll.ID, closeRollIds.ToList());
                }
            }

            public List<string> GetAmountOfAccessableRollsByForklift()
            {
                return paperRollNeighbourMap
                    .Where(entry => entry.Value.Count() <= 3)
                    .Select(x => x.Key)
                    .ToList();
            }

            public void RemoveRolls(List<string> idsToRemove)
            {
                var neiboursIdToAdapt = paperRollNeighbourMap
                    .Where(entry => entry.Value.Any(x => idsToRemove.Contains(x)))
                    .Select(x => x.Key)
                    .ToList()
                    .Distinct();

                foreach (var neibourRoll in neiboursIdToAdapt)
                {
                    foreach (var idToRemove in idsToRemove)
                    {
                        paperRollNeighbourMap[neibourRoll].Remove(idToRemove);
                    }
                }
                foreach (var idToRemove in idsToRemove)
                {
                    paperRollNeighbourMap.Remove(idToRemove);
                }
            }
        }

        public class PaperRoll
        {
            public readonly int XPostion;
            public readonly int YPostion;
            public readonly string ID = Guid.NewGuid().ToString();

            public PaperRoll(int x, int y)
            {
                XPostion = x;
                YPostion = y;
            }

            public bool IsCloseTo(PaperRoll roll) =>
                IsXPositionClose(roll.XPostion) && IsYPositionClose(roll.YPostion) && this != roll;

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
