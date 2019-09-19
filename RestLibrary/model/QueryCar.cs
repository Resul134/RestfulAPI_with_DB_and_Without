using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.model
{
    public class QueryCar
    {
        private int _minYear;
        private int _maxYear;

        public QueryCar()
        {
        }

        public QueryCar(int minYear, int maxYear)
        {
            MinYear = minYear;
            MaxYear = maxYear;
        }


        public int MaxYear
        {
            get { return _maxYear; }
            set { _maxYear = value; }
        }

        public int MinYear
        {
            get { return _minYear; }
            set { _minYear = value; }
        }

        public override string ToString()
        {
            return $"{nameof(MaxYear)}: {MaxYear}, {nameof(MinYear)}: {MinYear}";
        }
    }
}
