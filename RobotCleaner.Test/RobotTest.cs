using RobotCleaner.Logic;
using Xunit;

namespace RobotCleaner.Test
{

    public class RobotTest
    {
        private readonly InputFactory _inputFactory;

        public RobotTest()
        {
            _inputFactory = new InputFactory();
        }
        [Fact]
        public void CreateRobotRobotMustCreated()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");

            var commandSet = _inputFactory.GetCommandSet();
            var robot = new Robot(commandSet, null);
            Assert.NotNull(robot);
        }

        [Fact]
        public void RunRobotWithEmptyCommmand()
        {
            _inputFactory.AddCommand("0");
            _inputFactory.AddCommand("10 22");
           
            var commandSet = _inputFactory.GetCommandSet();
            var robot = new Robot(commandSet, null);

            robot.ExecuteCommand();

            Assert.Equal(commandSet.StartPosition.Xaxis, robot.Position.Xaxis);
            Assert.Equal(commandSet.StartPosition.Yaxis, robot.Position.Yaxis);

        }

        [Fact]
        public void GenarateOutputWithEmptyCommmand()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");
            var commandSet = _inputFactory.GetCommandSet();
            IReportGenarator reportGenarator = new TestReport();
            var robot = new Robot(commandSet, reportGenarator);
            robot.ExecuteCommand();

            var output = robot.Print();

            Assert.Equal(output, "=> Cleaned: 0");
        }

        [Fact]
        public void GenarateOutputWithEmptyCommmandAndReportGenaratorIsNull()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");
            var commandSet = _inputFactory.GetCommandSet();
            IReportGenarator reportGenarator = new TestReport();
            var robot = new Robot(commandSet, null);
            robot.ExecuteCommand();

            var output = robot.Print();

            Assert.Equal(output, "=> Cleaned: unknown");
        }

        [Fact]
        public void RunRobotWithCommmandShouldMove()
        {
            _inputFactory.AddCommand("1");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("N 1");
            var commandSet = _inputFactory.GetCommandSet();
            var robot = new Robot(commandSet, null);

            robot.ExecuteCommand();

            Assert.Equal(commandSet.StartPosition.Xaxis, robot.Position.Xaxis);
            Assert.Equal(commandSet.StartPosition.Yaxis + 1, robot.Position.Yaxis);

        }

        [Fact]
        public void RunRobotWithIlegalCommmandShouldRemainInBound()
        {
            _inputFactory.AddCommand("1");
            _inputFactory.AddCommand("10000 10000");
            _inputFactory.AddCommand("N 1");
            var commandSet = _inputFactory.GetCommandSet();
            var robot = new Robot(commandSet, null,null,new Coordinate(10000,10000),new Coordinate(-10000,-10000) );

            robot.ExecuteCommand();

            Assert.Equal(commandSet.StartPosition.Xaxis, robot.Position.Xaxis);
            Assert.Equal(commandSet.StartPosition.Yaxis, robot.Position.Yaxis);

        }

        [Fact]
        public void RunRobotWithSimpleSetCommmandShouldRetunCleanedPosition()
        {
            _inputFactory.AddCommand("4");
            _inputFactory.AddCommand("0 0");
            _inputFactory.AddCommand("N 7");
            _inputFactory.AddCommand("E 7");
            _inputFactory.AddCommand("S 7");
            _inputFactory.AddCommand("W 7");
            var commandSet = _inputFactory.GetCommandSet();
            IRobotCleaner cleaner = new RobotCleanerAlgorithm();
            IReportGenarator reportGenarator = new ReportGenarator(cleaner);
            var robot = new Robot(commandSet, reportGenarator, cleaner, 
                new Coordinate(7, 7), new Coordinate(0,0));
            robot.ExecuteCommand();

            var output = robot.Print();

            Assert.Equal("=> Cleaned: 28", output);

        }
    }
}
