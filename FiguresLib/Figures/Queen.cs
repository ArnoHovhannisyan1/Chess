using ChessProject;
using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Figures
{
    public class Queen : IFigure
    {
        public bool isBlack { get; set; }
        public Coords Coords { get; set; }
        public bool ToUp { get; set; }

        public string theType { get { return "Queen"; } }

        public Queen(Coords cords, bool isBlack)
        {
            this.isBlack = isBlack;
            Coords = cords;
        }

        public List<Coords> LegalMoves()
        {
            Bishop bish = new Bishop(Coords, isBlack);
            Rook rook = new Rook(Coords, isBlack);
            List<Coords> coords = new List<Coords>();
            foreach (Coords item in bish.LegalMoves())
            {
                coords.Add(item);
            }
            foreach (Coords item in rook.LegalMoves())
            {
                coords.Add(item);
            }

            //IFigure? theFigure = null;
            //foreach (var item in AllPositions.FigsOnBoard)
            //{
            //    if (item.Coords.x == Coords.x && item.Coords.y == Coords.y)
            //    {
            //        theFigure = item;
            //    }
            //}

            //foreach (Coords cords in  coords)
            //{
            //    if(AllPositions.CheckLocalShax(theFigure,cords))
            //    {
            //        coords.Remove(cords);
            //    }
            //}


            return coords;
        }

        public bool MoveFigure(Coords coords)
        {
            //IFigure? theFigure = null;
            //foreach(var item in AllPositions.FigsOnBoard)
            //{
            //    if(item.Coords.x == Coords.x && item.Coords.y == Coords.y)
            //    {
            //        theFigure = item;
            //    }
            //}  
            
            

            if (LegalMoves().Contains(coords) /*&& !AllPositions.CheckLocalShax(theFigure,coords)*/)
            {
                IFigure figure = null;
                foreach (IFigure fig in AllPositions.FigsOnBoard)
                {
                    if (fig.Coords.x == coords.x && fig.Coords.y == coords.y)
                    {
                        figure = fig;
                    }
                }
                if (figure != null)
                {
                    AllPositions.FigsOnBoard.Remove(figure);
                    AllPositions.UpdateBehindBoard();
                }
                Coords = coords;
                AllPositions.UpdateBehindBoard();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
