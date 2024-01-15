using ChessConsole;

namespace ChessTest
{
    [TestClass]
    public class ChessUnitTests
    {
        [TestMethod]
        public void KingAndRooks()
        {
            bool success = true;
            for (int tests = 0; tests < 100; tests++)
            { 
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.Reset(false);

                bool foundFirstRook = false;
                bool foundKing = false;
                bool foundSecondRook = false;

                for (int i = 0; i < 8; i++) 
                {
                    var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;

                    if (tempPiece == 'R' && !foundFirstRook) { foundFirstRook = true; }
                    else if (tempPiece == 'R') { foundSecondRook = true; }

                    if (tempPiece == 'K') { foundKing = true; }

                    if (tempPiece == 'K' && !foundFirstRook)
                    {
                        success = false;
                        break;
                    }
                    else if (tempPiece == 'K' && foundFirstRook && foundSecondRook)
                    {
                        success = false;
                        break;
                    }
                }
                if (!foundFirstRook || !foundSecondRook || !foundKing) { success = false; }

                if (!success) break;
            }
            Assert.IsTrue(success);
            //chessBoard.GetCell()
        }
        [TestMethod]
        public void BishopsOnLightAndDark()
        {
            bool success = true;
            for (int tests = 0; tests < 100; tests++)
            {
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.Reset(false);

                bool foundLightTileBishop = false;
                bool foundDarkTileBishop = false;

                for (int i = 0; i < 8; i++)
                {
                    var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;
                    if (tempPiece == 'B' && i % 2 == 0) 
                    {
                        if (foundLightTileBishop)
                        {
                            success = false;
                            break;
                        }
                        foundLightTileBishop = true; 
                    }
                    if (tempPiece == 'B' && i % 2 == 1) 
                    {
                        if (foundDarkTileBishop)
                        {
                            success = false;
                            break;
                        }
                        foundDarkTileBishop = true; 
                    }
                }
                if (!success) break;
            }
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void AllPiecesPresent()
        {
            bool success = true;
            for (int tests = 0; tests < 100; tests++)
            {
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.Reset(false);

                int knightCount = 0;
                int bishopCount = 0;
                int rookCount = 0;
                int queenCount = 0;
                int kingCount = 0;

                for (int i = 0; i < 8; i++)
                {
                    var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;
                    switch (tempPiece)
                    {
                        case 'H':
                            knightCount++;
                            if (knightCount > 2) success = false;
                            break;
                        case 'B':
                            bishopCount++;
                            if (bishopCount > 2) success = false;
                            break;
                        case 'R':
                            rookCount++;
                            if (rookCount > 2) success = false;
                            break;
                        case 'Q':
                            queenCount++;
                            if (queenCount > 1) success = false;
                            break;
                        case 'K':
                            kingCount++;
                            if (kingCount > 1) success = false;
                            break;
                    }
                    if (!success) break;
                }
                if (success)
                {
                    if (knightCount != 2) success = false;
                    if (bishopCount != 2) success = false;
                    if (rookCount != 2) success = false;
                    if (queenCount != 1) success = false;
                    if (kingCount != 1) success = false;
                }
                if (!success) break;
            }
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void BothSidesAreMirrored()
        {
            bool success = true;
            for (int tests = 0; tests < 100; tests++)
            {
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.Reset(false);
                string whiteSide = "";
                string blackSide = "";
                for (int i = 0; i < 8; i++)
                {
                    var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;
                    whiteSide += tempPiece;

                    tempPiece = chessBoard.GetCell(i, 0).Piece.Char;
                    blackSide += tempPiece;
                }
                success = (blackSide == whiteSide);
                if (!success) break;
            }
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void ClassicStillAccessible()
        {
            bool success = true;
            ChessBoard chessBoard = new ChessBoard();
            chessBoard.Reset(true);

            string pieceOrder = "RHBQKBHR";

            string whiteSide = "";
            string blackSide = "";
            for (int i = 0; i < 8; i++)
            {
                var tempPiece = chessBoard.GetCell(i, 7).Piece.Char;
                whiteSide += tempPiece;

                tempPiece = chessBoard.GetCell(i, 0).Piece.Char;
                blackSide += tempPiece;
            }

            if (pieceOrder != whiteSide || pieceOrder != blackSide) success = false;

            Assert.IsTrue(success);
        }
    }
}