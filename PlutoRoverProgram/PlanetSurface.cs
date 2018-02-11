using System;
namespace PlutoRoverProgram
{
    public class PlanetSurface
    {
        public string[,] Topography { get; set; }

        public PlanetSurface(string[,] topography)
        {
            this.Topography = topography;
        }

        public int peekNextXCoordinate(int currentXCoordinate)
        {
            if (currentXCoordinate == Topography.GetLength(0) - 1)
            {
                return 0;
            }
            else
            {
                return currentXCoordinate + 1;
            }
        }

        public int peekNextYCoordinate(int currentYCoordinate)
        {
            if (currentYCoordinate == Topography.GetLength(1) - 1)
            {
                return 0;
            }
            else
            {
                return currentYCoordinate + 1;
            }
        }

        public int peekPrevXCoordinate(int currentXCoordinate)
        {
            if (currentXCoordinate == 0)
            {
                return Topography.GetLength(0) - 1;
            }
            else
            {
                return currentXCoordinate - 1;
            }
        }

        public int peekPrevYCoordinate(int currentYCoordinate)
        {
            if (currentYCoordinate == 0)
            {
                return Topography.GetLength(1) - 1;
            }
            else
            {
                return currentYCoordinate - 1;
            }
        }
    }
}
