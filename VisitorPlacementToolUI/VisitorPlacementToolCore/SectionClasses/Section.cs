using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.RowClasses;

namespace VisitorPlacementToolCore.SectionClasses
{
	public class Section
	{
		private string _name;
		public string Name { get { return _name; } }

		private List<Row> _rows;
		public List<Row> Rows { get { return _rows; } }

		public Section(string name)
		{
			_name = name;
			_rows = new List<Row>();
		}


	}
}
