using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.HappeningClasses;

namespace VisitorPlacementToolCore.VisitorClasses
{
    public class Visitor
    {
        private int _id;
        public int Id { get { return _id; } }

        private string _name;
        public string Name { get { return _name; } }

        private DateOnly _birthdate;
        public DateOnly Birthdate { get {  return _birthdate; } }

        public Visitor(int id, string name, DateOnly birthdate)
        {
            _id = id;
            _name = name;
            _birthdate = birthdate;
        }

    }
}
