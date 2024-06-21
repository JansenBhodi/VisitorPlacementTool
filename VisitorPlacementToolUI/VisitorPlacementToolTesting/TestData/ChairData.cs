using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolTesting.TestData
{
    public class ChairData
    {
        public Chair EmptyChair()
        {
            return new Chair(1);
        }
        public Chair FilledChair()
        {
            return new Chair(2, OneVisitor());
        }
        public Visitor OneVisitor()
        {
            return new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"));
        }
    }
}
