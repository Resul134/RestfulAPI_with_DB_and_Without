using System;
using System.Collections.Generic;
using System.Text;

namespace RestLibrary.model
{
    public class Item
    {
        private int _id;
        private string _name;
        private string _quality;
        private double _quantity;


        public Item()
        {
        }

        public Item(int id, string name, string quality, double quantity)
        {
            _id = id;
            _name = name;
            _quality = quality;
            _quantity = quantity;
        }


        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string ToString()
        {
            return $"{nameof(Quantity)}: {Quantity}, {nameof(Quality)}: {Quality}, {nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }
}
