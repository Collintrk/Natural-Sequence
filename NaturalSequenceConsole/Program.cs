using System;
using BoardModel;

namespace NaturalSequenceConsole
{
    class Program
    {
        static Board b = new Board(19);

        static void Main(string[] args)
        {
            bool loop = true;
            //Display empty board
            displayBoard(b);

            while (loop)
            {
                //Ask user to choose a piece, x, and y coord
                Console.WriteLine("Enter the piece");
                String piece = Console.ReadLine();

                Console.WriteLine("Enter the row");
                int currentRow = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the column");
                int currentCol = int.Parse(Console.ReadLine());

                Space currentSpace = SetCurrentSpace(currentRow, currentCol);
                currentSpace.Occupied = true;

                //Calculate all legal moves
                b.MarkLegalMoves(currentSpace, piece);

                //print board again
                displayBoard(b);

                //move piece
                Console.WriteLine("Enter row to move to:");
                currentRow = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter column to move to:");
                currentCol = int.Parse(Console.ReadLine());

                bool valid = b.Grid[currentRow, currentCol].NextLegalMove;
                while (!valid)
                {
                    Console.WriteLine("Enter a valid move");
                    Console.WriteLine("Enter row to move to:");
                    currentRow = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter column to move to:");
                    currentCol = int.Parse(Console.ReadLine());

                    //if move is out of bounds, inform user
                    if (currentRow < 1 || currentRow > 17 || currentCol < 1 || currentCol > 17)
                    {
                        Console.WriteLine("Enter a valid space");
                    }
                    //otherwise check if move is valid
                    else
                    {
                        valid = b.Grid[currentRow, currentCol].NextLegalMove;
                    }
                }

                currentSpace = SetCurrentSpace(currentRow, currentCol);
                currentSpace.Occupied = true;

                //Calculate all legal moves
                b.MarkLegalMoves(currentSpace, piece);

                //print board again
                displayBoard(b);

                //Ask for loop
                //Console.WriteLine("Continue? y/n");
                //String cont = Console.ReadLine();
                //if(!cont.Contains("y"))
                //{
                //    loop = false;
                //}
            }
        }

        private static Space SetCurrentSpace(int currentRow, int currentCol)
        {
            //set space as
            return b.Grid[currentRow, currentCol];
        }

        private static bool ChooseNextmove()
        {
            Console.WriteLine("Select row to move to:");
            int RowMove = int.Parse(Console.ReadLine());

            Console.WriteLine("Select column to move to:");
            int ColumnMove = int.Parse(Console.ReadLine());

            if(b.Grid[RowMove, ColumnMove].NextLegalMove)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void displayBoard(Board b)
        {
            //print passages on first row
            Console.WriteLine("  +               +               +");

            for (int i = 17; i >= 1; i--)
            {
                for (int j = 0; j < b.Size; j++)
                {
                    //First column: print passages on Row 1 and 17
                    if(j == 0)
                    {
                        if (i == 1 || i == b.Size - 2 || i == 9)
                        {
                            Console.Write("+-");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    //Last column: Print passages on row 1 and 17
                    else if(j == b.Size - 1)
                    {
                        if(i == 1 || i == b.Size - 2 || i == 9)
                        {
                            Console.WriteLine("-+");
                        }
                        else
                        {
                            Console.WriteLine("  ");
                        }
                    }
                    //Last filled row: Don't print - after space/piece
                    else if(j == b.Size - 2)
                    {
                        //Cell is occupied by piece
                        if (b.Grid[i, j].Occupied)
                        {
                            Console.Write("&");
                        }
                        //mark all legal next moves
                        else if (b.Grid[i, j].NextLegalMove)
                        {
                            Console.Write("O");
                        }
                        //otherwise print a space marker
                        else
                        {
                            Console.Write("+");
                        }
                    }
                    //normal rows: print - after space marker
                    else
                    {
                        //Cell is occupied by piece
                        if(b.Grid[i, j].Occupied)
                        {
                            Console.Write("&-");
                        }
                        //mark space if it is a legal move
                        else if (b.Grid[i, j].NextLegalMove)
                        {
                            Console.Write("O-");
                        }
                        //otherwise print space marker
                        else
                        {
                            Console.Write("+-");
                        }
                    }

                }
            }
            //print passages on last row
            Console.WriteLine("  +               +               +");
        }
    }
    }
