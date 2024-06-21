using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolCore.HappeningClasses
{
	public class HappeningService
	{
		private IHappeningInterface _repo;
		private VisitorGroupService _groupService;
		private SectionService _sectionService;

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

		public Happening StartNewHappening(List<Section> sections, DateTime signupDate, DateTime HappeningDate)
		{
			Happening result = null;
			try
			{
				result = new Happening(signupDate, HappeningDate, sections);
			}
			catch (Exception)
			{

				throw;
			}

			//Save Result to database.

			return result;
		}

		public bool AddGroupToHappening(Happening target, VisitorGroup group)
		{
			int checker = 0;
			foreach(VisitorGroup listed in target.Groups)
			{
				checker += listed.Visitors.Count();
			}
			try
			{
				if ((checker + group.Visitors.Count()) > target.GetMaxVisitors())
				{
					return false;
				}
                return target.AddGroup(group);
            }
			catch (Exception)
			{

				throw;
			}
		}

		#region Sorting
		
		public List<Section> StartSorting(Happening happening)
		{
			List<Section> result = new List<Section>();

			List<VisitorGroup> sorted = new List<VisitorGroup>();
			List<VisitorGroup> unsorted = new List<VisitorGroup>();
			try
            {
                int check = 0;
                foreach (VisitorGroup group in happening.Groups)
                {
                    check += group.Visitors.Count();
                    if (check! > happening.GetMaxVisitors())
                    {
                        sorted.Add(group);
                    }
                    else
                    {
                        check -= group.Visitors.Count();
                        unsorted.Add(group);
                    }
                }
            }
			catch (Exception ex)
			{

				throw ex;
			}


			List<VisitorGroup> childrenGroups = new List<VisitorGroup>();
            try
            {
                childrenGroups = GetAllGroupsWithChildren(sorted, happening.DateOfHappening);
            }
			catch (Exception ex)
			{

				throw ex;
			}

			List<int> childSeatsNeeded = new List<int>();
			try
            {
                childSeatsNeeded = CalculateSeatsNeededForChildren(childrenGroups, happening.DateOfHappening);
            }
			catch (Exception ex)
			{

				throw ex;
			}

			int attendingVisitors = 0;
			foreach(VisitorGroup group in sorted)
			{
				attendingVisitors += group.Visitors.Count();
			}

            //compare ascending to descending on which is optimal.
			
            if (CalculateAscendingVsDescending(happening, attendingVisitors, childSeatsNeeded.Sum()))
			{
                //Sort by Ascending
                happening.sections.OrderBy(s => s.TotalChairs);
                childrenGroups = childrenGroups.OrderBy(g => g.GetChildrenPlusChaperoneCount(happening.DateOfHappening)).ToList();
                childSeatsNeeded = childSeatsNeeded.OrderBy(g => g).ToList();
                result = SortGroupsToSections(sorted, childrenGroups, childSeatsNeeded, CalculateAscendingSeats(happening, attendingVisitors, childSeatsNeeded.Sum()));
            }
			else
			{
				//Sort by Descending
				happening.sections.OrderByDescending(s => s.TotalChairs);
                childrenGroups = childrenGroups.OrderByDescending(g => g.GetChildrenPlusChaperoneCount(happening.DateOfHappening)).ToList();
                childSeatsNeeded = childSeatsNeeded.OrderByDescending(g => g).ToList();
                result = SortGroupsToSections(sorted, childrenGroups, childSeatsNeeded, CalculateDescendingSeats(happening, attendingVisitors, childSeatsNeeded.Sum()));
            }


            return result;
		}

        public bool CalculateAscendingVsDescending(Happening happening, int attendingVisitors, int childSeatsNeeded)
		{
			if (CalculateAscendingSeats(happening, attendingVisitors, childSeatsNeeded) >= CalculateDescendingSeats(happening, attendingVisitors, childSeatsNeeded)) return true;
			else return false;
        }

		public int CalculateDescendingSeats(Happening happening, int attendingVisitors, int childSeatsNeeded)
        {
            try
            {
                happening.sections.OrderByDescending(s => s.TotalChairs);
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Sorting of section list failed", ex);
            }
            int DescendingSectionCount = 0;

            int openSeats = 0;
            int childrenSeats = 0;

            foreach (Section section in happening.sections)
            {
                openSeats += section.TotalChairs;
                childrenSeats += section.Rows[0].Chairs.Count();
                DescendingSectionCount++;
                if (openSeats >= attendingVisitors && childrenSeats >= childSeatsNeeded)
                {
                    break;
                }
            }
			return DescendingSectionCount;
        }

		public int CalculateAscendingSeats(Happening happening, int attendingVisitors, int childSeatsNeeded)
		{
            try
            {
                happening.sections.OrderBy(s => s.TotalChairs);
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Sorting of section list failed", ex);
            }

            int AscendingSectionCount = 0;

            int openSeats = 0;
            int childrenSeats = 0;

            foreach (Section section in happening.sections)
            {
                openSeats += section.TotalChairs;
                childrenSeats += section.Rows[0].Chairs.Count();
                AscendingSectionCount++;
                if (openSeats >= attendingVisitors && childrenSeats >= childSeatsNeeded)
                {
                    break;
                }
            }
			return AscendingSectionCount;
        }


		public List<Section> SortGroupsToSections(List<VisitorGroup> groups, List<VisitorGroup> childGroups, List<int> ChildrenPerGroup, int sectionsNeeded)
		{
			List<Section> sections = new List<Section>();
            List<Visitor> visitors = new List<Visitor>();
			
			int p = 0;
			//Grab children groups, spread them out over the sections. remove unneeded adults
			try
            {
                foreach (VisitorGroup cgroup in childGroups)
                {

                    cgroup.SortVisitorsByAge();
                    for (int i = ChildrenPerGroup[p] + 1; i <= cgroup.Visitors.Count(); i++)
                    {
						visitors.Add(cgroup.Visitors[i]);
                    }
                    p++;
                }
            }
			catch (Exception)
			{

				throw;
			}

			try
			{
				sections = _sectionService.FillChildren(sections, childGroups, ChildrenPerGroup);
			}
			catch (Exception ex)
			{

				throw ex;
			}


			//Remove child groups from the main group list
			groups = groups.Except(childGroups).ToList();
			foreach (VisitorGroup group in groups) 
			{ 
				visitors.AddRange(group.Visitors); 
			}

			//Fill sections with remaining groups
			try
			{
				sections = _sectionService.FillRemainingSeats(sections, visitors, sectionsNeeded);
			}
			catch (Exception ex)
			{

				throw ex;
			}

			//return result

			return sections;
		}

        public List<VisitorGroup> GetAllGroupsWithChildren(List<VisitorGroup> groups, DateTime date)
        {
            List<VisitorGroup> result = new List<VisitorGroup>();
			try
            {
                foreach (VisitorGroup group in groups)
                {
                    bool check = false;
                    foreach (Visitor visitor in group.Visitors)
                    {
                        if ((date.Year - visitor.Birthdate.Year) <= 12)
                        {
                            check = true;
                        }
                    }
                    if (check)
                    {
                        result.Add(group);
                    }
                }
            }
			catch (Exception ex)
			{

				throw new InvalidDataException("", ex);
			}

            return result;
        }

		public List<int> CalculateSeatsNeededForChildren(List<VisitorGroup> groups, DateTime date)
		{
			List<int> result = new List<int>();
			bool AdultPresent = false;
			try
			{
				foreach(VisitorGroup group in groups)
				{
					int input = 0;
					foreach(Visitor visitor in group.Visitors)
                    {
                        if ((date.Year - visitor.Birthdate.Year) <= 12)
                        {
                            input++;
                        }
						else
						{
							AdultPresent = true;
						}
                    }
					if(!AdultPresent)
					{
						throw new InvalidOperationException("A group with only children has gotten in.");
					}
					AdultPresent = false;
                    input++;
					result.Add(input);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}


			return result;
		}

        #endregion
    }
}
