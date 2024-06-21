using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolCore.VisitorClasses
{
    public interface IVisitorInterface
    {
        public bool CreateVisitor(string name, DateTime birthdate);
        public Visitor GetVisitorById(int id);
        public List<Visitor> GetVisitorsByGroup(int groupId);
        public bool InsertVisitorIntoGroup(int visitorId, int groupId);
    }
}
