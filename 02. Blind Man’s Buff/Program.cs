namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            int blindManRow = 0;
            int blindManCol = 0;
            int opponentsTouched = 0;
            int moves = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] col = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                    if (col[cols] == "B")
                    {
                        blindManRow = rows;
                        blindManCol = cols;
                        matrix[rows, cols] = "-";
                    }
                }
            }
            string command = string.Empty;
            
            while ((command = Console.ReadLine()) != "Finish")
            {
                switch (command)
                {
                    case "up":
                        if (BoundsOrObstacleCheck(blindManRow -1, blindManCol, matrix))
                        {
                            blindManRow--;
                            (opponentsTouched, moves) = PositionAction(blindManRow, blindManCol, matrix, opponentsTouched, moves);
                        }
                        
                        break;
                    case "down":
                        if (BoundsOrObstacleCheck(blindManRow + 1, blindManCol, matrix))
                        {
                            blindManRow++;
                            (opponentsTouched, moves) = PositionAction(blindManRow, blindManCol, matrix, opponentsTouched, moves);
                        }
                        
                        break;
                    case "right":
                        if (BoundsOrObstacleCheck(blindManRow, blindManCol+1, matrix))
                        {
                            blindManCol++;
                            (opponentsTouched, moves) = PositionAction(blindManRow, blindManCol, matrix, opponentsTouched, moves);
                        }
                       
                        break;
                    case "left":
                        if (BoundsOrObstacleCheck(blindManRow, blindManCol-1, matrix))
                        {
                            blindManCol--;
                            (opponentsTouched, moves) = PositionAction(blindManRow, blindManCol, matrix, opponentsTouched, moves);
                        }
                        
                        break;

                }
                if (opponentsTouched == 3)
                {
                    break;
                }
            }
            matrix[blindManRow, blindManCol] = "B";
            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {opponentsTouched} Moves made: {moves}");

        }
        public static bool BoundsOrObstacleCheck(int rowIndex, int colIndex, string[,] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
            {
                if (matrix[rowIndex, colIndex] == "O")
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Tuple<int,int> PositionAction(int row, int col, string[,] matix , int touched, int moves)
        {
            if (matix[row,col] == "P")
            {
                touched++;
                moves++;
                matix[row,col] = "-";
            }
            else if (matix[row,col] == "-")
            {
                moves++;
            }
            return Tuple.Create(touched, moves);
        }
    }
}