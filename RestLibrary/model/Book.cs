using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.model
{
    public class Book
    {
        private string _isbn13;
        private string _name;
        private int _year;


        public Book()
        {
        }

        public Book(string isbn13, string name, int year)
        {
            _isbn13 = isbn13;
            _name = name;
            _year = year;
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Isbn13
        {
            get { return _isbn13; }
            set { _isbn13 = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Year)}: {Year}, {nameof(Name)}: {Name}, {nameof(Isbn13)}: {Isbn13}";
        }
    }
}
