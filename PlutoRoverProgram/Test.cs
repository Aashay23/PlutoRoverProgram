using NUnit.Framework;
using System;
namespace PlutoRoverProgram
{
    [TestFixture()]
    public class Test
    {
        [TestCase(0,0,"N")]
        [TestCase(1,23,"S")]
        public void Test_RoverInitialization(int xCoord, int yCoord, string direction)
        {
            Rover rover1 = new Rover(xCoord, yCoord, direction);
            Assert.NotNull(rover1);
        }

        [TestCase(0, 0, "N", "FFFBB", 0, 1, "N")]
        [TestCase(5, 10, "E", "BBBFFFF", 6, 10, "E")]
        public void Test_MovingRoverForwardAndBackwardFromInstructions(int xCoord, int yCoord, string direction, string instructions, int finalXCoord, int finalYCoord, string finalDirection)
        {
            Rover plutoRover = new Rover(xCoord, yCoord, direction);
            //string instructions = "FFFBB";
            plutoRover.ExecuteCommand(instructions);

            Rover finalLocationOfPlutoRover = new Rover(finalXCoord, finalYCoord, finalDirection);

            Assert.IsTrue((plutoRover.XCoordinate == finalLocationOfPlutoRover.XCoordinate && 
                           plutoRover.YCoordinate == finalLocationOfPlutoRover.YCoordinate && 
                           plutoRover.DirectionFacing == finalLocationOfPlutoRover.DirectionFacing));
        }
    }
}
