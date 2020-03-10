using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Coordinate: UpdateInterface
    {
        public  int Row { get; set; }
        public  int Column { get; set; }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public Coordinate()
        {
            Row = 0;
            Column = 0;
        }

        public bool Equals(Coordinate other)
        {
            if (this.Row == other.Row && this.Column == other.Column)   
            { return true; }
            else
            { return false; }
        }

        public bool Equals(int i, int j)
        {
            if (this.Row == i && this.Column == j)
            {   return true; }
            else
            { return false; }
        }

        public virtual void updateLocation()
        { }
        
    }
}
