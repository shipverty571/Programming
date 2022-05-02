namespace Programming.Model
{
    public class Movie
    {
        private static int _allMoviesCount;

        private int _releaseYear;

        private double _rating;

        private int _durationMinutes;

        private int _id;

        public Movie()
        {
            _allMoviesCount++;
            _id = _allMoviesCount;
        }

        public Movie(int releaseYear,
                    int durationMinutes,
                    int rating,
                    string name,
                    string genre
                    )
        {
            ReleaseYear = releaseYear;
            DurationMinutes = durationMinutes;
            Rating = rating;
            Name = name;
            Genre = genre;
            _allMoviesCount++;
            _id = _allMoviesCount;
        }

        public int Id => _id;

        public string Name { get; set; }

        public string Genre { get; set; }

        public int DurationMinutes
        {
            get
            {
                return _durationMinutes;
            }
            set
            {
                Validator.AssertOnPositiveValue(nameof(DurationMinutes), value);
                _durationMinutes = value;
            }
        }

        public int ReleaseYear
        {
            get
            {
                return _releaseYear;
            }
            set
            {
                Validator.AssertValueInRange(nameof(ReleaseYear), value, 1900, 2022);
                _releaseYear = value;
            }
        }

        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                Validator.AssertValueInRange(nameof(Rating), value, 0d, 10d);
                _rating = value;
            }
        }
    }
}
