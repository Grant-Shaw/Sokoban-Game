using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Box : Coordinate , UpdateInterface
    {
        public Coordinate boxTargetLocation = new Coordinate();

        public Coordinate BoxLocation { get; set; }

        public override void updateLocation()
        {
            this.BoxLocation.Row = boxTargetLocation.Row;
            this.BoxLocation.Column = boxTargetLocation.Column;

        }

    }
}
