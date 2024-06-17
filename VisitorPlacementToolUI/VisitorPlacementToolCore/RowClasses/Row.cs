using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.ChairClasses;

namespace VisitorPlacementToolCore.RowClasses
{
	public class Row
	{
		private int _name;
		public int Name { get { return _name; } }

		private List<Chair> _chairs;
		public List<Chair> Chairs { get { return _chairs; } }

		public Row(int name)
		{
			_name = name;
			_chairs = new List<Chair>();
		}


	}
}
