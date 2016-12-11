namespace RobotCleaner.Logic
{
    public class Robot
    {
        private readonly CommandSet _commandSet;
        internal Coordinate Position { get; set; }
        private readonly Coordinate _topBound;
        private readonly Coordinate _bottomBound;
        private readonly IReportGenarator _reportGenarator;
        private readonly IRobotCleaner _robotCleaner;

        public Robot(CommandSet commandSet, IReportGenarator reportGenarator) :
            this(commandSet, reportGenarator, null, null, null)
        { }

        public Robot(CommandSet commandSet, IReportGenarator reportGenarator, IRobotCleaner robotCleaner,
            Coordinate topBound, Coordinate bottomBound)
        {
            _commandSet = commandSet;
            _reportGenarator = reportGenarator;
            _topBound = topBound;
            _bottomBound = bottomBound;
            Position = commandSet.StartPosition;
            _robotCleaner = robotCleaner;

        }


        public void ExecuteCommand()
        {
            RegisterIntialPlace(Position);

            foreach (var command in _commandSet.MovementCommands)
            {
                for (var i = 0; i < command.NumberOfSteps; i++)
                {
                    MoveRobot(command);
                }
            }

        }

        private void RegisterIntialPlace(Coordinate position)
        {
            _robotCleaner?.RegisterUniquePlace(Position);
        }

        private void MoveRobot(MovementCommand command)
        {
            switch (command.Direction)
            {
                case Direction.North:
                    Position = new Coordinate(Position.Xaxis, Position.Yaxis + 1);
                    break;
                case Direction.South:
                    Position = new Coordinate(Position.Xaxis, Position.Yaxis - 1);
                    break;
                case Direction.East:
                    Position = new Coordinate(Position.Xaxis + 1, Position.Yaxis);
                    break;
                case Direction.West:
                    Position = new Coordinate(Position.Xaxis - 1, Position.Yaxis);
                    break;

            }

            Position.Validate(_topBound, _bottomBound);
            _robotCleaner?.RegisterUniquePlace(Position);
        }

        public string Print()
        {
            return _reportGenarator == null ? "=> Cleaned: unknown" : _reportGenarator.Print();
        }
    }
}