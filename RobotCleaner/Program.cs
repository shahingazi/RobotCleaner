using System;
using RobotCleaner.Logic;

namespace RobotCleaner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputFactory = new InputFactory();

            while (!inputFactory.IsCommandAddedComplete)
            {
                inputFactory.AddCommand(Console.ReadLine());
            }

            var robotCleaner = new RobotCleanerAlgorithm();
            var genarator = new ReportGenarator(robotCleaner);
            var robot = new Robot(inputFactory.GetCommandSet(), genarator, robotCleaner,
                new Coordinate(7, 7), new Coordinate(0, 0));

            robot.ExecuteCommand();

            Console.WriteLine(robot.Print());
            Console.ReadKey();
        }
    }


}
