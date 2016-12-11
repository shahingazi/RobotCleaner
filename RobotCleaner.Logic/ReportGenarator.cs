using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Logic
{
   public class ReportGenarator: IReportGenarator
    {
       private readonly IRobotCleaner _robotCleaner;

       public ReportGenarator(IRobotCleaner robotCleaner)
       {
           _robotCleaner = robotCleaner;
       }

       public string Print()
       {
           return $"=> Cleaned: {_robotCleaner.Count()}";
       }
    }
}
