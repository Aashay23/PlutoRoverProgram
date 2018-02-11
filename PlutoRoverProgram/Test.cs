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
        [TestCase(0, 0, "N", "FFRFF", 2, 2, "E")]
        [TestCase(25, 5, "S", "LBBBBBLFFFFFLLLR", 20, 10, "S")]
        public void Test_MovingRoverFromInstructions(int xCoord, int yCoord, string direction, string instructions, int finalXCoord, int finalYCoord, string finalDirection)
        {
            Rover plutoRover = new Rover(xCoord, yCoord, direction);
            plutoRover.ExecuteCommand(instructions);

            Rover finalLocationOfPlutoRover = new Rover(finalXCoord, finalYCoord, finalDirection);

            Assert.IsTrue((plutoRover.XCoordinate == finalLocationOfPlutoRover.XCoordinate && 
                           plutoRover.YCoordinate == finalLocationOfPlutoRover.YCoordinate && 
                           plutoRover.DirectionFacing == finalLocationOfPlutoRover.DirectionFacing));
        }
    }
}
