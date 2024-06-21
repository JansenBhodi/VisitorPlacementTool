using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.HappeningClasses;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolTesting.TestData
{
    public class HappeningData
    {
        private SectionData _data = new SectionData();

        #region Happening.cs
        public Happening GetHappeningTwelveCurrentVisitors()
        {
            Happening result = new Happening(DateTime.Now, DateTime.Now);

            foreach(VisitorGroup group in _data.Get3ChildrenGroupList())
            {
                result.AddGroup(group);
            }

            return result;
        }
        public Happening GetHappeningThirtyEightMax()
        {
            Happening result = new Happening(DateTime.Now, DateTime.Now, _data.GetEmptySectionList());

            return result;
        }
        #endregion

        public DateTime GetDateTimeForTesting()
        {
            return DateTime.Parse("15-04-2025");
        }

        #region CalculateSeatsNeededForChildren

        public List<VisitorGroup> CalculateSeatsNeededForChildrenSuccesful()
        {
            List<VisitorGroup> result = new List<VisitorGroup>();
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Child, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Adult, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Adult}));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Adult }));
            return result;
        }

        public List<VisitorGroup> CalculateSeatsNeededForChildrenFailed()
        {
            List<VisitorGroup> result = new List<VisitorGroup>();
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Child, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Adult, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Adult }));
            return result;
        }
        public List<int> CalculateSeatsNeededForChildrenIntList()
        {
            return new List<int> { 4, 3, 3, 2 };
        }

        #endregion

        #region GetAllGroupsWithChildren


        public List<VisitorGroup> GetChildrenGroupsSuccesfulTest()
        {
            List<VisitorGroup> result = new List<VisitorGroup>();
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            result.Add(new VisitorGroup(1, new List<Visitor> { Adult, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Child, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Adult, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Child, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Adult, Adult, Adult}));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Adult, Adult, Adult, Adult, Adult }));
            return result;
        }

        public List<VisitorGroup> GetChildrenGroupsFailedTest()
        {
            List<VisitorGroup> result = new List<VisitorGroup>();
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            result.Add(new VisitorGroup(1, new List<Visitor> { null, Child, Child, Adult, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, null, Adult, null, Adult }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, null }));
            result.Add(new VisitorGroup(1, new List<Visitor> { Child, Adult }));
            return result;
        }

        #endregion

        #region CalculateDescendingSeats + versus

        public Happening CalculateDescendingSeatsHappening()
        {
            Happening happening = new Happening(DateTime.Parse("12-08-2024"), DateTime.Parse("25-08-2024"), _data.GetEmptySectionList());
            foreach (VisitorGroup group in GetChildrenGroupsSuccesfulTest())
            {
                happening.AddGroup(group);
            }
            return happening;
        }

        public Happening CalculateDescendingSeatsHappeningBigger()
        {
            Happening happening = new Happening(DateTime.Parse("12-08-2024"), DateTime.Parse("25-08-2024"), _data.GetEmptySectionListForDescending());
            bool bonus = true;
            foreach (VisitorGroup group in GetChildrenGroupsSuccesfulTest())
            {
                happening.AddGroup(group);
                if (bonus) 
                {
                    bonus = false;
                    happening.AddGroup(group);
                }
            }
            return happening;
        }

        public Happening CalculateDescendingSeatsHappeningFail()
        {
            Happening happening = new Happening(DateTime.Parse("12-08-2024"), DateTime.Parse("25-08-2024"), null);
            foreach (VisitorGroup group in GetChildrenGroupsSuccesfulTest())
            {
                happening.AddGroup(group);
            }
            return happening;
        }

        #region StartSorting

        public Happening StartSortingHappening()
        {
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            List<VisitorGroup> groups = new List<VisitorGroup> { 
                new VisitorGroup(1, new List<Visitor> { Child, Adult, Adult}), 
                new VisitorGroup(1, new List<Visitor> { Child, Adult }), 
                new VisitorGroup(1, new List<Visitor> { Child, Adult, Child, Adult }), 
                new VisitorGroup(1, new List<Visitor> { Adult, Adult, Adult }),
                new VisitorGroup(1, new List<Visitor> { Adult, Adult, Adult, Adult, Adult }),
                new VisitorGroup(1, new List<Visitor> { Adult, Adult }) };

            List<Section> sections = new List<Section>();
            for (int i = 0; i < 3; i++)
            {
                sections.Add(new Section("a"));
            }
            for (int i = 0; i < 2; i++)
            {
                Row a = new Row(0);
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                sections[0].Rows.Add(a);
            }
            for (int i = 0; i < 1; i++)
            {
                Row a = new Row(0);
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                sections[1].Rows.Add(a);
            }
            for (int i = 0; i < 3; i++)
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
                sections[2].Rows.Add(a);
            }
            Happening happening = new Happening(DateTime.Parse("12-08-2024"), DateTime.Parse("25-08-2024"), sections);
            foreach(VisitorGroup group in groups)
            {
                happening.AddGroup(group);
            }
            return happening;
        }
        public List<Section> StartSortingExpectedOutcome()
        {
            Visitor Child = new Visitor(1, "Charlie", DateTime.Parse("08-08-2015"));
            Visitor Adult = new Visitor(1, "Bob", DateTime.Parse("08-08-2000"));
            List<Section> result = new List<Section>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(new Section("a"));
            }
            for (int i = 0; i < 2; i++)
            {
                Row a = new Row(0);
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                result[0].Rows.Add(a);
            }
            for (int i = 0; i < 1; i++)
            {
                Row a = new Row(0);
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                result[1].Rows.Add(a);
            }
            for (int i = 0; i < 3; i++)
            {
                Row a = new Row(0);
                if(i == 0)
                {
                    a.AssignChair(new Chair(1, Child));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Child));
                    a.AssignChair(new Chair(1, Child));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Child));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                }
                else if(i == 1)
                {
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1, Adult));
                    a.AssignChair(new Chair(1));
                }
                else
                {
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
                }
                result[2].Rows.Add(a);
            }

            result = result.OrderByDescending(s => s.TotalChairs).ToList();
            return result;
        }

        #endregion

        #endregion

    }
}
