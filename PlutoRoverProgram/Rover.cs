using System;
namespace PlutoRoverProgram
{
    public class Rover
    {
        private PlanetSurface _surface;

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

        //public Rover(int x, int y, string direction)
        //{
        //    this.XCoordinate = x;
        //    this.YCoordinate = y;
        //    this.DirectionFacing = direction;
        //}

        public Rover(int x, int y, string direction, PlanetSurface surface)
        {
            this.XCoordinate = x;
            this.YCoordinate = y;
            this.DirectionFacing = direction;

            _surface = surface;
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
            int nextXCoordinate = _surface.peekNextXCoordinate(this.XCoordinate);
            int prevXCoordinate = _surface.peekPrevXCoordinate(this.XCoordinate);
            int nextYCoordinate = _surface.peekNextYCoordinate(this.YCoordinate);
            int prevYCoordinate = _surface.peekPrevYCoordinate(this.YCoordinate);

            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.YCoordinate = nextYCoordinate;
                    break;
                case FacingEast:
                    this.XCoordinate = nextXCoordinate;
                    break;
                case FacingWest:
                    this.XCoordinate = prevXCoordinate;
                    break;
                case FacingSouth:
                    this.YCoordinate = prevYCoordinate;
                    break;
                default:
                    break;
            }
        }

        private void moveRoverBackward()
        {
            int nextXCoordinate = _surface.peekNextXCoordinate(this.XCoordinate);
            int prevXCoordinate = _surface.peekPrevXCoordinate(this.XCoordinate);
            int nextYCoordinate = _surface.peekNextYCoordinate(this.YCoordinate);
            int prevYCoordinate = _surface.peekPrevYCoordinate(this.YCoordinate);

            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    this.YCoordinate = prevYCoordinate;
                    break;
                case FacingEast:
                    this.XCoordinate = prevXCoordinate;
                    break;
                case FacingWest:
                    this.XCoordinate = nextXCoordinate;
                    break;
                case FacingSouth:
                    this.YCoordinate = nextYCoordinate;
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
