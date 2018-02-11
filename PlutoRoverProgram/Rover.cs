using System;
namespace PlutoRoverProgram
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string DirectionFacing { get; set; }

        public Rover()
        {
            this.XCoordinate = 0;
            this.YCoordinate = 0;
            this.DirectionFacing = "N";
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
                    case 'F':
                        moveRoverForward();
                        break;
                    case 'B':
                        moveRoverBackward();
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
                case "N":
                    this.YCoordinate += 1;
                    break;
                case "E":
                    this.XCoordinate += 1;
                    break;
                case "W":
                    this.XCoordinate -= 1;
                    break;
                case "S":
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
                case "N":
                    this.YCoordinate -= 1;
                    break;
                case "E":
                    this.XCoordinate -= 1;
                    break;
                case "W":
                    this.XCoordinate += 1;
                    break;
                case "S":
                    this.YCoordinate += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
