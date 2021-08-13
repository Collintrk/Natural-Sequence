using System;
using System.Collections.Generic;
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
            List<Piece> playedPieces = new List<Piece>();
            List<Space> spaces = new List<Space>();

            while (loop)
            {
                Console.WriteLine("Chose an action to perform: Play, Move, Display, Quit");
                String action = Console.ReadLine();
                //clear board of all pieces and legal moves
                b.ClearBoard();
                switch (action)
                {
                    case "Play":

                        break;

                    case "Move":
                        if(spaces.Count == 0)
                        {
                            Console.WriteLine("No pieces played! Please play a piece first.");
                        }
                        else
                        {
                            //ask user to choose a piece
                            Console.WriteLine("Choose a piece to move:");
                            foreach (Space s in spaces)
                            {
                                Console.WriteLine("{0} ({1})", s.Piece.name, s.Piece.type);
                            }

                            //check if user chose a legal piece
                            String piece = Console.ReadLine();
                            bool legalPiece = false;
                            Space chosen = spaces[0];
                            foreach (Space s in spaces)
                            {
                                if (piece.Equals(s.Piece.name))
                                {
                                    //if user inputs legal piece, find its name and space and print its legal moves
                                    legalPiece = true;
                                    b.MarkLegalMoves(s, s.Piece.type);
                                    chosen = s;
                                }
                            }

                            //if user doesn't input a legal piece, use first space in array
                            if (legalPiece == false)
                            {
                                Console.WriteLine("No valid piece chosen, using default piece instead");
                                b.MarkLegalMoves(chosen, chosen.Piece.type);
                            }

                            //print board again
                            displayBoard(b);

                            //ask user where to move the piece
                            Console.WriteLine("{0} ({1}) was selected. Move this piece? (yes/no)", chosen.Piece.name, chosen.Piece.type);
                            String move = Console.ReadLine();
                            if (move.Equals("yes"))
                            {
                                int row = int.Parse(Console.ReadLine());
                                int col = int.Parse(Console.ReadLine());
                                if(b.Grid[row, col].NextLegalMove == true)
                                {
                                    Space s = new Space(row, col);
                                    s.Piece = chosen.Piece;
                                    spaces.Remove(chosen);
                                    spaces.Add(s);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Piece not moved");
                            }
                        }
                        break;

                    case "Display":
                        b.ClearBoard();
                        foreach(Space s in spaces)
                        {
                            b.MarkOccupied(s.Row, s.Column);
                        }
                        displayBoard(b);
                        break;

                    case "Quit":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Command not recognized");
                        break;
                }
                foreach (Piece p in playedPieces)
                {
                    //tell user next piece
                    Console.WriteLine("Next piece is {0}", p.type);

                    //prompt user for row
                    Console.WriteLine("Enter a row");
                    int currentRow = int.Parse(Console.ReadLine());

                    //prompt user for column
                    Console.WriteLine("Enter a column");
                    int currentCol = int.Parse(Console.ReadLine());

                    //create new space, mark it as occupied, place the piece on it, and add it to the spaces array
                    Space currentSpace = SetCurrentSpace(currentRow, currentCol);
                    currentSpace.Occupied = true;
                    currentSpace.Piece = p;
                    spaces.Add(currentSpace);
                }
                foreach (Space s in spaces)
                {
                    b.MarkOccupied(s.Row, s.Column);
                }


                //print board again
                displayBoard(b);
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
            Console.WriteLine("      P                       P                               P");
            Console.WriteLine("  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |");
            for (int i = 17; i >= 1; i--)
            {
                for (int j = 0; j < b.Size; j++)
                {
                    //First column: print passages on Row 2 and 16
                    if(j == 0)
                    {
                        if (i == 2 || i == b.Size - 3 || i == 9)
                        {
                            Console.Write("P-");
                        }
                        else
                        {
                            Console.Write(" -");
                        }
                    }
                    //Last column: Print passages on row 1 and 17
                    else if(j == b.Size - 1)
                    {
                        if(i == 2 || i == b.Size - 3 || i == 9)
                        {
                            Console.WriteLine("P");
                        }
                        else
                        {
                            Console.WriteLine("  ");
                        }
                    }
                    //Last filled row
                    else if(j == b.Size - 2)
                    {
                        //Cell is occupied by piece
                        if (b.Grid[i, j].Occupied)
                        {
                            Console.Write("{0}", b.Grid[i, j].Piece.name);
                        }
                        //mark all legal next moves
                        else if (b.Grid[i, j].NextLegalMove)
                        {
                            Console.Write("O-");
                        }
                        //otherwise print a space marker
                        else
                        {
                            Console.Write("+-");
                        }
                    }
                    //normal rows: print - after space marker
                    else
                    {
                        //Cell is occupied by piece
                        if(b.Grid[i, j].Occupied)
                        {
                            Console.Write("{0}--", b.Grid[i, j].Piece.name);
                        }
                        //mark space if it is a legal move
                        else if (b.Grid[i, j].NextLegalMove)
                        {
                            Console.Write("O---");
                        }
                        //otherwise print space marker
                        else
                        {
                            Console.Write("+---");
                        }
                    }
                }
                printSpaceColors(i);
            }
            //print passages on last row
            Console.WriteLine("      P                       P                               P");
        }

        private static void printSpaceColors(int row)
        {
            switch (row)
            {
                case 17:
                    Console.WriteLine("  | w | w | w | w | w | w | w |w/S|S\\w| w | w | w | w | w | w | w |");
                    break;

                case 16:
                    Console.WriteLine("  | w | G | G | G | G | w | w |w\\S|S/w| w | w | S | S | S | S | w |");
                    break;

                case 15:
                    Console.WriteLine("  | w | G | G | G | G | w | w |w/G|G\\w| w | w | S | S | S | S | w |");
                    break;

                case 14:
                    Console.WriteLine("  | w | G | G | G | G | w |w/G| G | G |G\\w| w | S | S | S | S | w |");
                    break;

                case 13:
                    Console.WriteLine("  | w | G | G | G | G |w/G| G | G | G | G |G\\w| S | S | S | S | w |");
                    break;

                case 12:
                    Console.WriteLine("  | w | w | w | w |w/S|S\\G| G | G | G | G |G/S|S\\w| w | w | w | w |");
                    break;

                case 11:
                    Console.WriteLine("  | w | w | w |w/S| S | S |S\\G| G | G |G/S| S | S |S\\w| w | w | w |");
                    break;

                case 10:
                    Console.WriteLine("  |w/G|G\\w|w/S| S | S | S | S |S\\G|G/S| S | S | S | S |S\\w|w/G|G\\w|");
                    break;

                case 9:
                    Console.WriteLine("  |w\\G|G/w|w\\S| S | S | S | S |S/G|G\\S| S | S | S | S |S/w|w\\G|G/w|");
                    break;

                case 8:
                    Console.WriteLine("  | w | w | w |w\\S| S | S |S/G| G | G |G\\S| S | S |S/w| w | w | w |");
                    break;

                case 7:
                    Console.WriteLine("  | w | w | w | w |w\\S|S/G| G | G | G | G |G\\S|S/w| w | w | w | w |");
                    break;

                case 6:
                    Console.WriteLine("  | w | S | S | S | S |w\\G| G | G | G | G |G/w| G | G | G | G | w |");
                    break;

                case 5:
                    Console.WriteLine("  | w | S | S | S | S | w |w\\G| G | G |G/w| w | G | G | G | G | w |");
                    break;

                case 4:
                    Console.WriteLine("  | w | S | S | S | S | w | w |w\\G|G/w| w | w | G | G | G | G | w |");
                    break;

                case 3:
                    Console.WriteLine("  | w | S | S | S | S | w | w |w/S|S\\w| w | w | S | S | S | S | w |");
                    break;

                case 2:
                    Console.WriteLine("  | w | w | w | w | w | w | w |w\\S|S/w| w | w | w | w | w | w | w |");
                    break;

                case 1:
                    Console.WriteLine("  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |");
                    break;

                default:
                    Console.WriteLine("  |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |   |");
                    break;
            }
        }
    }
}
