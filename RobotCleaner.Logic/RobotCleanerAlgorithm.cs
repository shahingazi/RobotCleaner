using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Logic
{
    public class RobotCleanerAlgorithm: IRobotCleaner
    {
        private readonly SortedSet<Coordinate> _uniquePositions; 

        public RobotCleanerAlgorithm()
        {
            _uniquePositions = new SortedSet<Coordinate>();
        }

        public void RegisterUniquePlace(Coordinate coordinate)
        {
            _uniquePositions.Add(coordinate);
        }

        public int Count()
        {
            return _uniquePositions.Count;
        }
    }
}
