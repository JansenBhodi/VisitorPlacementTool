using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.VisitorClasses;

namespace VisitorPlacementToolCore.SectionClasses
{
	public class SectionService
	{
		RowService _rowService = new RowService();

		public SectionService() 
		{ 
		
		}

		public Section CreateNewSection(string name)
		{
			if(name == null) throw new ArgumentNullException("name");
			else return new Section(name);
		}

		public Section FillNewSection(string name, List<Visitor> visitors, int chairsPerRow)
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
			
			foreach (Visitor visitor in visitors)
			{
				for (int i = 0; i < chairsPerRow; i++)
				{

				}
			}



			return result;
		}

		public Section NewSectionWithChildren(string name, List<Visitor> visitors)
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

			foreach(Visitor visitor in visitors)
			{
				//fill @section last open row slots.
			}

			return section;
		}
	}
}
