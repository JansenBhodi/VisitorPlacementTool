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
		public int TotalChairs { get { return TotalChairCount(); } }

		public Section(string name)
		{
			_name = name;
			_rows = new List<Row>();
		}

		private int TotalChairCount()
		{
			int result = 0;
			try
            {
                foreach (Row row in _rows)
                {
					result += row.Chairs.Count();
                }
            }
			catch (Exception)
			{
				throw new InvalidDataException("There are no existing rows in this section: " + Name);
			}

			return result;
		}
	}
}
