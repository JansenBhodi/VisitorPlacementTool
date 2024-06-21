using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolTesting.TestData;

namespace VisitorPlacementToolTesting
{
    public class ChairTesting
    {
        private ChairData _data = new ChairData();
        

        [Fact]
        public void AssignChairTestEmptyChair()
        {
            Chair testObject = _data.EmptyChair();
            Assert.Null(testObject.Visitor);

            testObject.AssignChair(_data.OneVisitor());

            Assert.Equivalent(testObject.Visitor, _data.OneVisitor());
        }

        [Fact]
        public void AssignChairTestFilledChair()
        {
            Chair testObject = _data.FilledChair();
            Assert.NotNull(testObject.Visitor);

            Assert.Throws<InvalidOperationException>(() => testObject.AssignChair(_data.OneVisitor()));
        }
    }
}
