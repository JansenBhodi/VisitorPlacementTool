using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolTesting.TestData;

namespace VisitorPlacementToolTesting
{
    public class RowTesting
    {

        private RowData _data = new RowData();

        [Fact]
        public void AssignChairTestSuccesfulSixChair()
        {
            Row testObject = _data.GetRowWith5Chairs();

            Assert.Equal(5, testObject.Chairs.Count());

            Assert.True(testObject.AssignChair(new Chair(1)));

            Assert.Equal(6, testObject.Chairs.Count());

        }

        [Fact]
        public void AssignChairTestFailOver11Attempt()
        {
            Row testObject = _data.GetRowWith11Chairs();

            Assert.Equal(11, testObject.Chairs.Count());

            Assert.Throws<InvalidOperationException>(() => testObject.AssignChair(new Chair(1)));

        }
    }
}
