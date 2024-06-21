using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.HappeningClasses;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;
using VisitorPlacementToolTesting.TestData;

namespace VisitorPlacementToolTesting
{
    public class HappeningTesting
    {
        private HappeningData _data = new HappeningData();
        private HappeningService _service = new HappeningService();

        #region Happening.cs
        [Fact]
        public void GetCurrentVisitorsTestSuccess()
        {
            Happening testData = _data.GetHappeningTwelveCurrentVisitors();

            Assert.Equal(12, testData.GetCurrentVisitors());
        }

        [Fact]
        public void GetMaxVisitorsTestSuccess()
        {
            Happening testData = _data.GetHappeningThirtyEightMax();

            Assert.Equal(38, testData.GetMaxVisitors());
        }
        #endregion

        #region HappeningService

        #region CalculateSeatsNeeded
        [Fact]
        public void CalculateSeatsNeededForChildrenTestSuccess()
        {
            List<VisitorGroup> groupData = _data.CalculateSeatsNeededForChildrenSuccesful();
            DateTime DateTest = _data.GetDateTimeForTesting();

            List<int> expectedResult = _data.CalculateSeatsNeededForChildrenIntList();

            Assert.Equivalent(expectedResult, _service.CalculateSeatsNeededForChildren(groupData, DateTest));
        }
        [Fact]
        public void CalculateSeatsNeededForChildrenTestGroupNoAdult()
        {
            List<VisitorGroup> groupData = _data.CalculateSeatsNeededForChildrenFailed();
            DateTime DateTest = _data.GetDateTimeForTesting();


            Assert.Throws<InvalidOperationException>(() => _service.CalculateSeatsNeededForChildren(groupData, DateTest));
        }
        #endregion

        #region GetAllGroupsWithChildren

        [Fact]
        public void GetAllGroupsWithChildrenTestSuccess()
        {
            List<VisitorGroup> groupData = _data.GetChildrenGroupsSuccesfulTest();
            DateTime DateTest = _data.GetDateTimeForTesting();

            List<VisitorGroup> expectedResult = _data.CalculateSeatsNeededForChildrenSuccesful();

            Assert.Equivalent(expectedResult, _service.GetAllGroupsWithChildren(groupData, DateTest));
        }
        [Fact]
        public void GetAllGroupsWithChildrenTestFail()
        {
            List<VisitorGroup> groupData = _data.GetChildrenGroupsFailedTest();
            DateTime DateTest = _data.GetDateTimeForTesting();


            Assert.Throws<InvalidDataException>(() => _service.GetAllGroupsWithChildren(groupData, DateTest));
        }
        #endregion

        #region CalculateDescendingSeats

        [Fact]
        public void CalculateDescendingSeatsTestSuccess()
        {
            Happening happening = _data.CalculateDescendingSeatsHappening();


            Assert.Equal(2, _service.CalculateDescendingSeats(happening, happening.GetCurrentVisitors(), 12));
        }

        [Fact]
        public void CalculateDescendingSeatsTestException()
        {
            Happening happening = _data.CalculateDescendingSeatsHappeningFail();

            Assert.Throws<ArgumentException>(() => _service.CalculateDescendingSeats(happening, happening.GetCurrentVisitors(), 12));
        }

        #endregion

        #region CalculateAscendingVsDescending

        [Fact]
        public void CalculateDescendingVsAscendingTestAscending()
        {
            Happening ascendingWins = _data.CalculateDescendingSeatsHappening();


            Assert.False(_service.CalculateAscendingVsDescending(ascendingWins, ascendingWins.GetCurrentVisitors(), 12));
        }
        [Fact]
        public void CalculateDescendingVsAscendingTestDescending()
        {
            Happening descendingWins = _data.CalculateDescendingSeatsHappeningBigger();


            Assert.False(_service.CalculateAscendingVsDescending(descendingWins, descendingWins.GetCurrentVisitors(), 12));
        }

        #endregion
        [Fact]
        public void FullSortingTestSuccess()
        {
            Happening happening = _data.StartSortingHappening();
            List<Section> expectedOutcome = _data.StartSortingExpectedOutcome();

            int s = 0;
            List<Section> ActualOutcome = _service.StartSorting(happening);
            foreach (Section section in ActualOutcome)
            {
                int r = 0;
                foreach(Row row in  section.Rows)
                {
                    int c = 0;
                    foreach(Chair chair in  row.Chairs)
                    {
                        Assert.Equivalent(expectedOutcome[s].Rows[r].Chairs[c], chair);
                        c++;
                    }
                    r++;
                }
                s++;
            }
        }
        #endregion
    }
}
