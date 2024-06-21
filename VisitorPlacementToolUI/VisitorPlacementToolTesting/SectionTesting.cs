using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;
using VisitorPlacementToolTesting.TestData;

namespace VisitorPlacementToolTesting
{
    public class SectionTesting
    {
        private SectionService _service = new SectionService();
        private SectionData _data = new SectionData();

        [Fact]
        public void DivideByNTestSuccesfulSplit()
        {
            List<Visitor> testData = new List<Visitor>();
            int visiterPerChair = 3;
            for (int i = 0; i < 10; i++)
            {
                testData.Add(new Visitor(i, "a", DateTime.Now));
            }

            IEnumerable<Visitor[]> result = _service.DivideByN(testData, visiterPerChair);

            int counter = 0;
            foreach (Visitor[] output in result)
            {
                for (int i = 0; i < output.Length; i++)
                {
                    Assert.Equivalent(output[i], testData[counter]);
                    counter++;
                }
            }
        }

        #region TotalChairCount
        [Fact]
        public void TotalChairCountTestCount20Succesful()
        {
            Section testData = _data.GetSection20Chairs();

            Assert.Equal(20, testData.TotalChairs);
        }

        [Fact]
        public void TotalChairCountTestCountZero()
        {
            Section testData = new Section("a");

            Assert.Equal(0, testData.TotalChairs);
        }
        #endregion

        #region FillChildren

        [Fact]
        public void FillChildrenTestSuccess()
        {
            List<Section> sectionData = _data.GetEmptySectionList();
            List<VisitorGroup> groupData = _data.Get3ChildrenGroupList();
            List<int> assigneeData = _data.Get3ChildrenGroupInt();

            List<Section> expectedResult = _data.GetEmptySectionListExpectedResult();

            Assert.Equivalent(expectedResult, _service.FillChildren(sectionData, groupData, assigneeData));

        }
        [Fact]
        public void FillChildrenTestFailGroupsizeMismatch()
        {
            List<Section> sectionData = _data.GetEmptySectionList();
            List<VisitorGroup> groupData = _data.Get3ChildrenGroupList();
            List<int> assigneeData = _data.Get3ChildrenGroupIntFault();

            Assert.Throws<ArgumentException>(() => _service.FillChildren(sectionData, groupData, assigneeData));
        }

        [Fact]
        public void FillChildrenTestFailLackingSeats()
        {
            List<Section> sectionData = _data.GetEmptySectionList();
            List<VisitorGroup> groupData = _data.GetTooManyChildrenGroupList();
            List<int> assigneeData = _data.GetTooManyChildrenGroupInt();

            Assert.Throws<InvalidOperationException>(() => _service.FillChildren(sectionData, groupData, assigneeData));
        }

        #endregion


        #region FillRemainingSeats
        [Fact]
        public void FillRemainingSeatsTestSuccess()
        {
            List<Section> sectionData = _data.GetSectionListWithChildrenAdded();
            List<Visitor> groupData = _data.GetGroupsForRemainingSeats();
            int sectionCount = 2;

            List<Section> ExpectedResult = _data.GetSectionListWithChildrenAddedExpectedResult();

            Assert.Equivalent(ExpectedResult, _service.FillRemainingSeats(sectionData, groupData, sectionCount));
        }

        #endregion
    }
}
