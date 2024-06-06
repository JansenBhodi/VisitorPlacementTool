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

        public Happening(int maxVisitors, DateOnly lastSignupDate, DateOnly dateOfHappening)
        {
            _maxVisitors = maxVisitors;
            _lastSignupDate = lastSignupDate;
            _dateOfHappening = dateOfHappening;
        }


    }
}
