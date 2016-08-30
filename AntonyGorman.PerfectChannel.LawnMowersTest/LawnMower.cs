using System;

namespace AntonyGorman.PerfectChannel.LawnMowersTest
{
    public class LawnMower
    {
        public LawnMower(Position position, Orientation orientation)
        {
            Position = position;
            Orientation = orientation;
        }

        public Position Position { get; private set; }
        public Orientation Orientation { get; private set; }
        public string Output => $"{Position} {Orientation}";

        public static LawnMower CreateAt(string positionAndOrientation)
        {
            var positionAndOrientationParts = positionAndOrientation.Split(' ');

            if (positionAndOrientationParts.Length != 3)
            {
                throw new ArgumentException(
                    "The positionAndOrientation string can contain only the X, Y and Orientation strings separated by a space.",
                    nameof(positionAndOrientation));
            }

            return new LawnMower(PositionFor(positionAndOrientationParts[0], positionAndOrientationParts[1]),
                Orientation.Matching(positionAndOrientationParts[2]));
        }

        private static Position PositionFor(string positionX, string positionY)
        {
            return new Position(CoordinateFor(positionX), CoordinateFor(positionY));
        }

        private static int CoordinateFor(string part)
        {
            int position;

            if (!int.TryParse(part, out position) || position < 0)
            {
                throw new ArgumentException($"\"{part}\" is not part of a valid position.", nameof(part));
            }

            return position;
        }

        public void ExecuteMoves(string input)
        {
            //It wasn't clear from the spec whether I needed to take the Lawn boundaries into account
            //the simplest implementation that passes the required tests doesn't need to so I went with that, Antony.

            foreach (var command in input.ToUpper())
            {
                if (command.Equals('M'))
                {
                    Position = Orientation.Move(Position);
                }
                else if (command.Equals('L'))
                {
                    Orientation = Orientation.Left();
                }
                else if (command.Equals('R'))
                {
                    Orientation = Orientation.Right();
                }
            }
        }
    }
}