
namespace Advent2025.Day7
{
    public static class Laboratories
    {
        public static long GetAmountOfSplitsInAllTimeLines(string[] input)
        {
            var filteredInput = FilterNotNeededSplitters(input);
            filteredInput = filteredInput.OrderBy(point => point.Y).ThenByDescending(point => point.X).ToHashSet();

            long[]timeLines= new long[input[0].Count()];
            timeLines[filteredInput.ElementAt(0).X]=1;
            foreach(var splitter in filteredInput.Skip(1))
            {
                if(timeLines[splitter.X]>=1)
                {
                timeLines[splitter.X+1]+= timeLines[splitter.X];
                timeLines[splitter.X-1]+=timeLines[splitter.X];
                timeLines[splitter.X]=0;
                }
            }

            return timeLines.Sum();
        }
        public static long GetAmountOfSplits(string[] input)
        {
            var sPosition = input[0].IndexOf('S');
            HashSet<int> rays = [];
            rays.Add(sPosition );
            int splitCounter = 0;

            for (int i = 1; i < input.Length; i++)
            {
                foreach (int index in AllIndexesOf(input[i], '^'))
                {
                    if (rays.Contains(index))
                    {
                        rays.Remove(index);
                        rays.Add(index + 1);
                        rays.Add(index - 1);
                        splitCounter++;
                    }
                }
            }

            return splitCounter;
        }
        private static HashSet<(int Y, int X)> FilterNotNeededSplitters(string[] input)
        {
            HashSet<(int Y, int X)> splitters = GetSplitters(input);

            //if a splitter has no  splitter on the left or right above it, it can't be reached 
            splitters.OrderByDescending(splitter => splitter.Y).ThenBy(splitter => splitter.X);
            foreach (var splitter in splitters)
            {
                if (IsFirstSplitter(splitter))
                {
                    break;
                }
                if (!IsSplitterInUse(splitter, input))
                {
                    splitters.Remove(splitter);
                }
            }
            return splitters;
        }

        private static bool IsSplitterInUse((int Y, int X) splitter, string[] input)
        {
            for(int i = splitter.Y-1 ; i >=0; i--)
            {
                if(input[i][splitter.X-1]== '^' ||input[i][splitter.X-1]== 'S')
                {
                    return true;
                }
                if(input[i][splitter.X+1]== '^' ||input[i][splitter.X+1]== 'S')
                {
                    return true;
                }
                if(input[i][splitter.X]== '^' )
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsFirstSplitter((int Y, int X) splitter)
        {
            return splitter.Y == 0;
        }

        private static HashSet<(int Y, int X)> GetSplitters(string[] input)
        {
            HashSet<(int Y, int X)> splitters = [];
            for (int i = 0; i < input.Length; i++)
            {
                foreach (int index in AllIndexesOf(input[i], '^'))
                {
                    splitters.Add((i, index));
                }
            }
            splitters.Add((0, input[0].IndexOf('S')));

            return splitters;
        }

        private static IEnumerable<int> AllIndexesOf(string str, char character)
        {
            int minIndex = str.IndexOf(character);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(character, minIndex + 1);
            }
        }
    }
}
