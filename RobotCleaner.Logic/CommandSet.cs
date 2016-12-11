using System.Collections.Generic;

namespace RobotCleaner.Logic
{
    public class CommandSet
    {
        public CommandSet()
        {
            MovementCommands = new List<MovementCommand>();
        }
        internal Coordinate StartPosition { get; set; }
        internal List<MovementCommand> MovementCommands { get; set; }

     

        public int NumberOfCommands { get; set; }

    }
}