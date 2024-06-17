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
		private int _name;
		public int Name { get { return _name; } }

		private Visitor _visitor;
		public Visitor Visitor { get { return _visitor; } }

		public Chair(int name, Visitor visitor)
		{
			_name = name;
			_visitor = visitor;
		}

		public Chair(int name)
		{
			_name = name;
		}


	}
}
