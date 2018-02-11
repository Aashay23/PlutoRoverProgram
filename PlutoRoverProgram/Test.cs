using NUnit.Framework;
using System;
namespace PlutoRoverProgram
{
    [TestFixture()]
    public class Test
    {
        [TestCase(0,0,"N", 100, 100)]
        [TestCase(1,23,"S", 5, 5)]
        public void Test_RoverInitialization(int xCoord, int yCoord, string direction, int surfaceXMax, int surfaceYMax)
        {
            int[,] surface = new int[surfaceXMax, surfaceYMax];
            PlanetSurface planetSurface = new PlanetSurface(surface);

            Rover rover1 = new Rover(xCoord, yCoord, direction, planetSurface);
            Assert.NotNull(rover1);
        }

        [TestCase(0, 0, "N", 5, 5, "FFFBB", 0, 1, "N")]
        [TestCase(5, 10, "E", 20, 20, "BBBFFFF", 6, 10, "E")]
        [TestCase(0, 0, "N", 100, 100, "FFRFF", 2, 2, "E")]
        [TestCase(25, 5, "S", 30, 30, "LBBBBBLFFFFFLLLR", 20, 10, "S")]
        [TestCase(0, 0, "N", 3, 3, "FFFFLB", 1, 1, "W")]
        [TestCase(10, 7, "N", 11, 11, "FFFFFRFFBLB", 0, 0, "N")]
        public void Test_MovingRoverFromInstructions(int xCoord, int yCoord, string direction, int surfaceXMax, int surfaceYMax, string instructions, int finalXCoord, int finalYCoord, string finalDirection)
        {
            int[,] surface = new int[surfaceXMax, surfaceYMax];
            PlanetSurface planetSurface = new PlanetSurface(surface);

            Rover plutoRover = new Rover(xCoord, yCoord, direction, planetSurface);
            plutoRover.ExecuteCommand(instructions);

            Rover finalLocationOfPlutoRover = new Rover(finalXCoord, finalYCoord, finalDirection, planetSurface);

            Assert.IsTrue((plutoRover.XCoordinate == finalLocationOfPlutoRover.XCoordinate && 
                           plutoRover.YCoordinate == finalLocationOfPlutoRover.YCoordinate && 
                           plutoRover.DirectionFacing == finalLocationOfPlutoRover.DirectionFacing));
        }
    }
}
