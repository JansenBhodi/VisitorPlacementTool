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

		public bool AssignChair(Chair chair)
		{
			try
            {
				if(_chairs.Count() != 11)
                {
                    _chairs.Add(chair);
					return true;
                }
				else
				{
					throw new InvalidOperationException("This Row has reached the maximum amount of chairs.");
				}
            }
			catch (Exception ex)
			{

				throw ex;
			}
			return false;
		}

	}
}
