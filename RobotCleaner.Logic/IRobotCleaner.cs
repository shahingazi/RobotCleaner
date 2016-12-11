using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Logic
{
    public interface IRobotCleaner
    {
        void RegisterUniquePlace(Coordinate coordinate);
        int Count();
    }
}
