using ChessProject;
using FiguresLib;
using ProjectLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bg.Chess;
using Stockfish;
using Stockfish.NET;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Threading;

namespace ProjectLibrary
{
    public static class AllPositions
    {
        public static Coords PB1 { get; set; }
        public static Coords PB2 { get; set; }
        public static Coords PB3 { get; set; }
        public static Coords PB4 { get; set; }
        public static Coords PB5 { get; set; }
        public static Coords PB6 { get; set; }
        public static Coords PB7 { get; set; }
        public static Coords PB8 { get; set; }

        public static Coords PW1 { get; set; }
        public static Coords PW2 { get; set; }
        public static Coords PW3 { get; set; }
        public static Coords PW4 { get; set; }
        public static Coords PW5 { get; set; }
        public static Coords PW6 { get; set; }  
        public static Coords PW7 { get; set; }
        public static Coords PW8 { get; set; }

        public static List<Coords> CurrentLegalMoves = new List<Coords>();

        public static IFigure MovingFigure { get; set; }

        public static List<IFigure> FigsOnBoard = new List<IFigure>();
        public static Coords BlackKingCoordinates { get; set; }
        public static Coords WhiteKingCoordinates { get;set; }
        public static bool BlacksToMove = false;

        public static string[,] BoardBehind = new string[9,9];
        public static void UpdateBehindBoard()
        {
            BoardBehind = new string[9,9];
            foreach(var item in FigsOnBoard)
            {
                if(item.isBlack)
                {
                    BoardBehind[item.Coords.x, item.Coords.y] = "B";
                }
                else
                {
                    BoardBehind[item.Coords.x, item.Coords.y] = "W";
                }
            }
        }

        public static string[,] DetailedBoard = new string[9, 9];
        public static void UpdateDetailedBoard()
        {
            DetailedBoard = new string[9, 9];
            foreach (var item in FigsOnBoard)
            {
                switch (item.theType)
                {
                    case "Bishop":
                        if(item.isBlack)
                        {
                            DetailedBoard[item.Coords.x-1, item.Coords.y-1] = "b";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x-1, item.Coords.y-1] = "B";
                        }
                        break;
                    case "King":
                        if (item.isBlack)
                        {
                            DetailedBoard[item.Coords.x-1, item.Coords.y - 1] = "k";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "K";
                        }
                        break;
                    case "Knight":
                        if (item.isBlack)
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "n";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "N";
                        }
                        break;
                    case "Pawn":
                        if (item.isBlack)
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "p";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "P";
                        }
                        break;
                    case "Rook":
                        if (item.isBlack)
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "r";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "R";
                        }
                        break;
                    case "Queen":
                        if (item.isBlack)
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "q";
                        }
                        else
                        {
                            DetailedBoard[item.Coords.x - 1, item.Coords.y - 1] = "Q";
                        }
                        break;
                }
                for(int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (DetailedBoard[i,j] == null)
                        {
                            DetailedBoard[i, j] = "8";
                        }
                    }
                }
            }
        }


        public static string[,] ReversedBoard = new string[9, 9];
        public static void UpdateReversedBoard()
        {
            string WhiteFigures = "PRNBKQ";
            string BlackFigures = "prnbkq";
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (DetailedBoard[i, j] != null)
                    {
                        string temp = DetailedBoard[i, j];
                        if(WhiteFigures.Contains(temp))
                        {
                            ReversedBoard[7-i,7-j] = temp.ToLower();
                        }
                        else if(BlackFigures.Contains(temp))
                        {
                            ReversedBoard[7-i,7-j] = temp.ToUpper();
                        }
                        else if (temp == "8")
                        {
                            ReversedBoard[7 - i, 7- j] = temp;
                        }
                    }
                }
            }
        }

        public static bool isShax { get; set; }


        public static List<Coords> BlackPlayersOnBoard = new List<Coords>() { PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8 };
        public static List<Coords> WhitePlayersOnBoard = new List<Coords>() { PW1, PW2, PW3, PW4, PW5, PW6, PW7, PW8 };

        public static bool CheckLocalShax(IFigure figure, Coords destinationCoords)
        {
            Coords initialCoordinates = figure.Coords;
            figure.Coords = destinationCoords;
            UpdateBehindBoard();

            List<Coords> OpositeTeamLegalMoves = new List<Coords>();

            foreach(IFigure item in FigsOnBoard)
            {
                if(figure.isBlack != item.isBlack)
                {
                    foreach(Coords coords in item.LegalMoves())
                    {
                       OpositeTeamLegalMoves.Add(coords);
                    }
                }
            }
                figure.Coords = initialCoordinates;
            UpdateBehindBoard();

            if (figure.theType == "King")
            {
                if(figure.isBlack && OpositeTeamLegalMoves.Contains(destinationCoords))
                {
                    return true;

                }
                else if (!figure.isBlack && OpositeTeamLegalMoves.Contains(destinationCoords))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (figure.isBlack && OpositeTeamLegalMoves.Contains(BlackKingCoordinates))
                {
                    return true;
                }
                else if (!figure.isBlack && OpositeTeamLegalMoves.Contains(WhiteKingCoordinates))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


           
        }

        public static bool LetsCheckShax(IFigure figure)
        {
            List<Coords> LegalMoves = new List<Coords>();
            foreach(IFigure item in FigsOnBoard)
            {
                if(figure.isBlack == item.isBlack )
                {
                    foreach(Coords coordinates in  item.LegalMoves())
                    {
                        LegalMoves.Add(coordinates);
                    }
                }
            }


            if(figure.isBlack && LegalMoves.Contains(WhiteKingCoordinates))
            {
                return true;

            }
            else if(!figure.isBlack && LegalMoves.Contains(BlackKingCoordinates))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool AnyShax()
        {
            List<Coords> LegalMoves = new List<Coords>();
            foreach (IFigure item in FigsOnBoard)
            {
                foreach (Coords coordinates in item.LegalMoves())
                {
                    LegalMoves.Add(coordinates);
                }
            }

            if(LegalMoves.Contains(WhiteKingCoordinates) || LegalMoves.Contains(BlackKingCoordinates))
            {
                return true;    
            }
            else
            {
                return false;
            }
        }

        public static void BlackResponse()
        {
            List<IFigure> theTeam = new List<IFigure>();
            foreach (var item in FigsOnBoard)
            {
                if (item.isBlack == true)
                {
                    theTeam.Add(item);
                }
            }

            IFigure RandomFigure = null;
            Random rnd = new Random();
            int RndFiguresIndex = rnd.Next(0, theTeam.Count - 1);
            RandomFigure = theTeam[RndFiguresIndex];

            if (RandomFigure.LegalMoves().Count > 0)
            {
                Random random = new Random();
                int RandomMoveIndex = random.Next(0, RandomFigure.LegalMoves().Count - 1);
                RandomFigure.MoveFigure(RandomFigure.LegalMoves()[RandomMoveIndex]);
            }
            else
            {
                BlackResponse();
            }
            UpdateBehindBoard();
        }

        public static void TendToEatResponse()
        {
            UpdateDetailedBoard();
            UpdateReversedBoard();
            string[,] havai = ReversedBoard;
            string fens = ConvertToFEN(DetailedBoard);
            string reversedFen =  ConvertToFEN(ReversedBoard);
            using (Logic chessLogic = new Logic())
            {
                string bestMove = chessLogic.GetBestMove(reversedFen);
                Coords initialCoords = new Coords();
                Coords destinationCoords = new Coords();
                string allLets = "abcdefgh";
                //convert to gridform
                initialCoords.x = 9 - Int32.Parse(bestMove[1].ToString());
                initialCoords.y = allLets.IndexOf(bestMove[0]) + 1;

                destinationCoords.x = 9 - Int32.Parse(bestMove[3].ToString());
                destinationCoords.y = allLets.IndexOf(bestMove[2]) + 1 ;

                //rotate 180
                Coords FiguresInitialOnBoard = new Coords(9-initialCoords.x, 9 - initialCoords.y);
                Coords FiguresDestinationOnBoard = new Coords(9-destinationCoords.x, 9 - destinationCoords.y);

                foreach(var item in FigsOnBoard)
                {
                    if(item.Coords.x == FiguresInitialOnBoard.x && item.Coords.y == FiguresInitialOnBoard.y)
                    {
                        item.MoveFigure(FiguresDestinationOnBoard);
                        UpdateBehindBoard();
                        UpdateDetailedBoard();
                        break;
                    }
                }
            }
            BlacksToMove = !BlacksToMove;
        }

        static string ConvertToFEN(string[,] board)
        {
            string fen = "";

            for (int row = 0; row < 8; row++)
            {
                int emptyCount = 0;

                for (int col = 0; col < 8; col++)
                {
                    string piece = board[row, col];

                    if (piece == "8")
                    {
                        emptyCount++;
                    }
                    else
                    {
                        if (emptyCount > 0)
                        {
                            fen += emptyCount.ToString();
                            emptyCount = 0;
                        }

                        fen += piece;
                    }
                }

                if (emptyCount > 0)
                {
                    fen += emptyCount.ToString();
                }

                if (row < 7)
                {
                    fen += "/";
                }
            }

            // Add information about the side to move, castling rights, en passant square, and move counters
            fen += " w KQkq - 0 1";

            return fen;
        }

        public static bool WhiteKingIsUnderAttack()
        {
            bool isShax = false;
            foreach(var item in FigsOnBoard)
            {
                if(item.isBlack && item.LegalMoves().Contains(WhiteKingCoordinates))
                {
                    isShax = true;
                }
            }
            return isShax;
        }
        public static bool BlackKingIsUnderAttack()
        {
            bool isShax = false;
            foreach (var item in FigsOnBoard)
            {
                if (item.isBlack && item.LegalMoves().Contains(BlackKingCoordinates))
                {
                    isShax = true;
                }
            }
            return isShax;
        }


        public static void ChechMat()
        {
            foreach(var item in FigsOnBoard)
            {
                if(item.theType == "King" && item.isBlack && BlackKingIsUnderAttack() && item.LegalMoves().Count == 0)
                {
                    foreach(var item2 in FigsOnBoard)
                    {
                        //if(item.isBlack && item.LegalMoves().Contains)
                    }
                }
            }
        }

        public static bool WhiteKingCanBeProtected()
        {
            bool CanBeProtected = false;

            foreach (var item in FigsOnBoard)
            {
                if (!item.isBlack && item.LegalMoves().Contains(MovingFigure.Coords))
                {
                    CanBeProtected = true;
                }
            }

            foreach (var item in FigsOnBoard)
            {
                if (!item.isBlack)
                {
                    foreach (Coords cords in item.LegalMoves())
                    {
                        if(CurrentLegalMoves.Contains(cords))
                        {
                            CanBeProtected = true;
                        }
                    }
                }
            }
            return CanBeProtected;
        }


        public static bool BlackKingCanBeProtected()
        {
            bool CanBeProtected = false;
            //eat the attacker   -> need Attackers(MovingFigure) Coords
            foreach (var item in FigsOnBoard)
            {
                if (item.isBlack && item.LegalMoves().Contains(MovingFigure.Coords))
                {
                    CanBeProtected = true;
                }
            }

            //stand on the way   -> need Current LegalMoves() List
            //item.LegalMoves()
            //CurrentLegalMoves
            // List<Coords> MatchingMoves = new List<Coords>();
            foreach (var item in FigsOnBoard)
            {
                if (item.isBlack)
                {
                    foreach (Coords cords in item.LegalMoves())
                    {
                        if (MovingFigure.LegalMoves().Contains(cords))
                        {
                            CanBeProtected = true;
                        }
                    }
                }
            }



            return CanBeProtected;
        }
        //List<IFigure> blackTeam = new List<IFigure>();
        //List<Coords> whiteTeamCoordinates = new List<Coords>();
        //List<Coords> blackTeamLegalMoves = new List<Coords>();
        //foreach (var item in FigsOnBoard)
        //{
        //    if (item.isBlack == true)
        //    {
        //        blackTeam.Add(item);
        //        foreach(Coords cordinates in item.LegalMoves())
        //        {
        //            blackTeamLegalMoves.Add(cordinates);
        //        }
        //    }
        //    if(!item.isBlack)
        //    {
        //        whiteTeamCoordinates.Add(item.Coords);
        //    }
        //}
        //////////////////////////////////
        //bool moveIsDone = false;
        //foreach(Coords item in whiteTeamCoordinates)
        //{
        //    if(blackTeamLegalMoves.Contains(item))
        //    {
        //        foreach(var Eater in blackTeam)
        //        {
        //            if(Eater.LegalMoves().Contains(item))
        //            {
        //                Eater.MoveFigure(item);
        //                moveIsDone = true;
        //                break;

        //            }
        //        }
        //        break;
        //    }
        //}



        //if(!moveIsDone)
        //{
        //    BlackResponse();
        //}
        //UpdateBehindBoard();







    }
}
