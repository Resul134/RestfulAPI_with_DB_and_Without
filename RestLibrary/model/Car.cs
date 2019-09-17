using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary
{
    public class Car
    {
        private int _id;
        private int _year;
        private string _color;


        public Car()
        {
        }


        public Car(int id, int year, string color)
        {
            _id = id;
            _year = year;
            _color = color;
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Color)}: {Color}, {nameof(Year)}: {Year}, {nameof(Id)}: {Id}";
        }

    }

    
}
