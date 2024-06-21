using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolTesting.TestData
{
    public class SectionData
    {
        public Section GetSection20Chairs()
        {
            Section result = new Section("C");

            Row a = new Row(0);
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            a.AssignChair(new Chair(1));
            Row b = new Row(1);
            b.AssignChair(new Chair(1));
            b.AssignChair(new Chair(1));
            b.AssignChair(new Chair(1));
            Row c = new Row(3);
            c.AssignChair(new Chair(1));
            c.AssignChair(new Chair(1));
            c.AssignChair(new Chair(1));
            c.AssignChair(new Chair(1));
            c.AssignChair(new Chair(1));
            Row d = new Row(2);
            d.AssignChair(new Chair(1));
            d.AssignChair(new Chair(1));
            d.AssignChair(new Chair(1));
            d.AssignChair(new Chair(1));
            Row e = new Row(4);
            e.AssignChair(new Chair(1));
            e.AssignChair(new Chair(1));
            e.AssignChair(new Chair(1));
            e.AssignChair(new Chair(1));

            result.Rows.Add(a);
            result.Rows.Add(b);
            result.Rows.Add(c);
            result.Rows.Add(d);
            result.Rows.Add(e);

            return result;
        }



        #region ChildrenTesting
        public List<Section> GetEmptySectionList()
        {
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
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                a.AssignChair(new Chair(1));
                result[2].Rows.Add(a);
            }
            return result;
        }

        public List<Section> GetEmptySectionListExpectedResult()
        {
            List<Section> result = new List<Section>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(new Section("a"));
            }
            for (int i = 0; i < 2; i++)
            {
                Row a = new Row(0);
                if(i == 0)
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                }
                else
                {
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                }
                result[0].Rows.Add(a);
            }
            for (int i = 0; i < 1; i++)
            {
                Row a = new Row(0);
                if(i == 0)
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                }
                else
                {
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                }
                result[1].Rows.Add(a);
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
                result[2].Rows.Add(a);
            }
            return result;
        }

        public List<int> Get3ChildrenGroupInt()
        {
            return new List<int> { 3, 4, 2 };
        }
        public List<int> Get3ChildrenGroupIntFault()
        {
            return new List<int> { 5, 4, 2 };
        }

        public List<VisitorGroup> Get3ChildrenGroupList()
        {
            List<Visitor> Three =
            [
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
            ];
            List<Visitor> Five =
            [
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
            ];
            List<Visitor> Four =
            [
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
            ];
            return new List<VisitorGroup>
            {
                new VisitorGroup(1, Three),
                new VisitorGroup(2, Five),
                new VisitorGroup(3, Four)
            };
        }

        public List<int> GetTooManyChildrenGroupInt()
        {
            return new List<int> { 11, 11, 11 };
        }

        public List<VisitorGroup> GetTooManyChildrenGroupList()
        {
            List<Visitor> Eleven =
            [
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))
            ];
            return new List<VisitorGroup>
            {
                new VisitorGroup(1, Eleven),
                new VisitorGroup(2, Eleven),
                new VisitorGroup(3, Eleven)
            };
        }
        #endregion

        #region RemainingVisitorsTesting


        public List<Section> GetSectionListWithChildrenAddedExpectedResult()
        {
            List<Section> result = new List<Section>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(new Section("a"));
            }
            for (int i = 0; i < 2; i++)
            {
                Row a = new Row(0);
                a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                result[0].Rows.Add(a);
            }
            for (int i = 0; i < 3; i++)
            {
                Row a = new Row(0);
                if (i == 2)
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1));
                }
                else
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                }
                result[1].Rows.Add(a);
            }
            for (int i = 0; i < 1; i++)
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
                result[2].Rows.Add(a);
            }
            return result;
        }

        public List<Visitor> GetGroupsForRemainingSeats()
        {

            List<Visitor> Fourteen =
            [
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
                new Visitor(0, "Charlie", DateTime.Parse("2022-08-12")),
            ];
            return Fourteen;
        }

        public List<Section> GetSectionListWithChildrenAdded()
        {
            List<Section> result = new List<Section>();
            for (int i = 0; i < 3; i++)
            {
                result.Add(new Section("a"));
            }
            for (int i = 0; i < 2; i++)
            {
                Row a = new Row(0);
                if (i == 0)
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                }
                else
                {
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                }
                result[0].Rows.Add(a);
            }
            for (int i = 0; i < 3; i++)
            {
                Row a = new Row(0);
                if (i == 0)
                {
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                    a.AssignChair(new Chair(1, new Visitor(0, "Charlie", DateTime.Parse("2022-08-12"))));
                }
                else
                {
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                    a.AssignChair(new Chair(1));
                }
                result[1].Rows.Add(a);
            }
            for (int i = 0; i < 1; i++)
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
                result[2].Rows.Add(a);
            }
            return result;
        }

        #endregion
    }
}
