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
		private string _name;
		public string Name { get { return _name; } }

		private List<Chair> _chairs;
		public List<Chair> Chairs { get { return _chairs; } }

		public Row(string name)
		{
			_name = name;
			_chairs = new List<Chair>();
		}


	}
}
