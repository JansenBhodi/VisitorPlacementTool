using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.RowClasses;

namespace VisitorPlacementToolTesting.TestData
{
    public class RowData
    {
        public Row GetRowWith5Chairs()
        {

            Row a = new Row(0);
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));

            return a;
        }

        public Row GetRowWith11Chairs()
        {

            Row a = new Row(0);
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));

            return a;
        }
    }
}
