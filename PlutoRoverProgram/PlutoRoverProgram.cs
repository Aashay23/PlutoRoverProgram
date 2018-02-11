using System;
namespace PlutoRoverProgram
{
    public class PlutoRoverProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pluto Rover program...");

            Console.Write("Enter World Max X: ");
            int XMax = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter World Max Y: ");
            int YMax = Convert.ToInt32(Console.ReadLine());

            string[,] surface = new string[XMax, YMax];
            PlanetSurface ps = new PlanetSurface(surface);

            Console.Write("Would you like to place an obstacle? (y/n)");
            string reply = Console.ReadLine().ToLower();
            if (reply == "y")
            {
                Console.Write("Enter Obstacle X coordinate: ");
                int obsX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Obstacle Y coordinate: ");
                int obsY = Convert.ToInt32(Console.ReadLine());

                ps.Topography[obsX, obsY] = Rover.ObstacleLocation;
            }

            Console.Write("Enter initial rover X coordinate: ");
            var initX = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter initital rover Y coordinate: ");
            var initY = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter heading direction(ex: N, E, W or, S): ");
            var initDir = Console.ReadLine().ToUpper();
           
            Rover r = new Rover(initX, initY, initDir, ps);

            Console.WriteLine("Rover at: " + r.XCoordinate + "-" + r.YCoordinate + "-" + r.DirectionFacing);
            Console.Write("Enter rover movement instructions(ex: F, B, L, R): ");
            var input = Console.ReadLine().ToUpper();
            r.ExecuteCommand(input);
            Console.WriteLine("New rover position : " + r.XCoordinate + "-" + r.YCoordinate + "-" + r.DirectionFacing + " Message: " + r.Message);
        }
    }
}
