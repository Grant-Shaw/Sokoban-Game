using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Wullie : Coordinate , UpdateInterface 

    {

        public Coordinate WullieLocation { get; set; }

        public Coordinate TargetLocation { get; set; }

        

        public override void updateLocation()
        {


            this.WullieLocation.Row = TargetLocation.Row;
            this.WullieLocation.Column = TargetLocation.Column;

        }

    }
}
