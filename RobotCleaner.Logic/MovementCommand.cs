namespace RobotCleaner.Logic
{
    internal class MovementCommand
    {
        internal Direction Direction { get; set; }
        internal int NumberOfSteps { get; set; }
    }

    public enum Direction
    {
        North,
        South,
        East,
        West,
        Unknown
    }
}