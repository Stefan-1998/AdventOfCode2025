using System.Data;
using System.Drawing;
using System.Numerics;

namespace Advent2025.Day9
{
    public class MovieTheater
    {
        public class TileAreaMaximizer
        {
            private Point[]_redTiles=Array.Empty<Point>();
            public Dictionary <Rectangle, BigInteger >RectangleAreaMap;
            public TileAreaMaximizer(string[] input)
            {
               _redTiles = new Point[input.Length];
               for(int i=0; i< input.Length; i++)
                {
                    var xPostion = int.Parse(input[i].Split(',')[0]);
                    var yPostion = int.Parse(input[i].Split(',')[1]);
                    _redTiles[i]=new Point(xPostion,yPostion);
                }
                RectangleAreaMap = [];
                FillRectangleAreaMap();
            }           
            private void FillRectangleAreaMap()
            {
                foreach(var firstTile in _redTiles)
                {
                    foreach(var secondTile in _redTiles)
                    {
                        if(firstTile == secondTile)
                        {
                            continue;
                        }
                        var rect= new Rectangle(firstTile, secondTile);
                        RectangleAreaMap.Add(rect,rect.Area);
                    }
                }
            }
        }

        public record Point(long X, long Y);
        public class Rectangle
        {
            public BigInteger Area => CalculateArea();
            private Point A;
            private Point B;
            public Rectangle(Point a, Point b)
            {
                if(a == b ){throw new ArgumentException();}
                A = a;
                B = b;
            }
            private BigInteger CalculateArea()
            {
                return new BigInteger(Math.Abs(B.Y -A.Y)+1) * new BigInteger(Math.Abs(B.X -A.X)+1);
            }
        }
    }
}

