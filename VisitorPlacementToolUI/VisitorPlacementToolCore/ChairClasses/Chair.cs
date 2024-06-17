using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolCore.ChairClasses
{
	public class Chair
	{
		private string _name;
		public string Name { get { return _name; } }

		private Visitor _visitor;
		public Visitor Visitor { get { return _visitor; } }

		public Chair(string name, Visitor visitor)
		{
			_name = name;
			_visitor = visitor;
		}
	}
}
