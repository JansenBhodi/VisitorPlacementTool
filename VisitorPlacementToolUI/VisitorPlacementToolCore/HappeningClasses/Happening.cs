using VisitorPlacementToolCore.SectionClasses;
using VisitorPlacementToolCore.VisitorGroupClasses;

namespace VisitorPlacementToolCore.HappeningClasses
{
    public class Happening
    {
        private int _id;
        public int Id { get { return _id; } }

        private int _maxVisitors;
        public int MaxVisitors { get { return _maxVisitors; } }

        private DateOnly _lastSignupDate;
        public DateOnly LastSignupDate { get { return _lastSignupDate; } }

        private DateOnly _dateOfHappening;
        public DateOnly DateOfHappening { get { return _dateOfHappening; } }

        private List<VisitorGroup> _groups;
        public List<VisitorGroup> Groups { get { return _groups; } }

        private List<Section> _sections;
        public List<Section> sections { get { return _sections; } }

        public Happening(int maxVisitors, DateOnly lastSignupDate, DateOnly dateOfHappening)
        {
            _maxVisitors = maxVisitors;
            _lastSignupDate = lastSignupDate;
            _dateOfHappening = dateOfHappening;
        }

		public Happening(int maxVisitors, DateOnly lastSignupDate, DateOnly dateOfHappening, List<VisitorGroup> groups)
		{
            _groups = groups;
			_maxVisitors = maxVisitors;
			_lastSignupDate = lastSignupDate;
			_dateOfHappening = dateOfHappening;
		}

	}
}
