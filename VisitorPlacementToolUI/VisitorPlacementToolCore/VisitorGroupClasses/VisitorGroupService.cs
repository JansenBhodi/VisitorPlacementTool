using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolCore.VisitorGroupClasses
{
	public class VisitorGroupService
	{

		private IGroupRepository _groupRepo;

		public VisitorGroupService(IGroupRepository groupRepo)
		{
			_groupRepo = groupRepo;
		}

		#region Database
		public VisitorGroup GetGroupByVisitor(int visitorId)
		{
			VisitorGroup visitorGroup = null;
			if(visitorId < 0)
			{
				throw new InvalidDataException("Visitor Id was invalid, check selected happening data");
			}

			try
			{
				visitorGroup = _groupRepo.GetGroupByVisitorId(visitorId);
			}
			catch (Exception ex)
			{
				throw new InvalidDataException("Data did not align to expected data values.", ex);
			}

			return visitorGroup;
		}

		public bool CreateNewVisitorGroup(int visitorId)
		{
			if (visitorId < 0)
			{
				throw new InvalidDataException("Visitor Id was invalid, check selected happening data");
			}

			try
			{
				return _groupRepo.CreateNewVisitorGroup(visitorId);
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Data did not align to expected data values.", ex);
			}
		}

		public List<VisitorGroup> GetGroupsByHappeningId(int happeningId)
		{
			List<VisitorGroup> result = new List<VisitorGroup>();

			if(happeningId < 0)
			{
				throw new InvalidDataException("HappeningId was invalid, check selected happening data");
			}

			try
			{
				foreach(VisitorGroup output in _groupRepo.GetGroupsByHappeningId(happeningId))
				{
					result.Add(output);
				}
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Invalid data caused data retrieval to fail. Check if correct information was called.", ex);
			}

			return result;	
		}

		#endregion

		#region Sorting

		public bool DoesGroupHaveChild(VisitorGroup group, DateOnly eventDate)
		{
			foreach(Visitor visitor in group.Visitors)
			{
				if (new VisitorService().IsVisitorChild(eventDate, visitor)) return true;
			}
			return false;
		}

		#endregion
	}
}
