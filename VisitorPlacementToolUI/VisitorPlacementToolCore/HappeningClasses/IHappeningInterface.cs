using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolCore.HappeningClasses
{
	public interface IHappeningInterface
	{
		public bool CreateNewHappening(int maxVisitors, DateOnly finalSignup, DateOnly happeningDate);
		public bool UpdateHappening(int happeningId, int maxVisitors, DateOnly finalSignup, DateOnly happeningDate);
		public List<Happening> GetHappeningsByGroupId(int groupId);
		public Happening GetHappeningById(int id);
	}
}
