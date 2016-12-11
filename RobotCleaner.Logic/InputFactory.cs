using System.Collections.Generic;

namespace RobotCleaner.Logic
{
    public class InputFactory
    {
        private const int MinStep = 1;
        private const int MaxStep = 99999;
        private readonly List<string> _commandList;
        internal readonly CommandSet CommandSet;

        public InputFactory()
        {
            _commandList = new List<string>();
            CommandSet = new CommandSet();
        }

        public void AddCommand(string cmd)
        {
            if (IsCommandAddedComplete) return;

            switch (_commandList.Count)
            {
                case 0:
                    SetNumberOfCommand(cmd);
                    break;
                case 1:
                    SetStartCoordinates(cmd);
                    break;
                default:
                    CommandSet.MovementCommands.Add(GetAndParseCommand(cmd));
                    break;
            }

            _commandList.Add(cmd);
        }

        private MovementCommand GetAndParseCommand(string cmd)
        {
            var command = new MovementCommand();
            var result = cmd.Split(' ');
            if (result.Length <= 1) return command;

            switch (result[0])
            {
                case "N":
                    command.Direction = Direction.North;
                    break;
                case "S":
                    command.Direction = Direction.South;
                    break;
                case "E":
                    command.Direction = Direction.East;
                    break;
                case "W":
                    command.Direction = Direction.West;
                    break;
                default:
                    command.Direction = Direction.Unknown;
                    break;
            }

            command.NumberOfSteps = int.Parse(result[1]);

            if (command.NumberOfSteps < MinStep)
                command.NumberOfSteps = MinStep;

            if (command.NumberOfSteps > MaxStep)
                command.NumberOfSteps = MaxStep;

            return command;
        }

        private void SetStartCoordinates(string cmd)
        {
            var result = cmd.Split(' ');
            if (result.Length <= 1) return;
            var xaxis = int.Parse(result[0]);
            var yaxis = int.Parse(result[1]);
            CommandSet.StartPosition = new Coordinate(xaxis, yaxis);
        }

        private void SetNumberOfCommand(string cmd)
        {
            CommandSet.NumberOfCommands = int.Parse(cmd);

            if (CommandSet.NumberOfCommands < 0)
                CommandSet.NumberOfCommands = 0;

            if (CommandSet.NumberOfCommands > 10000)
                CommandSet.NumberOfCommands = 10000;
        }

        public bool IsCommandAddedComplete => (CommandSet.NumberOfCommands + 2 == _commandList.Count);

        public CommandSet GetCommandSet()
        {
            return IsCommandAddedComplete ? CommandSet : null;
        }
    }
}