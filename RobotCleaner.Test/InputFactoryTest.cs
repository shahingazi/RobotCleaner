using System;
using Xunit;
using RobotCleaner.Logic;


namespace RobotCleaner.Test
{

    [Trait("Category", "InputCommand")]
    public class InputFactoryTest
    {
        private readonly InputFactory _inputFactory;

        public InputFactoryTest()
        {
            _inputFactory = new InputFactory();
        }

        [Fact]
        public void CreateInputFactoryWithTwoCommand()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }


        [Fact]
        public void CreateInputFactoryWithFourCommand()
        {
            _inputFactory.AddCommand("4");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }

        [Fact]
        public void CreateInputFactoryWithZeroCommand()
        {
            _inputFactory.AddCommand("0");
            _inputFactory.AddCommand("10 22");

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }

        [Fact]
        public void CreateInputFactoryWithThousandCommand()
        {
            _inputFactory.AddCommand("10000");
            _inputFactory.AddCommand("10 22");

            for (var i = 0; i < 10000; i++)
            {
                _inputFactory.AddCommand($"{i} {i}");
            }

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }


        [Fact]
        public void CreateInputFactoryWithMinusCommand()
        {
            _inputFactory.AddCommand("-3");
            _inputFactory.AddCommand("10 22");

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }

        [Fact]
        public void CreateInputFactoryWithMoreThenTenThousandCommand()
        {
            _inputFactory.AddCommand("20000");
            _inputFactory.AddCommand("10 22");
            for (var i = 0; i < 20000; i++)
            {
                _inputFactory.AddCommand($"{i} {i}");
            }

            Assert.True(_inputFactory.IsCommandAddedComplete);
        }


        [Fact]
        public void CreateInputFactoryCheckCoordinateIsCorrect()
        {
            _inputFactory.AddCommand("20000");
            _inputFactory.AddCommand("10 22");
            
            Assert.Equal(10, _inputFactory.CommandSet.StartPosition.Xaxis);
            Assert.Equal(22, _inputFactory.CommandSet.StartPosition.Yaxis);
        }

        [Fact]
        public void CreateInputFactoryCheckStepCommandCorrect()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("N 1");

            Assert.Equal(2, _inputFactory.CommandSet.MovementCommands.Count);
        }

        [Fact]
        public void CreateInputFactoryCheckMinStepIsCorrect()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E -3");
            _inputFactory.AddCommand("N 1");

            var command = _inputFactory.CommandSet.MovementCommands[0];

            Assert.Equal(1, command.NumberOfSteps);
        }

        [Fact]
        public void CreateInputFactoryCheckMaxStepIsCorrect()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 999999");
            _inputFactory.AddCommand("N 1");

            var command = _inputFactory.CommandSet.MovementCommands[0];

            Assert.Equal(99999, command.NumberOfSteps);
        }


        [Fact]
        public void CreateInputFactoryNullCheckWithCompleteInputSet()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            var commandSet = _inputFactory.GetCommandSet(); 
            Assert.Null(commandSet);
        }

        [Fact]
        public void CreateInputFactoryNotNullCheckWithCompleteInputSet()
        {
            _inputFactory.AddCommand("2");
            _inputFactory.AddCommand("10 22");
            _inputFactory.AddCommand("E 2");
            _inputFactory.AddCommand("E 2");
            var commandSet = _inputFactory.GetCommandSet();
            Assert.NotNull(commandSet);
        }
    }
}
