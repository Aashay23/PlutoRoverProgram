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

        public const string ObstacleLocation = "X";
        public const string ReceivedInstructions = "Received instructions";
        public const string MoveSuccessful = "Move successful";
        public const string ObstacleFound = "Obstacle found";

        public const char Forward = 'F';
        public const char Backward = 'B';
        public const char Left = 'L';
        public const char Right = 'R';

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string DirectionFacing { get; set; }
        public string Message { get; set; }

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
                        this.Message = moveRoverForward();
                        break;
                    case Backward:
                        this.Message = moveRoverBackward();
                        break;
                    case Left:
                        this.Message = turnRoverLeft();
                        break;
                    case Right:
                        this.Message = turnRoverRight();
                        break;
                    default:
                        break;
                }

                if(this.Message != MoveSuccessful)
                {
                    return;
                }
            }
        }

        private string moveRoverForward()
        {
            string roverMessage = MoveSuccessful;

            int nextXCoordinate = _surface.peekNextXCoordinate(this.XCoordinate);
            int prevXCoordinate = _surface.peekPrevXCoordinate(this.XCoordinate);
            int nextYCoordinate = _surface.peekNextYCoordinate(this.YCoordinate);
            int prevYCoordinate = _surface.peekPrevYCoordinate(this.YCoordinate);

            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    if(_surface.Topography[this.XCoordinate, nextYCoordinate] != ObstacleLocation)
                    {
                        this.YCoordinate = nextYCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + this.XCoordinate + "-" + nextYCoordinate;
                    }
                    break;
                case FacingEast:
                    if(_surface.Topography[nextXCoordinate, this.YCoordinate] != ObstacleLocation)
                    {
                        this.XCoordinate = nextXCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + nextXCoordinate + "-" + this.YCoordinate;
                    }
                    break;
                case FacingWest:
                    if(_surface.Topography[prevXCoordinate, this.YCoordinate] != ObstacleLocation)
                    {
                        this.XCoordinate = prevXCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + prevXCoordinate + "-" + this.YCoordinate;
                    }
                    break;
                case FacingSouth:
                    if(_surface.Topography[this.XCoordinate, prevYCoordinate] != ObstacleLocation)
                    {
                        this.YCoordinate = prevYCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + this.XCoordinate + "-" + prevYCoordinate;
                    }
                    break;
                default:
                    break;
            }

            return roverMessage;
        }

        private string moveRoverBackward()
        {
            string roverMessage = MoveSuccessful;

            int nextXCoordinate = _surface.peekNextXCoordinate(this.XCoordinate);
            int prevXCoordinate = _surface.peekPrevXCoordinate(this.XCoordinate);
            int nextYCoordinate = _surface.peekNextYCoordinate(this.YCoordinate);
            int prevYCoordinate = _surface.peekPrevYCoordinate(this.YCoordinate);

            switch (this.DirectionFacing)
            {
                case FacingNorth:
                    if(_surface.Topography[this.XCoordinate, prevYCoordinate] != ObstacleLocation)
                    {
                        this.YCoordinate = prevYCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + this.XCoordinate + "-" + prevYCoordinate;
                    }
                    break;
                case FacingEast:
                    if(_surface.Topography[prevXCoordinate, this.YCoordinate] != ObstacleLocation)
                    {
                        this.XCoordinate = prevXCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + prevXCoordinate + "-" + this.YCoordinate;
                    }
                    break;
                case FacingWest:
                    if (_surface.Topography[nextXCoordinate, this.YCoordinate] != ObstacleLocation)
                    {
                        this.XCoordinate = nextXCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + nextXCoordinate + "-" + this.YCoordinate;
                    }
                    break;
                case FacingSouth:
                    if (_surface.Topography[this.XCoordinate, nextYCoordinate] != ObstacleLocation)
                    {
                        this.YCoordinate = nextYCoordinate;
                    }else
                    {
                        roverMessage = "Obstacle found at " + this.XCoordinate + "-" + nextYCoordinate;
                    }
                    break;
                default:
                    break;
            }

            return roverMessage;
        }

        private string turnRoverLeft()
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

            return MoveSuccessful;
        }

        private string turnRoverRight()
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

            return MoveSuccessful;
        }
    }
}
