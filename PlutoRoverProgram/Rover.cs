using System;
namespace PlutoRoverProgram
{
    public class Rover
    {
        public const string FacingNorth = "N";
        public const string FacingEast = "E";
        public const string FacingWest = "W";
        public const string FacingSouth = "S";

        public const char Forward = 'F';
        public const char Backward = 'B';
        public const char Left = 'L';
        public const char Right = 'R';


        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string DirectionFacing { get; set; }

        public Rover()
        {
            this.XCoordinate = 0;
            this.YCoordinate = 0;
            this.DirectionFacing = FacingNorth;
        }

        public Rover(int x, int y, string direction)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
            this.DirectionFacing = direction;

        }

        public void ExecuteCommand(string instructions)
        {
            foreach (var command in instructions)
            {
                switch (command)
                {
                    case Forward:
                        moveRoverForward();
                        break;
                    case Backward:
                        moveRoverBackward();
                        break;
                    case Left:
                        turnRoverLeft();
                        break;
                    case Right:
                        turnRoverRight();
                        break;
                    default:
                        break;
                }
            }
        }

        private void moveRoverForward()
        {
            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.YCoordinate += 1;
                    break;
                case FacingEast:
                    this.XCoordinate += 1;
                    break;
                case FacingWest:
                    this.XCoordinate -= 1;
                    break;
                case FacingSouth:
                    this.YCoordinate -= 1;
                    break;
                default:
                    break;
            }
        }

        private void moveRoverBackward()
        {
            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.YCoordinate -= 1;
                    break;
                case FacingEast:
                    this.XCoordinate -= 1;
                    break;
                case FacingWest:
                    this.XCoordinate += 1;
                    break;
                case FacingSouth:
                    this.YCoordinate += 1;
                    break;
                default:
                    break;
            }
        }

        private void turnRoverLeft()
        {
            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.DirectionFacing = FacingWest;
                    break;
                case FacingEast:
                    this.DirectionFacing = FacingNorth;
                    break;
                case FacingWest:
                    this.DirectionFacing = FacingSouth;
                    break;
                case FacingSouth:
                    this.DirectionFacing = FacingEast;
                    break;
                default:
                    break;
            }
        }

        private void turnRoverRight()
        {
            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.DirectionFacing = FacingEast;
                    break;
                case FacingEast:
                    this.DirectionFacing = FacingSouth;
                    break;
                case FacingWest:
                    this.DirectionFacing = FacingNorth;
                    break;
                case FacingSouth:
                    this.DirectionFacing = FacingWest;
                    break;
                default:
                    break;
            }
        }
    }
}
