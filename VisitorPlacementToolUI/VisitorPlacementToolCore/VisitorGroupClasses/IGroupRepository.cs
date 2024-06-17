using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolCore.VisitorGroupClasses
{
	public interface IGroupRepository
	{
		public VisitorGroup GetGroupById(int id);
		public VisitorGroup GetGroupByVisitorId(int visitorId);
		public bool CreateNewVisitorGroup(int visitorId);
		public List<VisitorGroup> GetGroupsByHappeningId(int happeningId);

	}
}
