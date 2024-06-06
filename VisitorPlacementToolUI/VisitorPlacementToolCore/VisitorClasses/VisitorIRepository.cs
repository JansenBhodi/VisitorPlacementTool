using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolCore.VisitorClasses
{
    public interface VisitorIRepository
    {
        public bool CreateVisitor(string name, DateOnly birthdate);
    }
}
