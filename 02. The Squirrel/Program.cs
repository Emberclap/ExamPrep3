using System.Runtime.CompilerServices;

namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main()
        {
            int dimension = int.Parse(Console.ReadLine());
                  
            char[,] matrix = new char[dimension,dimension];

            int squirrelRowIndex = 0;
            int squirrelColIndex = 0;
            int hazelnutsCounter = 0;
            string[] commands = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                char[] col = Console.ReadLine().ToArray();


                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                    if (col[cols] == 's')
                    {
                        squirrelRowIndex = rows;
                        squirrelColIndex = cols;
                    }
                }
            }
            bool outOfTheField = false;
            bool trap = false;
            matrix[squirrelRowIndex, squirrelColIndex] = '*';
            foreach (var command in commands)
            {
                if (outOfTheField || trap || hazelnutsCounter == 3)
                {
                    break;
                }
                switch (command)
                {
                    case "up":
                        if (BoundsCheck(squirrelRowIndex - 1, squirrelColIndex, matrix))
                        {
                            squirrelRowIndex--;
                            trap = (TrapCheck(squirrelRowIndex, squirrelColIndex, matrix));
                            if(NutsCheck(squirrelRowIndex, squirrelColIndex, matrix))
                            {
                                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                                hazelnutsCounter++;
                            }
                        }
                        else { outOfTheField = true; break; }
                        
                        break;
                    case "down":
                        if (BoundsCheck(squirrelRowIndex + 1, squirrelColIndex, matrix))
                        {
                            squirrelRowIndex++;
                            trap = (TrapCheck(squirrelRowIndex, squirrelColIndex, matrix));
                            if (NutsCheck(squirrelRowIndex, squirrelColIndex, matrix))
                            {
                                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                                hazelnutsCounter++;
                            }
                        }
                        else { outOfTheField = true; break; }
                        break;
                    case "right":
                        if (BoundsCheck(squirrelRowIndex, squirrelColIndex + 1, matrix))
                        {
                            squirrelColIndex++;
                            trap = (TrapCheck(squirrelRowIndex, squirrelColIndex, matrix));
                            if (NutsCheck(squirrelRowIndex, squirrelColIndex, matrix))
                            {
                                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                                hazelnutsCounter++;
                            }
                        }
                        else { outOfTheField = true; break; }
                        break;
                    case "left":
                        if (BoundsCheck(squirrelRowIndex, squirrelColIndex - 1, matrix))
                        {
                            squirrelColIndex--;
                            trap = (TrapCheck(squirrelRowIndex, squirrelColIndex, matrix));
                            if (NutsCheck(squirrelRowIndex, squirrelColIndex, matrix))
                            {
                                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                                hazelnutsCounter++;
                            }
                        }
                        else { outOfTheField = true; break; }
                        break;
                }
                

            }
            matrix[squirrelRowIndex, squirrelColIndex] = 's';
            if (outOfTheField)
            {
                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                Console.WriteLine("The squirrel is out of the field.");
            }
            else if (trap)
            {
                matrix[squirrelRowIndex, squirrelColIndex] = '*';
                Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            }
            else if (hazelnutsCounter == 3)
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
            }
            else
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCounter}");
        }


        public static bool BoundsCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < matrix.GetLength(0) && colIndex < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool TrapCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (matrix[rowIndex, colIndex] == 't')
            {
                return true;
            }
            else { return false; }
        }
        public static bool NutsCheck(int rowIndex, int colIndex, char[,] matrix)
        {
            if (matrix[rowIndex, colIndex] == 'h')
            {
                return true;
            }
            return false;
            
        }
    }
}