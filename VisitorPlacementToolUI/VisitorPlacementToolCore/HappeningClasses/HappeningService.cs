using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolCore.HappeningClasses
{
	public class HappeningService
	{
		private IHappeningInterface _repo;

		public HappeningService(IHappeningInterface repo)
		{
			_repo = repo;
		}

		#region Database
		//Database functions
		public bool CreateHappening(int maxVisitors, DateOnly signupDate, DateOnly eventDate)
		{
			try
			{
				if (!ValidateHappeningData(maxVisitors, signupDate, eventDate))
				{
					return false;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

			bool result = false;

			try
			{
				result = _repo.CreateNewHappening(maxVisitors, signupDate, eventDate);
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return result;
		}

		public bool UpdateHappening(int happeningId, int maxVisitors, DateOnly signupDate, DateOnly eventDate)
		{
			try
			{
				if (!ValidateHappeningData(maxVisitors, signupDate, eventDate))
				{
					return false;
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

			bool result = false;

			try
			{
				result = _repo.UpdateHappening(happeningId, maxVisitors, signupDate, eventDate);
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return result;
		}

		public List<Happening> GetHappeningsByGroupId(int groupId)
		{
			if(groupId < 0)
			{
				throw new InvalidDataException("id was invalid, check status of group");
			}


			List<Happening> result = new List<Happening>();

			try
			{
				result = _repo.GetHappeningsByGroupId(groupId);
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Caught Data was wrong.", ex);
			}
			return result;
		}
		public Happening GetHappeningById(int id)
		{
			if (id < 0)
			{
				throw new InvalidDataException("id was invalid, check status of happening");
			}

			Happening result = null;

			try
			{
				result = _repo.GetHappeningById(id);
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Caught Data was wrong.", ex);
			}
			return result;
		}

		public bool ValidateHappeningData(int maxVisitors, DateOnly signupDate, DateOnly eventDate)
		{
			try
			{
				if (maxVisitors > 0 || signupDate > DateOnly.FromDateTime(DateTime.Now) || eventDate > DateOnly.FromDateTime(DateTime.Now))
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Data was incorrect", ex);
			}
		}

		#endregion

		#region Sorting
		//Start sorting here


		#endregion
	}
}
