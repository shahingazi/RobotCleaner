using System;

namespace RobotCleaner.Logic
{
    public class Coordinate : IComparable<Coordinate>
    {
        public Coordinate(int x, int y)
        {
            Xaxis = x;
            Yaxis = y;
        }

        internal int Xaxis { get; set; }
        internal int Yaxis { get; set; }

        public void Validate(Coordinate topBound, Coordinate bottomBound)
        {
            if (topBound != null)
            {
                if (Xaxis > topBound.Xaxis)
                    Xaxis = topBound.Xaxis;
                if (Yaxis > topBound.Yaxis)
                    Yaxis = topBound.Yaxis;

            }

            if (bottomBound != null)
            {
                if (Xaxis < bottomBound.Xaxis)
                    Xaxis = bottomBound.Xaxis;

                if (Yaxis < bottomBound.Yaxis)
                    Yaxis = bottomBound.Yaxis;
            }
        }

        public int CompareTo(Coordinate other)
        {
            if (this.Xaxis == other.Xaxis)
                return this.Yaxis.CompareTo(other.Yaxis);
            return this.Xaxis.CompareTo(other.Xaxis);

        }

        public override string ToString()
        {
            return $"{Xaxis}${Yaxis}";
        }
    }
}