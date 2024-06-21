using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPlacementToolCore.HappeningClasses;

namespace VisitorPlacementToolCore.VisitorClasses
{
    public class VisitorService
    {
        private IVisitorInterface _repository;

        public VisitorService(IVisitorInterface repository)
        {
            _repository = repository;
        }

        public VisitorService()
        {
            //used when sorting, does not need database calls
        }

		#region Database
		public bool CreateVisitor(string name, DateTime birthdate)
        {
            try
            {
                if(ValidateNewVisitor(name, birthdate))
                {
                    return _repository.CreateVisitor(name, birthdate);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Visitor GetVisitorById(int visitorId)
        {
            if(visitorId < 0)
            {
				throw new InvalidDataException("Visitor Id was invalid, check selected happening data");
			}

            try
            {
                return _repository.GetVisitorById(visitorId);
            }
            catch (Exception ex)
            {

                throw new InvalidDataException("Data invalid", ex);
            }
        }

        public List<Visitor> GetVisitorsByGroupId(int groupId)
        {
            if(groupId < 0)
            {
                throw new InvalidDataException("Visitor Id was invalid, check selected happening data");
            }

			try
			{
				return _repository.GetVisitorsByGroup(groupId);
			}
			catch (Exception ex)
			{

				throw new InvalidDataException("Data invalid", ex);
			}
		}

        public bool AddVisitorToGroup(int visitorId, int groupId)
        {
            if(visitorId < 0 || groupId < 0)
			{
				throw new InvalidDataException("Visitor Id was invalid, check selected happening data");
			}

            try
            {
                return _repository.InsertVisitorIntoGroup(visitorId, groupId);
            }
            catch (Exception ex)
            {

				throw new InvalidDataException("Data invalid", ex);
			}
        }

        public bool ValidateNewVisitor(string name, DateTime birthdate)
        {
            try
            {
                if (string.IsNullOrEmpty(name) && birthdate == null) return true;
                else
                {
                    throw new InvalidDataException("Data did not match up to standard");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Data did not match up to standard", ex);
            }
        }
		#endregion

		#region Sorting

        public bool IsVisitorChild(DateOnly eventDate, Visitor visitor)
        {
            var ageDifference = eventDate.Year - visitor.Birthdate.Year;
            if(ageDifference > 12)
            {
                return true;
            }
            return false;
        }

		#endregion
	}
}
