namespace Mazes
{
	public static class EmptyMazeTask
	{
        public static void MoveOut(Robot robot, int width, int height)
        {
            int widthToZero = width - 2, heightToZero = height - 2;
            SquareMove(robot, ref widthToZero, ref heightToZero);
        }

        public static void SquareMove(Robot robot, ref int widthToZero, ref int heightToZero)
        {
            while (widthToZero != 1 || heightToZero != 1)
                SquareMoveHelp(robot, ref widthToZero, ref heightToZero);
        }

        public static void GoRight(Robot robot, ref int widthToZero)
        {
            --widthToZero;
            robot.MoveTo(Direction.Right);
        }

        public static void GoDown(Robot robot, ref int heightToZero)
        {
            --heightToZero;
            robot.MoveTo(Direction.Down);
        }

        public static void SquareMoveHelp(Robot robot, ref int widthToZero, ref int heightToZero)
        {
            if (widthToZero != 1)
                GoRight(robot, ref widthToZero);
            if (heightToZero != 1)
                GoDown(robot, ref heightToZero);
        }
    }
}
