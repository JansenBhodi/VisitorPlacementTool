﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.ChairClasses;


namespace VisitorPlacementToolCore.RowClasses
{
	public class RowService
	{

		public RowService()
		{

		}

		public Row CreateNewRow(int rowNumber)
		{
			if (rowNumber < 0) return new Row(rowNumber);
			else throw new InvalidDataException("Number was impossible, check sorting loop.");
		}

		public Row FillNewRow(int rowNumber, Visitor[] visitors)
		{
			if(!(visitors.Length > 2 && visitors.Length < 11))
			{
				throw new IndexOutOfRangeException("A row need to be at least 3 seats long and may only have a maximum of 10 seats.");
			}

			Row Result = null;

			try
			{
				Result = CreateNewRow(rowNumber);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			int counter = 1;
			try
			{
				foreach (Visitor visitor in visitors)
				{
					Result.Chairs.Add(new Chair(counter, visitor));
					counter++;
				}
			}
			catch (Exception ex)
			{
				throw new InvalidDataException("Data was not aligned with expected format.", ex);
			}

			return Result;
		}
	}
}
