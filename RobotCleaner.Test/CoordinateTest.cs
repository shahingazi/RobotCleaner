using System;
using RobotCleaner.Logic;
using Xunit;

namespace RobotCleaner.Test
{
    public class CoordinateTest
    {
        [Fact]
        public void CreateCoordinateWithCorrectValue()
        {
            var cordinate = new Coordinate(500, 200);
            Assert.Equal(500, cordinate.Xaxis);
            Assert.Equal(200, cordinate.Yaxis);
        }

        [Fact]
        public void CompareCoordinateSmallvsLargerReturnLarge()
        {
            var cordinate1 = new Coordinate(500, 200);
            var cordinate2 = new Coordinate(600, 200);
            Assert.Equal(-1, cordinate1.CompareTo(cordinate2));
        }

        [Fact]
        public void CompareCoordinateLargevsSmallReturnSmaller()
        {
            var cordinate1 = new Coordinate(800, 200);
            var cordinate2 = new Coordinate(700, 200);
            Assert.Equal(1, cordinate1.CompareTo(cordinate2));
        }
    }
}
