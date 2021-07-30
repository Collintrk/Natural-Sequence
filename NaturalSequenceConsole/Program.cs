using System;
using BoardModel;

namespace NaturalSequenceConsole
{
    class Program
    {
        static Board b = new Board(19);

        static void Main(string[] args)
        {
            bool loop = true; https://github.com/Collintrk/Natural-Sequence.git
                                    //Display empty board
            displayBoard(b);

            while (loop)
            {
                //Ask user to choose a piece, x, and y coord
                Console.WriteLine("Enter the piece");
                String piece = Console.ReadLine();

                Space currentSpace = SetCurrentSpace();
                currentSpace.Occupied = true;

                //Calculate all legal moves
                b.MarkLegalMoves(currentSpace, piece);

                //print board again
                displayBoard(b);

                //Ask for loop
                Console.WriteLine("Continue? y/n");
                String cont = Console.ReadLine();
                if(!cont.Contains("y"))
                {
                    loop = false;
                }
            }
        }

        private static Space SetCurrentSpace()
        {
            //get x and y coords from user
            Console.WriteLine("Enter the row");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column");
            int currentCol = int.Parse(Console.ReadLine());

            return b.Grid[currentRow, currentCol];
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
