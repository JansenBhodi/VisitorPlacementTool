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
        private VisitorIRepository _repository;

        public VisitorService(VisitorIRepository repository)
        {
            _repository = repository;
        }

        public bool CreateVisitor(string name, DateOnly birthdate)
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

        public bool JoinHappening(Happening happening)
        {
            return true;
        }

        public bool ValidateNewVisitor(string name, DateOnly birthdate)
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
    }
}
