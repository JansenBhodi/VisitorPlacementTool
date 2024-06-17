using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolCore.ChairClasses
{
	public class ChairService
	{
		public ChairService() 
		{


		}
		public Chair AddChair(Visitor visitor, int chairCount)
		{
			try
			{
				return new Chair(chairCount, visitor);
			}
			catch (Exception ex)
			{
				throw new InvalidDataException("Something was wrong with the given visitor, check its data state.", ex);
			}
		}

		public bool CheckAvailability(Chair chair)
		{
			if (chair.Visitor != null)
			{
				return false;
			}
			return true;
		}
	}
}
