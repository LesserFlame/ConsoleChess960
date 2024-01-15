using System;

namespace ChessConsole
{
    public class Program
    {
        static ChessGame game;
        static void Main(string[] args)
        {
            //TestTester();

            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();
            Console.WriteLine("Which gamemode would you like to play?\n1) Classic\n2) Chess960");

            bool valid = false;
            int inputInt = 0;
            while (!valid) 
            {
                var inputString = Console.ReadLine();
                valid = int.TryParse(inputString, out inputInt);
                if (inputInt < 1 || inputInt > 2 ) { valid = false; }
                if (!valid) { Console.WriteLine("Please input either 1 or 2."); }
            }
            Console.Clear();
            game = new ChessGame(inputInt == 1);
            
            do
            {
                game.Draw(graphics);
                graphics.SwapBuffers();
                game.Update();
            } while (game.Running);

            Console.Read();
        }

        //static void TestTester()
        //{
        //    bool success = true;
        //    for (int tests = 0; tests < 100; tests++)
        //    {
        //        ChessBoard chessBoard = new ChessBoard();
        //        chessBoard.Reset(false);

        //        bool foundFirstRook = false;
        //        bool foundKing = false;
        //        bool foundSecondRook = false;

        //        string output = "Test " + tests + ": ";
        //        for (int i = 0; i < 8; i++)
        //        {
        //            var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;
        //            output += tempPiece;

        //            if (tempPiece == 'R' && !foundFirstRook) { foundFirstRook = true; }
        //            else if (tempPiece == 'R') { foundSecondRook = true; }

        //            if (tempPiece == 'K') { foundKing = true; }

        //            if (tempPiece == 'K' && !foundFirstRook) success = false;
        //            else if (tempPiece == 'K' && foundFirstRook && foundSecondRook) success = false;
        //        }
        //        if (!foundFirstRook || !foundSecondRook || !foundKing) { success = false; }
        //        output += "\t Success: " + success;
        //        Console.WriteLine(output);
        //    }
        //}
    }
}
