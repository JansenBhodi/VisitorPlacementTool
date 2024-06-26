﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolCore.VisitorGroupClasses
{
    public class VisitorGroup
    {
        private int _id;
        public int Id { get { return _id; } }

        private List<Visitor> _visitors;
        public List<Visitor> Visitors { get { return _visitors; } }


        public VisitorGroup(int id, List<Visitor> visitors)
        {
            _id = id;
            _visitors = visitors;
        }

        public void SortVisitorsByAge()
        {
            _visitors.OrderBy(v => v.Birthdate);
        }

        public int GetChildrenPlusChaperoneCount(DateTime time)
        {
            int result = 0;
            foreach(Visitor visitor in Visitors)
            {
                if ((time.Year - visitor.Birthdate.Year) <= 12)
                {
                    result++;
                }
            }
            if(result > 0) result++;
            return result;
        }
    }
}
