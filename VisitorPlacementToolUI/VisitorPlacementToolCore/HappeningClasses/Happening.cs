using VisitorPlacementToolCore.RowClasses;
using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolCore.HappeningClasses
{
    public class Happening
    {
        private int _id;
        public int Id { get { return _id; } }

        private DateTime _lastSignupDate;
        public DateTime LastSignupDate { get { return _lastSignupDate; } }

        private DateTime _dateOfHappening;
        public DateTime DateOfHappening { get { return _dateOfHappening; } }

        private List<VisitorGroup> _groups;
        public List<VisitorGroup> Groups { get { return _groups; } }

        private List<Section> _sections;
        public List<Section> sections { get { return _sections; } }

        public Happening(DateTime lastSignupDate, DateTime dateOfHappening)
        {
            _lastSignupDate = lastSignupDate;
            _dateOfHappening = dateOfHappening;
        }

		public Happening(DateTime lastSignupDate, DateTime dateOfHappening, List<Section> sections)
		{
            _sections = sections;
			_lastSignupDate = lastSignupDate;
			_dateOfHappening = dateOfHappening;
		}

        public bool AddGroup(VisitorGroup group)
        {
            try
            {
                _groups.Add(group);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }

        public int GetCurrentVisitors()
        {
            int result = 0;
            try
            {
                foreach(VisitorGroup group in _groups)
                {
                    result += group.Visitors.Count();
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }

        public int GetMaxVisitors()
        {
            int result = 0;
            try
            {
                foreach (Section section in _sections)
                {
                    foreach (Row row in section.Rows)
                    {
                        result += row.Chairs.Count();
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
	}
}
