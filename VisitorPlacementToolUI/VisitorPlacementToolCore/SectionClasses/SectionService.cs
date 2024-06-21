using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolCore.SectionClasses
{
	public class SectionService
	{
		RowService _rowService = new RowService();

		public SectionService() 
		{ 
		
		}

        public List<Section> FillChildren(List<Section> input, List<VisitorGroup> groups, List<int> visitorsToBeSeated)
        {
            int section = 0;
            int chair = 0;

            for (int count = 0; count < groups.Count; count++)
            {
                VisitorGroup group = groups[count];
                int groupSize = visitorsToBeSeated[count];  // Number of visitors including the chaperone

                if (group.Visitors.Count < groupSize)
                {
                    throw new ArgumentException("Group does not have enough visitors to match the visitorsToBeSeated count.");
                }

                for (int i = 0; i < groupSize; i++)
                {
                    // Check if we need to move to the next section
                    if (chair >= input[section].Rows[0].Chairs.Count)
                    {
                        section++;
                        chair = 0;

                        // Ensure we do not exceed the number of available sections
                        if (section >= input.Count)
                        {
                            throw new InvalidOperationException("Not enough front row seats to accommodate all groups.");
                        }
                    }

                    Visitor visitor = group.Visitors[i];
                    input[section].Rows[0].Chairs[chair].AssignChair(visitor);
                    chair++;
                }
            }

            return input;
        }

        public List<Section> FillRemainingSeats(List<Section> input, List<Visitor> visitors, int sectionsNeeded)
        {
            int row = 0;
            int chair = 0;

            foreach (Visitor visitor in visitors)
            {
                bool assigned = false;

                while (!assigned)
                {
                    for (int section = 0; section < sectionsNeeded && section < input.Count; section++)
                    {
                        if (row < input[section].Rows.Count)
                        {
                            while (chair < input[section].Rows[row].Chairs.Count)
                            {
                                if (input[section].Rows[row].Chairs[chair].Visitor == null)
                                {
                                    input[section].Rows[row].Chairs[chair].AssignChair(visitor);
                                    assigned = true;
                                    chair++;
                                    break;
                                }
                                chair++;
                            }

                            if (assigned)
                            {
                                break;
                            }

                            // Reset chair to 0 for the next section in the same row
                            chair = 0;
                        }
                    }

                    if (!assigned)
                    {
                        // Move to the next row if the current row is fully processed
                        row++;
                        chair = 0; // Reset chair for the new row
                    }
                }
            }

            return input;
        }

        public IEnumerable<Visitor[]> DivideByN(List<Visitor> visitors, int chairsPerRow)
		{
			if(visitors == null || visitors.Count < 1)
            {
                throw new InvalidDataException("Input data (Visitors) is invalid.");
            }
			if(chairsPerRow == null || chairsPerRow < 1)
			{
				throw new InvalidDataException("Input data (ChairsPerRow) is invalid.");
			}
            IEnumerable<Visitor[]> result = new List<Visitor[]>();

            try
            {
                result = visitors.Chunk(chairsPerRow);
            }
			catch (Exception ex)
			{

				throw new InvalidCastException("Data could not be converted.", ex);
			}

			return result;
		}

        #region Unused
        public Section CreateNewSection(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            else return new Section(name);
        }

        public Section FillNewSection(string name, List<Visitor> visitors, int chairsPerRow)
        {
            Section result;
            try
            {
                result = CreateNewSection(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {
                IEnumerable<Visitor[]> sorting = DivideByN(visitors, chairsPerRow);
                try
                {
                    int rowCount = 1;
                    foreach (Visitor[] output in sorting)
                    {
                        result.Rows.Add(_rowService.FillNewRow(rowCount, output));
                        rowCount++;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Section NewSectionWithChildren(string name, Visitor[] visitors)
        {
            Section result = null;
            try
            {
                result = CreateNewSection(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            result.Rows.Add(_rowService.FillNewRow(1, visitors));


            return result;
        }

        public Section FillExistingSection(Section section, List<Visitor> visitors)
        {
            int rowCounter = section.Rows.Count();
            int chairPerRow = section.Rows[0].Chairs.Count();

            foreach (Visitor visitor in visitors)
            {
                //fill @section last open row slots.
            }

            return section;
        }
        #endregion
    }
}
