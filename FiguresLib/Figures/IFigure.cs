using FiguresLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject;

public interface IFigure
{
    public bool isBlack { get; set; }
    public Coords Coords { get; set; }
    public List<Coords> LegalMoves();
    public bool MoveFigure(Coords coords);
    public string theType { get;}
}
