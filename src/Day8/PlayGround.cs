using System.Data;
using System.Numerics;

namespace Advent2025.Day8
{
    public class PlayGround
    {
        public class JunctionBoxGrouper
        {
            private Vector3[] _jungtionsBoxPositions;
            public Dictionary<(Vector3 FirstBoxPos, Vector3 SecondBoxPos ), float > boxDistanceMap = [];
            public JunctionBoxGrouper(string[]input)
            {
                ReadInJunctionBoxes(input);
                CalculateDistanceMap();
            }

            public long GroupBoxesSum(int pairsToConnect )
            {
                Dictionary<Vector3, List<Vector3>> circuits = [];
                foreach (Vector3 circuit in _jungtionsBoxPositions)
                {
                    circuits.Add(circuit, new List<Vector3>() { circuit });
                }

                ConnectCircuits(pairsToConnect, circuits);
                var groups = RemoveDublicateCircuits(circuits);
                return groups.ElementAt(0).Count() *
                    groups.ElementAt(1).Count() *
                    groups.ElementAt(2).Count();
            }

            private void ConnectCircuits(int pairsToConnect, Dictionary<Vector3, List<Vector3>> circuits)
            {
                var sortedConnections = boxDistanceMap
                    .OrderBy(x => x.Value)
                    .Take(pairsToConnect)
                    .ToArray();

                for (int counter = 0; counter < pairsToConnect; counter++)
                {
                    Vector3 firstBox = sortedConnections[counter].Key.FirstBoxPos;
                    Vector3 secondBox = sortedConnections[counter].Key.SecondBoxPos;

                    // Find the root circuits for both boxes
                    var firstCircuit = circuits.First(c => c.Value.Contains(firstBox)).Value;
                    var secondCircuit = circuits.First(c => c.Value.Contains(secondBox)).Value;

                    // Merge circuits if they are not already the same
                    if (firstCircuit != secondCircuit)
                    {
                        firstCircuit.AddRange(secondCircuit);
                        
                        // Update all references to the second circuit
                        foreach (var box in secondCircuit)
                        {
                            circuits[box] = firstCircuit;
                        }
                    }
                }
            }

            private static List<List<Vector3>> RemoveDublicateCircuits(Dictionary<Vector3, List<Vector3>> circuits)
            {
                // Use HashSet to efficiently remove duplicates
                var uniqueCircuits = new HashSet<string>(
                    circuits.Values
                        .Select(list => string.Join(",", 
                            list.OrderBy(box => box.X)
                                .ThenBy(box => box.Y)
                                .ThenBy(box => box.Z)
                                .Select(box => $"{box.X},{box.Y},{box.Z}")
                        ))
                );

                // Convert back to lists of Vector3
                return uniqueCircuits
                    .Select(circuitString => 
                        circuitString.Split(',')
                        .Select((coord, index) => float.Parse(coord))
                        .Chunk(3)
                        .Select(chunk => new Vector3(chunk[0], chunk[1], chunk[2]))
                        .ToList()
                    )
                    .OrderByDescending(list => list.Count)
                    .Take(3)
                    .ToList();
            }

            private void CalculateDistanceMap()
            {
                foreach (Vector3 firstBox in _jungtionsBoxPositions)
                {
                    foreach (Vector3 secondBox in _jungtionsBoxPositions)
                    {
                        if (secondBox == firstBox)
                        {
                            continue;
                        }
                        if (!boxDistanceMap.ContainsKey((firstBox, secondBox)) && !boxDistanceMap.ContainsKey((secondBox, firstBox)))
                        {
                            var distance = Vector3.Distance(firstBox, secondBox);
                            boxDistanceMap.Add((firstBox, secondBox), distance);
                        }
                    }
                }
                boxDistanceMap = boxDistanceMap.OrderBy(element => element.Value).ToDictionary();
            }

            private void ReadInJunctionBoxes(string[] input)
            {
                _jungtionsBoxPositions = new Vector3[input.Length];
                for(int i=0; i< input.Length;i++)
                {
                    var coordinates =input[i].Split(',').Select(coordinate => int.Parse(coordinate)).ToArray();
                    _jungtionsBoxPositions[i]= new Vector3(coordinates[0],coordinates[1],coordinates[2]);
                }
            }
        }
    }
}

