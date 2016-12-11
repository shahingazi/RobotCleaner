using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCleaner.Logic;

namespace RobotCleaner.Test
{
    internal class TestReport: IReportGenarator
    {
        public string Print()
        {
            return "=> Cleaned: 0";
        }
    }
}
